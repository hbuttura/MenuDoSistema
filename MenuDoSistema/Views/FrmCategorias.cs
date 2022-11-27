using MenuDoSistema.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuDoSistema.Views
{
    public partial class FrmCategorias : Form
    {
        Categoria c;
        public FrmCategorias()
        {
            InitializeComponent();
        }
        void limpaControles()
        {
            txtCodigo.Clear();
            txtCategoria.Clear();
            txtConsulta.Clear();
        }

        void carregarGrid(string consulta)
        {
            c = new Categoria()
            {
                categoria = consulta
            };
            dgvCategoria.DataSource = c.Consultar();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtCategoria.Text != String.Empty)
            {
                c = new Categoria() { categoria = txtCategoria.Text };
                c.Incluir();
                limpaControles();
                carregarGrid("");
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            c = new Categoria() { id = Convert.ToInt32(txtCodigo.Text), categoria = txtCategoria.Text };
            c.Alterar();
            limpaControles();
            carregarGrid("");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            c = new Categoria() { id = int.Parse(txtCodigo.Text) };
            c.Excluir();
            limpaControles();
            carregarGrid("");
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtConsulta.Text);
        }

        private void dgvCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategoria.RowCount > 0)
            {
                txtCodigo.Text = dgvCategoria.CurrentRow.Cells["id"].Value.ToString();
                txtCategoria.Text = dgvCategoria.CurrentRow.Cells["categoria"].Value.ToString();
            }
        }
    }
}
