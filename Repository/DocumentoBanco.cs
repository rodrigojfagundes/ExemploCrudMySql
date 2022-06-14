using MySqlConnector;
using System;
using System.Collections.Generic;
using ExemploCrudMySql.Models;

namespace ExemploCrudMySql.Repository
{
    public class DocumentoBanco
    {
        private const string DadosConexao = "Server=localhost;Database=exemplo_crud;Uid=root;Connect Timeout = 60;";

        public List<Documento> Listar()
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            string Query = "SELECT * FROM documento ORDER BY titulo";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            MySqlDataReader Reader = Comando.ExecuteReader();

            List<Documento> Lista = new List<Documento>();

            while (Reader.Read())
            {
                Documento DocumentoEncontrado = new Documento();
                DocumentoEncontrado.Codigo = Reader.GetInt32("Codigo");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Titulo")))
                    DocumentoEncontrado.Titulo = Reader.GetString("Titulo");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Processo")))
                    DocumentoEncontrado.Processo = Reader.GetString("Processo");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Categoria")))
                    DocumentoEncontrado.Categoria = Reader.GetString("Categoria");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Arquivo")))
                    DocumentoEncontrado.Arquivo = Reader.GetString("Arquivo");

                Lista.Add(DocumentoEncontrado);
            }
            Conexao.Close();
            return Lista;
        }

        public void Inserir(Documento documento)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            string Query = "INSERT INTO Documento (Codigo, Titulo, Processo, Categoria, Arquivo) VALUES (@Codigo, @Titulo, @Processo, @Categoria, @Arquivo)";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@Codigo", documento.Codigo);
            Comando.Parameters.AddWithValue("@Titulo", documento.Titulo);
            Comando.Parameters.AddWithValue("@Processo", documento.Processo);
            Comando.Parameters.AddWithValue("@Categoria", documento.Categoria);
            Comando.Parameters.AddWithValue("@Arquivo", documento.Arquivo);
            Comando.ExecuteNonQuery();
            Conexao.Close();
        }


        public void TestarConexao()
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            Console.WriteLine("Banco de dados funcionando!");
            Conexao.Close();
        }
    }
}
