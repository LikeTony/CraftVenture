﻿using System;
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
    public partial class frmCadastroOpcoes : Form
    {
        public frmCadastroOpcoes()
        {
            InitializeComponent();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            frmCadastrarPapel frmPapel = new frmCadastrarPapel();
            frmPapel.ShowDialog();
        }

        private void btnRenda_Click(object sender, EventArgs e)
        {
            frmCadastroRenda frmRenda = new frmCadastroRenda();
            frmRenda.ShowDialog();
        }

        private void btnPerola_Click(object sender, EventArgs e)
        {
            frmCadastroRenda frmRenda = new frmCadastroRenda();
            frmRenda.ShowDialog();
        }

        private void btnAcetato_Click(object sender, EventArgs e)
        {
            frmCadastroAcetato frmAcetato = new frmCadastroAcetato();   
            frmAcetato.ShowDialog();
        }

        private void btnFita_Click(object sender, EventArgs e)
        {
            frmCadastrarFita frmFita = new frmCadastrarFita();  
            frmFita.ShowDialog();
        }

        private void btnTecido_Click(object sender, EventArgs e)
        {
            frmCadastroTecido frmTecido = new frmCadastroTecido();  
            frmTecido.ShowDialog();
        }

        private void btnCanudo_Click(object sender, EventArgs e)
        {
            frmCadastroCanudo frmCanudo = new frmCadastroCanudo();
            frmCanudo.ShowDialog();
        }
    }
}
