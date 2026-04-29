using Microsoft.AspNetCore.Identity;
using MySql.Data.MySqlClient;
using ProjetoEmprestimo.Controllers;
using ProjetoEmprestimo.Models;
using ProjetoEmprestimo.Repository.Contract;
using System.Data;

namespace ProjetoEmprestimo.Repository
{
    public class LivroRepositorio : ILivroRepository
    {
        private readonly string _conexaoMySQL;
        private MySqlConnection conexao;

        public LivroRepositorio(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }

        public object Id { get; private set; }

        public void Atualizar(Livro livro)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Livro livro)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("insert into tbLivro values(default, @NomeLivro, @ImagemLivro)", conexao);
                cmd.Parameters.Add("@NomeLivro", MySqlDbType.VarChar).Value = livro.nomeLivro;
                cmd.Parameters.Add("@ImagemLivro", MySqlDbType.VarChar).Value = livro.imagemLivro;
                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Cadastrar(LivroController livro)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public Livro ObterLivro(int id)
        {
            throw new NotImplementedException();
        }

        public Livro ObterLivros(Livro Livro)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbLivro where codLivro=@cod )", conexao);
                cmd.Parameters.Add("@cod", MySqlDbType.VarChar).Value = Id;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Livro livro = new Livro();
                dr = cmd .ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    livro.codLivro = Convert.ToInt32(dr["codLivro"]);
                    livro.nomeLivro = (String)(dr["nomeLivro"]);
                    livro.imagemLivro = (String)(dr["imagemLivro"]);
                }
                return livro;
            }
        }

        public IEnumerable<Livro> ObterTodosLivros()
        {
            List<Livro> Livrolist = new List<Livro>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbLivro ", conexao);
                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sd.Fill(dt);
                conexao.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    Livrolist.Add(
                         new Livro
                         {
                             codLivro = Convert.ToInt32(dr["codLivro"]),
                             nomeLivro = (String)(dr["nomeLivro"]),
                             imagemLivro = (String)(dr["imagemLivro"]),
                         });
                }
                return Livrolist;
            }
        }

    }
}