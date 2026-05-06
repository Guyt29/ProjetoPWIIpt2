using MySql.Data.MySqlClient;
using ProjetoEmprestimo.Models;
using ProjetoEmprestimo.Repository.Contract;

namespace ProjetoEmprestimo.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly string _conexaoMySQL;
        private MySqlConnection conexao;

        public ItemRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }

        public void Atualizar(Item item)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Item item)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("insert into itensEmp values(default, @codEmp, @codLivro)", conexao);

                cmd.Parameters.Add("@codEmp", MySqlDbType.VarChar).Value = item.codEmp;
                cmd.Parameters.Add("@codLivro", MySqlDbType.VarChar).Value = item.codLivro;
                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public IEnumerable<Item> ObterTodosLivros()
        {
            throw new NotImplementedException();
        }


        void IItemRepository.Excluir(int id)
        {
            throw new NotImplementedException();
        }

        Livro IItemRepository.ObterLivros(int id)
        {
            throw new NotImplementedException();
        }

    }
}
