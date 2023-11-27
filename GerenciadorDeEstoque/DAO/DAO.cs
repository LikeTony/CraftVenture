﻿using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GerenciadorDeEstoque.Apresentação.Menu;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
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

        private long idLastInsert = -1;

        public DAO()
        {
        }

        #region GetLastId

        public long getLastId()
        {
            if (idLastInsert != -1)
            {
                long lastId = idLastInsert;

                idLastInsert = -1;

                return lastId;
            }
            else
            {
                throw new ArgumentNullException("O valor não foi encontrado! Algo deu errado com o lastInsertid");
            }
        }

        #endregion

        #region Usuario
        public void IDU(String email, String senha, String nome)
        {
            conexao = new Conexao();
            con = new MySqlConnection();
            
            con.ConnectionString = conexao.getConnectionString();

            String query = "INSERT INTO usuario (email, nome, senha) VALUES";
            query += "(?email, ?nome, ?senha)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?email", email);
                cmd.Parameters.AddWithValue("?senha", senha);
                cmd.Parameters.AddWithValue("?nome", nome);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }

        public void ADU(String email, String senha, String nome, Int64 itemid)
        {
            conexao = new Conexao();
            con = new MySqlConnection();
            
            con.ConnectionString = conexao.getConnectionString();
            String query = "UPDATE usuario SET email = ?email, senha = ?senha, nome = ?nome";
            query += " WHERE itemid = ?itemid";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?email", email);
                cmd.Parameters.AddWithValue("?senha", senha);
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

        public void RDU(String email, String senha, String nome, Int64 itemid)
        {
            conexao = new Conexao();
            con = new MySqlConnection();
            
            con.ConnectionString = conexao.getConnectionString();
            String query = "DELETE FROM usuario";
            query += "WHERE nome = ?nome, email = ?email, senha = ?senha, itemid = ?itemid";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?email", email);
                cmd.Parameters.AddWithValue("?senha", senha);
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

        public int BDU(String nome, String senha)
        {
            try
            {
                conexao = new Conexao();
                con = new MySqlConnection();

                con.ConnectionString = conexao.getConnectionString();

                con.Open();

                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = con;

                cmd.CommandText = "SELECT id FROM usuario WHERE nome LIKE @nome OR senha LIKE @senha";

                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@senha", senha);


                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int id = Convert.ToInt32(reader.GetString(0));
                    con.Close();

                    return id;
                }
                else
                {
                    con.Close();

                    return -1;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("erro" + ex.Message + "ocorreu: " + ex.Message, "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro" + ex.Message + "ocorreu: " + ex.Message, "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally { con.Close(); }

        }

        #endregion

        #region Cliente
        public void IDC(Int64 telefone, Int64 numero, String email, String nome, String cep, String rua, String bairro, String estado, String complemento)
        {
            conexao = new Conexao();
            con = new MySqlConnection();
            
            con.ConnectionString = conexao.getConnectionString();

            String query = "INSERT INTO cliente (telefone, numero, email, nome, cep, rua, bairro, estado, complemento) VALUES";
            query += "(?telefone, ?numero, ?email, ?nome, ?cep, ?rua, ?bairro, ?estado, ?complemento)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?telefone", telefone);
                cmd.Parameters.AddWithValue("?numero", numero);
                cmd.Parameters.AddWithValue("?email", email);
                cmd.Parameters.AddWithValue("?nome", nome);
                cmd.Parameters.AddWithValue("?cep", cep);
                cmd.Parameters.AddWithValue("?rua", rua);
                cmd.Parameters.AddWithValue("?bairro", bairro);
                cmd.Parameters.AddWithValue("?estado", estado);
                cmd.Parameters.AddWithValue("?complemento", complemento);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }

        public void ADC(Int64 telefone, Int64 numero, String email, String nome, String cep, String rua, String bairro, String estado, String complemento, Int64 itemid)
        {
            conexao = new Conexao();
            con = new MySqlConnection();
            
            con.ConnectionString = conexao.getConnectionString();
            String query = "UPDATE estoque SET telefone = ?telefone, numero = ?numero, email = ?email, nome = ?nome, cep = ?cep, rua = rua?, bairro = ?bairro, estado = ?estado, complemento = ?complemento";
            query += " WHERE itemid = ?itemid";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?telefone", telefone);
                cmd.Parameters.AddWithValue("?numero", numero);
                cmd.Parameters.AddWithValue("?email", email);
                cmd.Parameters.AddWithValue("?nome", nome);
                cmd.Parameters.AddWithValue("?cep", cep);
                cmd.Parameters.AddWithValue("?rua", rua);
                cmd.Parameters.AddWithValue("?bairro", bairro);
                cmd.Parameters.AddWithValue("?estado", estado);
                cmd.Parameters.AddWithValue("?complemento", complemento);
                cmd.Parameters.AddWithValue("?itemid", itemid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }

        }

        public void RDC(Int64 telefone, Int64 numero, String email, String nome, String cep, String rua, String bairro, String estado, String complemento, Int64 itemid)
        {
            conexao = new Conexao();
            con = new MySqlConnection();
            
            con.ConnectionString = conexao.getConnectionString();
            String query = "DELETE FROM estoque";
            query += "WHERE telefone = ?telefone, numero = ?numero, email = ?email, nome = ?nome, cep = ?cep, rua = rua?, bairro = ?bairro, estado = ?estado, complemento = ?complemento, itemid = ?itemid";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?telefone", telefone);
                cmd.Parameters.AddWithValue("?numero", numero);
                cmd.Parameters.AddWithValue("?email", email);
                cmd.Parameters.AddWithValue("?nome", nome);
                cmd.Parameters.AddWithValue("?cep", cep);
                cmd.Parameters.AddWithValue("?rua", rua);
                cmd.Parameters.AddWithValue("?bairro", bairro);
                cmd.Parameters.AddWithValue("?estado", estado);
                cmd.Parameters.AddWithValue("?complemento", complemento);
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

        public void IDV(String nome, Int64 quantidade, String anotacao, Double valorTotal, String nomeCliente, String telefone, Int64 formaPagamento, Int64 CodCliente)
        {
            conexao = new Conexao();
            con = new MySqlConnection();
            
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

        public void ADV(String nome, Int64 quantidade, String anotacao, Double valorTotal, String nomeCliente, String telefone, Int64 formaPagamento, Int64 CodCliente, Int64 itemid)
        {
            conexao = new Conexao();
            con = new MySqlConnection();
            
            con.ConnectionString = conexao.getConnectionString();
            String query = "UPDATE estoque SET quantidade = ?quantidade, anotacao = ?anotacao, nome = ?nome, valorTotal = ?valorTotal, nomeCliente = ?nomeCliente, " +
                "                              telefone = ?telefone, formaPagamento = ?formaPagamento, CodCliente = ?CodCliente";
            query += " WHERE itemid = ?itemid";
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


        public void RDV(String nome, Int64 quantidade, String anotacao, Double valorTotal, String nomeCliente, String telefone, Int64 formaPagamento, Int64 CodCliente, Int64 itemid)
        {
            conexao = new Conexao();
            con = new MySqlConnection();
            
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

        public void IDP(Double valor, Int64 quantidade, String nome, String materialUsado, String tipo)
        {
            conexao = new Conexao();
            con = new MySqlConnection();
            
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

        public void ADP(Double valor, Int64 quantidade, String nome, String materialUsado, String tipo, Int64 itemid)
        {
            conexao = new Conexao();
            con = new MySqlConnection();
            
            con.ConnectionString = conexao.getConnectionString();
            String query = "UPDATE estoque SET quantidade = ?quantidade, tipo = ?tipo, nome = ?nome, valor = ?valor, materialUsado = ?materialUsado";
            query += " WHERE itemid = ?itemid";
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


        public void RDP(Double valor, Int64 quantidade, String nome, String materialUsado, String tipo, Int64 itemid)
        {
            conexao = new Conexao();
            con = new MySqlConnection();
            
            con.ConnectionString = conexao.getConnectionString();
            String query = "DELETE FROM estoque";
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

        #region Vende

        public void IDVENDE(Int64 idvenda, Int64 idproduto)
        {
            conexao = new Conexao();
            con = new MySqlConnection();
            
            con.ConnectionString = conexao.getConnectionString();

            String query = "INSERT INTO pedido (idvenda, idproduto) VALUES";
            query += "(?idvenda, ?idproduto)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?idvenda", idvenda);
                cmd.Parameters.AddWithValue("?idproduto", idproduto);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }

        public void ADVENDE(Int64 idvenda, Int64 idproduto, Int64 itemid)
        {
            conexao = new Conexao();
            con = new MySqlConnection();
            
            con.ConnectionString = conexao.getConnectionString();
            String query = "UPDATE vende " +
                "INNER JOIN venda ON vende.idvenda = venda.id" +
        "INNER JOIN produto ON vende.idproduto = produto.id" +
                " SET idvenda = ?idvenda, idproduto = ?idproduto" +
                " WHERE itemid =" + itemid;
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?idvenda", idvenda);
                cmd.Parameters.AddWithValue("?idproduto", idproduto);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }

        }

        public void RDVENDE(Int64 idvenda, Int64 idproduto, Int64 itemid)
        {
            conexao = new Conexao();
            con = new MySqlConnection();
            
            con.ConnectionString = conexao.getConnectionString();
            String query = "DELETE FROM estoque";
            query += " WHERE itemid = ?itemid, idvenda = ?idvenda, idproduto = ?idproduto";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?itemid", itemid);
                cmd.Parameters.AddWithValue("?idvenda", idvenda);
                cmd.Parameters.AddWithValue("?idproduto", idproduto);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }

        }

        #endregion

        #region Tipo Material

        public void IDTIPO(String nome)
        {
            conexao = new Conexao();
            con = new MySqlConnection();

            con.ConnectionString = conexao.getConnectionString();

            String query = "INSERT INTO tipoMaterial (nome) VALUES";
            query += "(?nome)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?nome", nome);
                cmd.ExecuteNonQuery();
                
                idLastInsert = cmd.LastInsertedId;

                cmd.Dispose();

                
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                
            }
            finally
            {
                con.Close();
            }
        }

        public void ADTIPO(String nome, Int64 itemid)
        {
            conexao = new Conexao();
            con = new MySqlConnection();
            
            con.ConnectionString = conexao.getConnectionString();
            String query = "UPDATE tipoMaterial SET nome = ?nome";
            query += " WHERE itemid =" + itemid;
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?nome", nome);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }

        }

        public void RDTIPO(String nome, Int64 itemid)
        {
            conexao = new Conexao();
            con = new MySqlConnection();
            
            con.ConnectionString = conexao.getConnectionString();
            String query = "DELETE tipoMaterial, nome FROM tipoMaterial";
            query += " WHERE itemid =" + itemid;
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?itemid", itemid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }

        }

        public static DataTable GetTipoMaterial()
        {
            Conexao con = new Conexao();
            var dt = new DataTable();

            var sql = "SELECT tipoMaterial, nome, itemid FROM tipoMaterial" +
                " ORDER BY itemid ASC";

            try
            {
                using (var cn = new MySqlConnection(con.getConnectionString()))
                {
                    cn.Open();

                    using (var da = new MySqlDataAdapter(sql, cn))
                    {
                        da.Fill(dt);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        #endregion

        #region Material

        public void IDM(Int64 idTipoMaterial, String nome, Double valor)
        {
            conexao = new Conexao();
            con = new MySqlConnection();
            
            con.ConnectionString = conexao.getConnectionString();

            String query = "INSERT INTO material (idTipoMaterial, nome, valor) VALUES";
            query += "(?idTipoMaterial, ?nome, ?valor)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?idTipoMaterial", idTipoMaterial);
                cmd.Parameters.AddWithValue("?nome", nome);
                cmd.Parameters.AddWithValue("?valor", valor);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }

        public void ADM(Int64 idTipoMaterial, String nome, Double valor, Int64 itemid)
        {
            conexao = new Conexao();
            con = new MySqlConnection();
            
            con.ConnectionString = conexao.getConnectionString();
            String query = "UPDATE material " +
                     "INNER JOIN tipoMaterial ON material.idTipoMaterial = tipoMaterial.id" +
                     "SET nome = ?nome, valor = ?valor, idTipoMaterial = ?idTipoMaterial";
            query += " WHERE itemid =" + itemid;
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?idTipoMaterial", idTipoMaterial);
                cmd.Parameters.AddWithValue("?nome", nome);
                cmd.Parameters.AddWithValue("?valor", valor);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }

        }

        public void RDM(Int64 itemid)
        {
            conexao = new Conexao();
            con = new MySqlConnection();
            con.ConnectionString = conexao.getConnectionString();
            String query = "DELETE material, nome, valor, idTipoMaterial FROM material" +
                " INNER JOIN tipoMaterial ON material.idTipoMaterial = tipoMaterial.id" +
                " WHERE itemid = " + itemid;
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?itemid", itemid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }

        }

        public static DataTable GetMaterial()
        {
            Conexao con = new Conexao();
            var dt = new DataTable();

            var sql = "SELECT material, nome, valor, idTipoMaterial, itemid FROM material" +
                "INNER JOIN tipoMaterial ON material.idTipoMaterial = tipoMaterial.id" +
                " ORDER BY itemid ASC";

            try
            {
                using (var cn = new MySqlConnection(con.getConnectionString()))
                {
                    cn.Open();

                    using (var da = new MySqlDataAdapter(sql, cn))
                    {
                        da.Fill(dt);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        #endregion

        #region Material Produto

        public void IDMPRODUTO(Int64 idmaterial, Int64 idproduto)
        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();

            String query = "INSERT INTO pedido (idmaterial, idproduto) VALUES";
            query += "(?idmaterial, ?idproduto)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?idmaterial", idmaterial);
                cmd.Parameters.AddWithValue("?idproduto", idproduto);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }

        public void ADMPRODUTO(Int64 idmaterial, Int64 idproduto, Int64 itemid)

        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();
            String query = "UPDATE MaterialProduto " +
                     "INNER JOIN material ON MaterialProduto.idmaterial = material.id" +
                     "INNER JOIN produto ON MaterialProduto.idproduto = produto.id" +
                     "SET material.idmaterial = ?idmaterial, produto.idproduto = ?idproduto";
            query += " WHERE itemid =" + itemid;
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?idmaterial", idmaterial);
                cmd.Parameters.AddWithValue("?idproduto", idproduto);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }

        }

        public void RDMPRODUTO(Int64 itemid)
        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();
            String query = "DELETE MaterialProduto, idproduto, idmaterial FROM MaterialProduto" +
                " INNER JOIN material ON MaterialProduto.idmaterial = material.id" +
                " INNER JOIN produto ON MaterialProduto.idproduto = produto.id" +
                " WHERE itemid = " + itemid;
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?itemid", itemid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }

        }

        public static DataTable GetMaterialProduto()
        {
            Conexao con = new Conexao();
            var dt = new DataTable();

            var sql = "SELECT MaterialProduto.idmaterial, MaterialProduto.idproduto, itemid FROM MaterialProduto" +
                      "INNER JOIN material ON MaterialProduto.idmaterial = material.id" +
                      "INNER JOIN produto ON MaterialProduto.idproduto = produto.id" +
                      " ORDER BY itemid ASC";

            try
            {
                using (var cn = new MySqlConnection(con.getConnectionString()))
                {
                    cn.Open();

                    using (var da = new MySqlDataAdapter(sql, cn))
                    {
                        da.Fill(dt);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        #endregion

        #region Renda

        public void IDR(Int64 idTipoMaterial, String tamanho, Double metragem)
        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();

            String query = "INSERT INTO renda (idTipoMaterial, tamanho, metragem) VALUES";
            query += "(?idTipoMaterial, ?tamanho, ?metragem)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?idTipoMaterial", idTipoMaterial);
                cmd.Parameters.AddWithValue("?tamanho", tamanho);
                cmd.Parameters.AddWithValue("?metragem", metragem);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void ADR(String tamanho, Double metragem, Int64 idTipoMaterial)
        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();
            String query = "UPDATE renda " +
                     "INNER JOIN material ON renda.idTipoMaterial = material.idTipoMaterial" +
                     "SET tamanho = ?tamanho, metragem = ?metragem";
            query += " WHERE renda.idTipoMaterial =" + idTipoMaterial;
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?tamamnho", tamanho);
                cmd.Parameters.AddWithValue("?metragem", metragem);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        public void RDR(Int64 idTipoMaterial)
        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();
            String query = "DELETE renda, tamanho, metragem, idTipoMaterial FROM renda" +
                " INNER JOIN material ON renda.idTipoMaterial = material.idTipoMaterial" +
                " INNER JOIN tipoMaterial ON renda.idTipoMaterial = tipoMaterial.id" +
                " WHERE renda.idTipoMaterial = " + idTipoMaterial;
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?idTipoMaterial", idTipoMaterial);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }

        }

        public static DataTable GetRenda()
        {
            Conexao con = new Conexao();
            var dt = new DataTable();

            var sql = "SELECT renda.idTipoMaterial, tamanho, metragem FROM renda" +
                "INNER JOIN material ON renda.idTipoMaterial = material.idTipoMaterial" +
                " ORDER BY idTipoMaterial ASC";

            try
            {
                using (var cn = new MySqlConnection(con.getConnectionString()))
                {
                    cn.Open();

                    using (var da = new MySqlDataAdapter(sql, cn))
                    {
                        da.Fill(dt);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        #endregion

        #region Canudo

        public void IDCANUDO(Int64 idtipomaterial, Int64 quantidade, String cor)

        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();

            String query = "INSERT INTO canudo (idTipoMaterial, quantidade, cor) VALUES";
            query += "(?idTipoMaterial, ?quantidade, ?cor)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?idTipoMaterial", idtipomaterial);
                cmd.Parameters.AddWithValue("?quantidade", quantidade);
                cmd.Parameters.AddWithValue("?cor", cor);
                cmd.ExecuteNonQuery();

                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }

        public void ADCANUDO(Int64 quantidade, String cor, Int64 idTipoMaterial)
        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();

            String query = "UPDATE canudo " +
                     "INNER JOIN material ON canudo.idTipoMaterial = material.idTipoMaterial" +
                     "SET quantidade = ?quantidade, cor = ?cor";
            query += " WHERE canudo.idTipoMaterial =" + idTipoMaterial;
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?quantidade", quantidade);
                cmd.Parameters.AddWithValue("?cor", cor);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        public void RDCANUDO(Int64 idTipoMaterial)

        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();
            String query = "DELETE canudo, quantidade, cor, tipoMaterial FROM canudo" +
                " INNER JOIN material ON canudo.idTipoMaterial = material.idTipoMaterial" +
                " INNER JOIN tipoMaterial ON canudo.idTipoMaterial = tipoMaterial.id" +
                " WHERE canudo.idTipoMaterial =" + idTipoMaterial;
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?idTipoMaterial", idTipoMaterial);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }

        }

        public static DataTable GetCanudo()
        {
            Conexao con = new Conexao();
            var dt = new DataTable();

            var sql = "SELECT canudo.idTipoMaterial, cor, quantidade FROM canudo " +
                "INNER JOIN material ON canudo.idTipoMaterial = material.idTipoMaterial" +
                " ORDER BY idTipoMaterial ASC";

            try
            {
                using (var cn = new MySqlConnection(con.getConnectionString()))
                {
                    cn.Open();

                    using (var da = new MySqlDataAdapter(sql, cn))
                    {
                        da.Fill(dt);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        #endregion

        #region Fita

        public void IDF(Int64 idtipomaterial, Int64 numero, String tipo, String marca, String numeroCor, Double metragem)
        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();

            String query = "INSERT INTO fita (idtipomaterial, numero, tipo, marca, numeroCor, metragem) VALUES";
            query += "(?idtipomaterial, ?numero, ?tipo, ?marca, ?numeroCor, ?metragem)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?idtipomaterial", idtipomaterial);
                cmd.Parameters.AddWithValue("?numero", numero);
                cmd.Parameters.AddWithValue("?tipo", tipo);
                cmd.Parameters.AddWithValue("?marca", marca);
                cmd.Parameters.AddWithValue("?numeroCor", numeroCor);
                cmd.Parameters.AddWithValue("?metragem", metragem);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }

        public void ADF(Int64 numero, String tipo, String marca, String numeroCor, Double metragem, Int64 idTipoMaterial, Double valor)
        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();

            String query = "UPDATE fita " +
                "INNER JOIN material ON fita.idTipoMaterial = material.idTipoMaterial" +
                " SET numero = ?numero, tipo = ?tipo, marca = ?marca, numeroCor = ?numeroCor, metragem = ?metragem, material.valor = ?valor" +
                " WHERE fita.idTipoMaterial =" + idTipoMaterial;

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("?idTipoMaterial", idTipoMaterial);

                cmd.Parameters.AddWithValue("?numero", numero);
                cmd.Parameters.AddWithValue("?tipo", tipo);
                cmd.Parameters.AddWithValue("?marca", marca);
                cmd.Parameters.AddWithValue("?numeroCor", numeroCor);
                cmd.Parameters.AddWithValue("?metragem", metragem);
                cmd.Parameters.AddWithValue("?valor", valor);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }


        public void RDF(Int64 idTipoMatreial)

        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();
          
            String query = "DELETE fita, material, tipoMaterial FROM fita" +
               " INNER JOIN material ON fita.idTipoMaterial = material.idTipoMaterial" +
               " INNER JOIN tipoMaterial ON fita.idTipoMaterial = tipoMaterial.id" +
               " WHERE fita.idTipoMaterial =" + idTipoMaterial;

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("?idTipoMaterial", idTipoMaterial);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }

        }

        public static DataTable GetFita()
        {
            Conexao con = new Conexao();
            var dt = new DataTable();

            var sql = "SELECT fita.idTipoMaterial, tipo, numero, metragem, marca, numeroCor, material.valor " +
                "FROM fita " +

                "INNER JOIN material ON fita.idTipoMaterial = material.idTipoMaterial" +
                " ORDER BY idTipoMaterial ASC";

            try
            {
                using (var cn = new MySqlConnection(con.getConnectionString()))
                {
                    cn.Open();

                    using (var da = new MySqlDataAdapter(sql, cn))
                    {
                        da.Fill(dt);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        public static DataTable GetFita(String tipo)
        {
            var sql = "SELECT fita.idTipoMaterial, tipo, numero, metragem, marca, numeroCor, material.valor " +
                "FROM fita " +
                "INNER JOIN material ON fita.idTipoMaterial = material.idTipoMaterial" +
                " WHERE tipo LIKE '%" + tipo + "%' OR numero LIKE '%"+ tipo +"%'";

            FitaVO fita = new FitaVO();
            DataTable dt = new DataTable();
            Conexao conexao = new Conexao();

            try
            {
                using (var cn = new MySqlConnection(conexao.getConnectionString()))
                {
                    cn.Open();

                    using (var da = new MySqlDataAdapter(sql, cn))
                    {
                        da.Fill(dt);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        #endregion

        #region Papel

        public void IDPAPEL(Int64 idTipoMaterial, String tipo, Int32 gramatura, String cor, String tamanho)
        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();

            String query = "INSERT INTO papel (idTipoMaterial, tipo, gramatura, cor, tamanho) VALUES";
            query += "(?idTipoMaterial, ?tipo, ?gramatura, ?cor, ?tamanho)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?idTipoMaterial", idTipoMaterial);
                cmd.Parameters.AddWithValue("?tipo", tipo);
                cmd.Parameters.AddWithValue("?gramatura", gramatura);
                cmd.Parameters.AddWithValue("?cor", cor);
                cmd.Parameters.AddWithValue("?tamanho", tamanho);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }

        public void ADPAPEL(String tipo, Int32 gramatura, String cor, String tamanho, Double valor, Int64 idTipoMaterial)
        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();

            String query = "UPDATE papel " +
                "INNER JOIN material ON papel.idTipoMaterial = material.idTipoMaterial" +
                " SET tipo = ?tipo, gramatura = ?gramatura, cor = ?cor, tamanho = ?tamanho, material.valor = ?valor" +
                " WHERE papel.idTipoMaterial =" + idTipoMaterial;
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("?tipo", tipo);
                cmd.Parameters.AddWithValue("?gramatura", gramatura);
                cmd.Parameters.AddWithValue("?cor", cor);
                cmd.Parameters.AddWithValue("?tamanho", tamanho);
                cmd.Parameters.AddWithValue("?valor", valor);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        public void RDPAPEL(Int64 idTipoMaterial)
        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();

            String query = "DELETE papel, material, tipoMaterial FROM papel" +
                " INNER JOIN material ON papel.idTipoMaterial = material.idTipoMaterial" +
                " INNER JOIN tipoMaterial ON papel.idTipoMaterial = tipoMaterial.id" +
                " WHERE papel.idTipoMaterial ="+idTipoMaterial;
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?idTipoMaterial", idTipoMaterial);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }

        }

        public static DataTable GetPapel()
        {
            Conexao con = new Conexao();
            var dt = new DataTable();

            var sql = "SELECT papel.idTipoMaterial, tipo, gramatura, cor, tamanho, material.valor " +
                "FROM papel " +
                "INNER JOIN material ON papel.idTipoMaterial = material.idTipoMaterial" +
                " ORDER BY idTipoMaterial ASC";

            try
            {
                using (var cn = new MySqlConnection(con.getConnectionString()))
                {
                    cn.Open();

                    using (var da = new MySqlDataAdapter(sql, cn))
                    {
                        da.Fill(dt);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        public static DataTable GetPapel(String tipo)
        {
            var sql = "SELECT papel.idTipoMaterial, tipo, gramatura, cor, tamanho, material.valor " +
                "FROM papel " +
                "INNER JOIN material ON papel.idTipoMaterial = material.idTipoMaterial" +
                " WHERE tipo LIKE '%"+tipo+"%'";

            PapelVO papel = new PapelVO();
            DataTable dt = new DataTable();
            Conexao conexao = new Conexao();
            try
            {
                using (var cn = new MySqlConnection(conexao.getConnectionString()))
                {
                    cn.Open();

                    using (var da = new MySqlDataAdapter(sql, cn))
                    {
                        da.Fill(dt);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        #endregion

        #region Tecido

        public void IDTECIDO(Int64 idTipoMaterial, String tipo, String tipoEstampa, Double metragem)
        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();

            String query = "INSERT INTO tecido (idTipoMaterial, tipo, tipoEstampa, metragem) VALUES";
            query += "(?idTipoMaterial, ?tipo, ?tipoEstampa, ?metragem)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?idTipoMaterial", idTipoMaterial);
                cmd.Parameters.AddWithValue("?tipo", tipo);
                cmd.Parameters.AddWithValue("?tipoEstampa", tipoEstampa);
                cmd.Parameters.AddWithValue("?metragem", metragem);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }

        public void ADTECIDO(String tipo, String tipoEstampa, Double metragem, Int64 itemidTipoMatreial)
        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();
            String query = "UPDATE tecido " +
                     "INNER JOIN material ON tecido.idTipoMaterial = material.idTipoMaterial" +
                     "SET tipo = ?tipo, tipoEstampa = ?tipoEstampa, metragem = ?metragem";
            query += " WHERE tecido.idTipoMaterial =" + itemidTipoMatreial;
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?tipo", tipo);
                cmd.Parameters.AddWithValue("?tipoEstampa", tipoEstampa);
                cmd.Parameters.AddWithValue("?metragem", metragem);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        public void RDTECIDO(Int64 itemidTipoMatreial)
        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();
            String query = "DELETE tecido, tipo, tipoEstampa, metragem idTipoMaterial FROM tecido" +
                " INNER JOIN material ON tecido.idTipoMaterial = material.idTipoMaterial" +
                " INNER JOIN tipoMaterial ON tecido.idTipoMaterial = tipoMaterial.id" +
                " WHERE tecido.idTipoMaterial =" + itemidTipoMatreial;
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?itemidTipoMaterial", itemidTipoMatreial);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }

        }

        public static DataTable GetTecido()
        {
            Conexao con = new Conexao();
            var dt = new DataTable();

            var sql = "SELECT tecido.idTipoMaterial, tipo, tipoEspessura, metragem FROM tecido " +
                "INNER JOIN material ON tecido.idTipoMaterial = material.idTipoMaterial" +
                " ORDER BY idTipoMaterial ASC";

            try
            {
                using (var cn = new MySqlConnection(con.getConnectionString()))
                {
                    cn.Open();

                    using (var da = new MySqlDataAdapter(sql, cn))
                    {
                        da.Fill(dt);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        public static DataTable GetTecido(String tipo)
        {
            var sql = "SELECT tecido.idTipoMaterial, tipoEspessura, metragem FROM tecido " +
               "INNER JOIN material ON fita.idTipoMaterial = material.idTipoMaterial" +
               " WHERE tipo LIKE '%" + tipo + "%'";

            PapelVO papel = new PapelVO();
            DataTable dt = new DataTable();
            Conexao conexao = new Conexao();
            try
            {
                using (var cn = new MySqlConnection(conexao.getConnectionString()))
                {
                    cn.Open();

                    using (var da = new MySqlDataAdapter(sql, cn))
                    {
                        da.Fill(dt);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        #endregion

        #region Acetato

        public void IDE(Int64 idTipoMaterial, Double metragemAltura, Double metragemComprimento, Double espessura)
        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();

            String query = "INSERT INTO acetato (idTipoMaterial, metragemAltura, metragemComprimento, espessura) VALUES";
            query += "(?idTipoMaterial, ?metragemAltura, ?metragemComprimento, ?espessura)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?idTipoMaterial", idTipoMaterial);
                cmd.Parameters.AddWithValue("?metragemAltura", metragemAltura);
                cmd.Parameters.AddWithValue("?metragemComprimento", metragemComprimento);
                cmd.Parameters.AddWithValue("?espessura", espessura);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }

        public void ADE(Double metragemAltura, Double metragemComprimento, Double espessura, Int64 idTipoMaterial)
        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();

            String query = "UPDATE acetato SET  ?metragemAltura, ?metragemComprimento,, espessura = ?espessura";
            query += " WHERE idTipoMaterial = ?idTipoMaterial";

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("?metragemAltura", metragemAltura);
                cmd.Parameters.AddWithValue("?metragemComprimento", metragemComprimento);
                cmd.Parameters.AddWithValue("?idTipoMaterial", idTipoMaterial);

                cmd.Parameters.AddWithValue("?espessura", espessura);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        public void RDE(Int64 itemidTipoMatreial)
        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();

            String query = "DELETE acetado, tamanho, espessura, idTipoMaterial FROM acetado" +
                " INNER JOIN material ON acetado.idTipoMaterial = material.idTipoMaterial" +
                " INNER JOIN tipoMaterial ON acetado.idTipoMaterial = tipoMaterial.id" +
                " WHERE acetado.idTipoMaterial =" + itemidTipoMatreial;

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?itemidTipoMaterial", itemidTipoMatreial);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }

        }

        public static DataTable GetAcetado()
        {
            Conexao con = new Conexao();
            var dt = new DataTable();

            var sql = "SELECT acetado.idTipoMaterial, tamanho, espessura FROM acetado " +
                "INNER JOIN material ON acetado.idTipoMaterial = material.idTipoMaterial" +
                " ORDER BY idTipoMaterial ASC";

            try
            {
                using (var cn = new MySqlConnection(con.getConnectionString()))
                {
                    cn.Open();

                    using (var da = new MySqlDataAdapter(sql, cn))
                    {
                        da.Fill(dt);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        #endregion

        #region Perola

        public void IDPEROLA(Int64 idTipoMaterial, String cor, Double tamanho)
        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();

            String query = "INSERT INTO perola (idTipoMaterial, cor, tamanho) VALUES";
            query += "(?idTipoMaterial, ?cor, ?tamanho)";

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?idTipoMaterial", idTipoMaterial);
                cmd.Parameters.AddWithValue("?cor", cor);
                cmd.Parameters.AddWithValue("?tamanho", tamanho);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }

        public void ADPEROLA(String cor, Double tamanho, Int64 idTipoMaterial)

        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();
            String query = "UPDATE perola " +
                     "INNER JOIN material ON perola.idTipoMaterial = material.idTipoMaterial" +
                     "SET cor = ?cor, tamanho = ?tamanho";
            query += " WHERE perola.idTipoMaterial =" + idTipoMaterial;

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?cor", cor);
                cmd.Parameters.AddWithValue("?tamanho", tamanho);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        public void RDPEROLA(Int64 idTipoMaterial)
        {
            con = new MySqlConnection();
            conexao = new Conexao();
            con.ConnectionString = conexao.getConnectionString();

            String query = "DELETE perola, cor, tamanho, idTipoMaterial FROM perola" +
                " INNER JOIN material ON perola.idTipoMaterial = material.idTipoMaterial" +
                " INNER JOIN tipoMaterial ON perola.idTipoMaterial = tipoMaterial.id" +
                " WHERE perola.idTipoMaterial = " + idTipoMaterial;

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?idTipoMaterial", idTipoMaterial);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }

        }

        public static DataTable GetPerola()
        {
            Conexao con = new Conexao();
            var dt = new DataTable();

            var sql = "SELECT perola.idTipoMaterial, cor, tamanho FROM perola" +
                "INNER JOIN material ON perola.idTipoMaterial = material.idTipoMaterial" +
                " ORDER BY idTipoMaterial ASC";

            try
            {
                using (var cn = new MySqlConnection(con.getConnectionString()))
                {
                    cn.Open();

                    using (var da = new MySqlDataAdapter(sql, cn))
                    {
                        da.Fill(dt);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        #endregion

    }
}
