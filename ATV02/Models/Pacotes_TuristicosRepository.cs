using System;
using System.Collections.Generic;
using MySqlConnector;

namespace ATV02.Models
{
    public class Pacotes_TuristicosRepository
    {
        private const string DadosConexao = "Database=destino_certo;Data source=localhost;User Id=root;";

        public Pacotes_Turisticos searchId(int Id){

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "SELECT * FROM pacotes_turisticos WHERE Id=@Id";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@Id", Id);

            MySqlDataReader Reader = Comando.ExecuteReader(); //Lê a informação que está no banco de dados

            Pacotes_Turisticos packageFind = new Pacotes_Turisticos();
            if(Reader.Read()){

                packageFind.Id = Reader.GetInt32("Id");
                
                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    packageFind.Nome = Reader.GetString("Nome");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Origem")))
                    packageFind.Origem = Reader.GetString("Origem");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Destino")))
                    packageFind.Destino = Reader.GetString("Destino");
                
                if (!Reader.IsDBNull(Reader.GetOrdinal("Atrativos")))
                    packageFind.Atrativos = Reader.GetString("Atrativos");

                packageFind.Saida = Reader.GetDateTime("Saida");
                
                packageFind.Retorno = Reader.GetDateTime("Retorno");

                packageFind.Usuario = Reader.GetInt32("Usuario");

            }

            Conexao.Close();
            return packageFind;

        }
        public List<Pacotes_Turisticos> listar(){
            
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "SELECT * FROM pacotes_turisticos";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            MySqlDataReader Reader = Comando.ExecuteReader();

            List<Pacotes_Turisticos> Lista = new List<Pacotes_Turisticos>();
            while(Reader.Read()){

                Pacotes_Turisticos packageFind = new Pacotes_Turisticos();
                packageFind.Id = Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    packageFind.Nome = Reader.GetString("Nome");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Origem")))
                    packageFind.Origem = Reader.GetString("Origem");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Destino")))
                    packageFind.Destino = Reader.GetString("Destino");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Atrativos")))
                    packageFind.Atrativos = Reader.GetString("Atrativos");

                packageFind.Saida = Reader.GetDateTime("Saida");
                
                packageFind.Retorno = Reader.GetDateTime("Retorno");

                packageFind.Usuario = Reader.GetInt32("Usuario");
                
                Lista.Add(packageFind);

            }

            Conexao.Close();
            return Lista;

        }
        public void inserir(Pacotes_Turisticos package){
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "INSERT INTO pacotes_turisticos (Nome, Origem,Destino, Atrativos, Saida, Retorno, Usuario) VALUES(@Nome, @Origem, @Destino, @Atrativos, @Saida, @Retorno, @Usuario)";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@Nome", package.Nome);
            Comando.Parameters.AddWithValue("@Origem", package.Origem);
            Comando.Parameters.AddWithValue("@Destino", package.Destino);
            Comando.Parameters.AddWithValue("@Atrativos", package.Atrativos);
            Comando.Parameters.AddWithValue("@Saida", package.Saida);
            Comando.Parameters.AddWithValue("@Retorno", package.Retorno);
            Comando.Parameters.AddWithValue("@Usuario", package.Usuario);

            Comando.ExecuteNonQuery();

            Conexao.Close();
        }
        public void atualizar(Pacotes_Turisticos package){
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "UPDATE pacotes_turisticos SET Nome=@Nome, Origem=@Origem, Atrativos=@Atrativos, Saida=@Saida, Retorno=@Retorno, Usuario=@Usuario where Id=@Id";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@Id", package.Id);
            Comando.Parameters.AddWithValue("@Nome", package.Nome);
            Comando.Parameters.AddWithValue("@Origem", package.Origem);
            Comando.Parameters.AddWithValue("@Atrativos", package.Atrativos);
            Comando.Parameters.AddWithValue("@Saida", package.Saida);
            Comando.Parameters.AddWithValue("@Retorno", package.Retorno);
            Comando.Parameters.AddWithValue("@Usuario", package.Usuario);

            Comando.ExecuteNonQuery();

            Conexao.Close();
        }
        public void excluir(Pacotes_Turisticos package){

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open(); //abrir conexao
                
            String Query = "DELETE FROM pacotes_turisticos WHERE Id=@Id"; //definir a query(sq)

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@Id", package.Id);

            Comando.ExecuteNonQuery();

            Conexao.Close();
        }
    }
}