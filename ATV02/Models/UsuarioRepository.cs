using System;
using System.Collections.Generic;
using MySqlConnector;

namespace ATV02.Models
{
    public class UsuarioRepository
    {
        private const string DadosConexao = "Database=destino_certo;Data source=localhost;User Id=root;";

        public void TestarConexao(){
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            Console.WriteLine("banco de daodos funcionando!");
            Conexao.Close();
        }

        public List<Usuario> listar(){
            
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "SELECT * FROM usuario";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            MySqlDataReader Reader = Comando.ExecuteReader();

            List<Usuario> Index = new List<Usuario>();
            while(Reader.Read()){

                Usuario userFind = new Usuario();
                userFind.Id = Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    userFind.Nome = Reader.GetString("Nome");
                
                Index.Add(userFind);

            }

            Conexao.Close();
            return Index;

        }

        public Usuario Login(Usuario user)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "SELECT * FROM Usuario WHERE login=@Login AND senha=@Senha";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);


            Comando.Parameters.AddWithValue("@Login", user.Login);
            Comando.Parameters.AddWithValue("@Senha", user.Senha);

            MySqlDataReader reader = Comando.ExecuteReader();
            Usuario userFind = null;
            if(reader.Read())
            {
                userFind = new Usuario();
                userFind.Id = reader.GetInt32("Id");
                if(!reader.IsDBNull(reader.GetOrdinal("Nome")))
                    userFind.Nome = reader.GetString("Nome");
            
                if(!reader.IsDBNull(reader.GetOrdinal("Login")))
                    userFind.Login = reader.GetString("Login");
                if(!reader.IsDBNull(reader.GetOrdinal("Senha")))
                    userFind.Senha = reader.GetString("Senha");
            }
        
            Conexao.Close();
            return userFind;
        }

        public void inserir(Usuario user){
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "INSERT INTO Usuario (Nome, Login,Senha,DataNascimento) VALUES(@Nome, @Login, @Senha, @DataNascimento)";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@Nome", user.Nome);
            Comando.Parameters.AddWithValue("@Login", user.Login);
            Comando.Parameters.AddWithValue("@Senha", user.Senha);
            Comando.Parameters.AddWithValue("@DataNascimento", user.DataNascimento);

            Comando.ExecuteNonQuery();

            Conexao.Close();
        }
    }

    
}