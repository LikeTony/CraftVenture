﻿using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GerenciadorDeEstoque.DAO
{
    class DAO
    {
        private Conexao conexao;
        private MySqlConnection con;
        MySqlCommand cmd;
        private MySqlDataReader dr;

        public DAO()
        {
        }

        #region Usuario
        public void IDU(String email, String nome, String senha)
        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();

            String query = "INSERT INTO usuario (email, nome, senha) VALUES";
            query += "(?email, ?nome, ?senha)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?email", email);
                cmd.Parameters.AddWithValue("?nome", nome);
                cmd.Parameters.AddWithValue("?senha", senha);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }

        public void ADU(String email, String nome, String senha, Int32 itemid)
        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();
            String query = "UPDATE estoque SET email = ?email, senha = ?senha, nome = ?nome";
            query += " WHERE itemid = ?itemid";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?nome", nome);
                cmd.Parameters.AddWithValue("?email", email);
                cmd.Parameters.AddWithValue("?senha", senha);
                cmd.Parameters.AddWithValue("?itemid", itemid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }

        }

        public void RDU(String email, String nome, String senha, Int32 itemid)
        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();
            String query = "DELETE FROM estoque";
            query += "WHERE nome = ?nome AND itemid = ?itemid";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?nome", nome);
                cmd.Parameters.AddWithValue("?email", email);
                cmd.Parameters.AddWithValue("?senha", senha);
                cmd.Parameters.AddWithValue("?itemid", itemid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }

        public bool BDU(String nome, string senha)
        {
            conexaoUso busca = new conexaoUso();
            cmd = new MySqlCommand();

            busca.Open();
            cmd.CommandText = "select senha, nome WHERE nome ='" + nome + "' AND senha ='" + senha + "'";
            
            if (dr.Read())
            {
                busca.Close();
                return true;
            }
            else
            {
                busca.Close();
                return false;
            }
            
        }

        #endregion

        #region Cliente
        public void IDC(String email, String nome)
        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();

            String query = "INSERT INTO cliente (email, nome) VALUES";
            query += "(?email, ?nome)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?email", email);
                cmd.Parameters.AddWithValue("?nome", nome);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }

        public void ADC(String email, String nome, Int32 itemid)
        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();
            String query = "UPDATE estoque SET email = ?email, senha = ?senha, nome = ?nome";
            query += " WHERE itemid = ?itemid";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?nome", nome);
                cmd.Parameters.AddWithValue("?email", email);
                cmd.Parameters.AddWithValue("?itemid", itemid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }

        }

        public void RDC(String nome, Int32 itemid)
        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();
            String query = "DELETE FROM estoque";
            query += "WHERE nome = ?nome AND itemid = ?itemid";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?nome", nome);
                cmd.Parameters.AddWithValue("?itemid", itemid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }

        }

        #endregion

        #region Venda

        public void IDV(String nome, Int32 quantidade, String anotacao, Double valorTotal, String nomeCliente, String telefone, Int32 formaPagamento, Int32 CodCliente)
        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();

            String query = "INSERT INTO pedido (nome, quantidade, anotacao, valorTotal, nomeCliente, telefone, formaPagamento, CodCliente) VALUES";
            query += "(?nome, ?quantidade, ?anotacao, ?valorTotal, ?nomeCliente, ?telefone, ?formaPagamento, ?CodCliente)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?quantidade", quantidade);
                cmd.Parameters.AddWithValue("?nome", nome);
                cmd.Parameters.AddWithValue("?anotacao", anotacao);
                cmd.Parameters.AddWithValue("?valorTotal", valorTotal);
                cmd.Parameters.AddWithValue("?nomeCliente", nomeCliente);
                cmd.Parameters.AddWithValue("?telefone", telefone);
                cmd.Parameters.AddWithValue("?formaPagamento", formaPagamento);
                cmd.Parameters.AddWithValue("?CodCliente", CodCliente);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        
        public void ADV(String nome, Int32 quantidade, String anotacao, Double valorTotal, String nomeCliente, String telefone, Int32 formaPagamento, Int32 CodCliente, Int32 itemid)
        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();
            String query = "UPDATE estoque SET quantidade = ?quantidade, anotacao = ?anotacao, nome = ?nome, valorTotal = ?valorTotal, nomeCliente = ?nomeCliente, " +
                "                              telefone = ?telefone, formaPagamento = ?formaPagamento, CodCliente = ?CodCliente";
            query += " WHERE itemid = ?itemid, quantidade = ?quantidade, anotacao = ?anotacao, nome = ?nome, valorTotal = ?valorTotal, nomeCliente = ?nomeCliente, " +
                "                              telefone = ?telefone, formaPagamento = ?formaPagamento, CodCliente = ?CodCliente";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?itemid", itemid);
                cmd.Parameters.AddWithValue("?quantidade", quantidade);
                cmd.Parameters.AddWithValue("?nome", nome);
                cmd.Parameters.AddWithValue("?anotacao", anotacao);
                cmd.Parameters.AddWithValue("?valorTotal", valorTotal);
                cmd.Parameters.AddWithValue("?nomeCliente", nomeCliente);
                cmd.Parameters.AddWithValue("?telefone", telefone);
                cmd.Parameters.AddWithValue("?formaPagamento", formaPagamento);
                cmd.Parameters.AddWithValue("?CodCliente", CodCliente);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }

        }

        
        public void RDV(String nome, Int32 quantidade, String anotacao, Double valorTotal, String nomeCliente, String telefone, Int32 formaPagamento, Int32 CodCliente, Int32 itemid)
        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();
            String query = "DELETE FROM estoque";
            query += "WHERE itemid = ?itemid, quantidade = ?quantidade, anotacao = ?anotacao, nome = ?nome, valorTotal = ?valorTotal, nomeCliente = ?nomeCliente, " +
                "                              telefone = ?telefone, formaPagamento = ?formaPagamento, CodCliente = ?CodCliente";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?itemid", itemid);
                cmd.Parameters.AddWithValue("?quantidade", quantidade);
                cmd.Parameters.AddWithValue("?nome", nome);
                cmd.Parameters.AddWithValue("?anotacao", anotacao);
                cmd.Parameters.AddWithValue("?valorTotal", valorTotal);
                cmd.Parameters.AddWithValue("?nomeCliente", nomeCliente);
                cmd.Parameters.AddWithValue("?telefone", telefone);
                cmd.Parameters.AddWithValue("?formaPagamento", formaPagamento);
                cmd.Parameters.AddWithValue("?CodCliente", CodCliente);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }

        }

        #endregion

        #region Produto

        public void IDP(Double valor, Int32 quantidade, String nome, String materialUsado, String tipo)
        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();

            String query = "INSERT INTO pedido (valor, quantidade, nome, materialUsado, tipo) VALUES";
            query += "(?valor, ?quantidade, ?nome, ?materialUsado, ?tipo)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?quantidade", quantidade);
                cmd.Parameters.AddWithValue("?nome", nome);
                cmd.Parameters.AddWithValue("?materialUsado", materialUsado);
                cmd.Parameters.AddWithValue("?valor", valor);
                cmd.Parameters.AddWithValue("?tipo", tipo);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }

        public void ADP(Double valor, Int32 quantidade, String nome, String materialUsado, String tipo, Int32 itemid)
        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();
            String query = "UPDATE estoque SET quantidade = ?quantidade, tipo = ?tipo, nome = ?nome, valor = ?valor, materialUsado = ?materialUsado";
            query += " WHERE itemid = ?itemid, quantidade = ?quantidade, tipo = ?tipo, nome = ?nome, valor = ?valor, materialUsado = ?materialUsado";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?itemid", itemid);
                cmd.Parameters.AddWithValue("?quantidade", quantidade);
                cmd.Parameters.AddWithValue("?nome", nome);
                cmd.Parameters.AddWithValue("?materialUsado", materialUsado);
                cmd.Parameters.AddWithValue("?valor", valor);
                cmd.Parameters.AddWithValue("?tipo", tipo);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }

        }


        public void RDP(Double valor, Int32 quantidade, String nome, String materialUsado, String tipo, Int32 itemid)
        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();
            String query = "DELETE estoque SET quantidade = ?quantidade, tipo = ?tipo, nome = ?nome, valor = ?valor, materialUsado = ?materialUsado";
            query += " WHERE itemid = ?itemid, quantidade = ?quantidade, tipo = ?tipo, nome = ?nome, valor = ?valor, materialUsado = ?materialUsado";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?itemid", itemid);
                cmd.Parameters.AddWithValue("?quantidade", quantidade);
                cmd.Parameters.AddWithValue("?nome", nome);
                cmd.Parameters.AddWithValue("?materialUsado", materialUsado);
                cmd.Parameters.AddWithValue("?valor", valor);
                cmd.Parameters.AddWithValue("?tipo", tipo);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }

        }

        #endregion

    }
}
