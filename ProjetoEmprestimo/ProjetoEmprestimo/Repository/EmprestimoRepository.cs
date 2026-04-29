using MySql.Data.MySqlClient;
using ProjetoEmprestimo.Models;
using ProjetoEmprestimo.Repository.Contract;

namespace ProjetoEmprestimo.Repository
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly string _conexaoMySQL;

        public EmprestimoRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }

        public void Atualizar(Emprestimo emprestimo)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Emprestimo emprestimo)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("insert into tbEmprestimo values(default, @dtEmpre, @dtDev , @codUsu)", conexao);

                cmd.Parameters.Add("@dtEmpre", MySqlDbType.VarChar).Value = emprestimo.dtEmpre;
                cmd.Parameters.Add("@dtDev", MySqlDbType.VarChar).Value = emprestimo.dtDev;
                cmd.Parameters.Add("@codUsu", MySqlDbType.VarChar).Value = emprestimo.codUsu;
                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }
        public void buscaIdEmp(Emprestimo emprestimo)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlDataReader dr;
                MySqlCommand cmd = new MySqlCommand("SELECT codEmp FROM tbEmprestimo ORDER BY codEmp DESC limit 1", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    emprestimo.codEmp = dr[0].ToString();
                }
                conexao.Close();
            }
        }
        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public Emprestimo ObterEmprestimo(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Livro> ObterEmprestimos()
        {
            throw new NotImplementedException();
        }
    }
}
