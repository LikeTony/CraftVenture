﻿using GerenciadorDeEstoque.DAO;
using Org.BouncyCastle.Tls.Crypto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciadorDeEstoque.Apresentação
{
    public partial class frmAdicionarMaterialProduto : Form
    {
        MaterialProdutoVO materialProduto;
        DataTable dt = new DataTable();

        public frmAdicionarMaterialProduto(MaterialProdutoVO materialProduto)
        {
            InitializeComponent();
            Inicializar();

            this.materialProduto = materialProduto;
        }

        private void Inicializar()
        {
            dt = DAO.DAO.GetMaterial();
            dgvAdicionarProdutoKrypton.DataSource = dt;
            ConfigurarGradeMaterialProduto();

        }

        private void ConfigurarGradeMaterialProduto()
        {
            dgvAdicionarProdutoKrypton.DefaultCellStyle.Font = new Font("Segoe UI Emoji", 20, FontStyle.Bold);
            dgvAdicionarProdutoKrypton.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Emoji", 15, FontStyle.Bold);
            dgvAdicionarProdutoKrypton.RowHeadersWidth = 20;
            dgvAdicionarProdutoKrypton.RowTemplate.Height = 40;
            
            dgvAdicionarProdutoKrypton.Columns["idTipoMaterial"].HeaderText = "ID";
            dgvAdicionarProdutoKrypton.Columns["idTipoMaterial"].Visible = true;
            dgvAdicionarProdutoKrypton.Columns["idTipoMaterial"].ReadOnly = true;

            dgvAdicionarProdutoKrypton.Columns["escolha"].HeaderText = "Escolha";
            dgvAdicionarProdutoKrypton.Columns["escolha"].Width = 100;
            dgvAdicionarProdutoKrypton.Columns["escolha"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAdicionarProdutoKrypton.Columns["escolha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAdicionarProdutoKrypton.Columns["escolha"].ReadOnly = false;
           
            dgvAdicionarProdutoKrypton.Columns["nome"].HeaderText = "Nome";
            dgvAdicionarProdutoKrypton.Columns["nome"].Width = 300;
            dgvAdicionarProdutoKrypton.Columns["nome"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAdicionarProdutoKrypton.Columns["nome"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAdicionarProdutoKrypton.Columns["nome"].ReadOnly = true;

            dgvAdicionarProdutoKrypton.Columns["valor"].HeaderText = "Valor";
            dgvAdicionarProdutoKrypton.Columns["valor"].Width = 150;
            dgvAdicionarProdutoKrypton.Columns["valor"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAdicionarProdutoKrypton.Columns["valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAdicionarProdutoKrypton.Columns["valor"].ReadOnly = true;

            dgvAdicionarProdutoKrypton.Columns["quantidade"].HeaderText = "Quantidade";
            dgvAdicionarProdutoKrypton.Columns["quantidade"].Width = 100;
            dgvAdicionarProdutoKrypton.Columns["quantidade"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAdicionarProdutoKrypton.Columns["quantidade"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAdicionarProdutoKrypton.Columns["quantidade"].ReadOnly = false;

            dgvAdicionarProdutoKrypton.Columns["foto"].HeaderText = "Foto";
            dgvAdicionarProdutoKrypton.Columns["foto"].Width = 100;
            dgvAdicionarProdutoKrypton.Columns["foto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAdicionarProdutoKrypton.Columns["foto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAdicionarProdutoKrypton.Columns["foto"].ReadOnly = true;

        }


        private void btnNovo_Click(object sender, EventArgs e)
        {
            
            List<Int64> idMaterial = new List<Int64>();
            List<Int32> quantidade = new List<Int32>();

            try
            {

                foreach (DataGridViewRow row in dgvAdicionarProdutoKrypton.Rows)
                {
                    if (row.Cells["escolha"].Value.ToString() == "True")
                    {
                        if (row.Cells["quantidade"].Value != DBNull.Value && Convert.ToInt32(row.Cells["quantidade"].Value) > 0)
                        {
                            idMaterial.Add(Convert.ToInt64(row.Cells["idTipoMaterial"].Value));
                            quantidade.Add(Convert.ToInt32(row.Cells["quantidade"].Value));
                        }
                        else
                        {
                            throw new ArgumentException("O produto " + row.Cells["nome"].Value + " está sem quantidade ou com uma quantidade negativo");
                        }
                    }
                }

                materialProduto.IdMaterialLista = idMaterial;
                materialProduto.QuantidadeLista = quantidade;

                MessageBox.Show("Materiais adicionados ao produto com Sucesso");

                this.Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "erro");
            }


        }

        private void dgvLivrosKrypton_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        String palavra;

        private void txtPesquisar_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                DataView dv = new DataView(dt);

                if (e.KeyChar != '\b')
                {
                    palavra += e.KeyChar;

                    dv.RowFilter = String.Format("nome LIKE '%{0}%'", palavra);

                }
                else if (palavra.Length != 0)
                {
                    palavra = palavra.Remove(palavra.Length - 1);

                    dv.RowFilter = String.Format("nome LIKE '%{0}%'", palavra);

                }

                dgvAdicionarProdutoKrypton.DataSource = dv;

            }
            catch (Exception ex) { }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem certeza que gostaria de Voltar? (todas as informações não salvas serão perdidas)", "Voltar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
