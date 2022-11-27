using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MenuDoSistema
{
    public class Banco
    {
        public static MySqlConnection Conexao;
        public static MySqlCommand Comando;
        // Inserir dados em um dataTable
        public static MySqlDataAdapter Adaptador;
        // DataTable reponsável por ligar o banco em controles com a propriedade DataSource
        public static DataTable datTabela;

        public static void AbrirConexao()
        {
            try
            {
                Conexao = new MySqlConnection("server=localhost;port=3306;uid=root;pwd=9090");
                Conexao.Open();
            } catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void FecharConexao()
        {
            try
            {
                Conexao.Close();
            } catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void CriarBanco()
        {
            try
            {
                AbrirConexao();
                Comando = new MySqlCommand("CREATE DATABASE IF NOT EXISTS vendas; USE vendas", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS cidades " + "(id integer auto_increment primary key, " + "nome varchar(40), " + "uf char(02))", Conexao);
                Comando.ExecuteNonQuery();;

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS marcas " + "(id integer auto_increment primary key, " + "marca varchar(20))", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS categorias " + "(id integer auto_increment primary key, " + "categoria varchar(20))", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS clientes " + "(id integer auto_increment primary key, nome varchar(40), idCidade integer, dataNasc date, renda decimal(10,2), cpf char(14), foto varchar(100), venda boolean)", Conexao);
                Comando.ExecuteNonQuery();
                FecharConexao();

            } catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
