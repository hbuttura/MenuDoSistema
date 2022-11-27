using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MenuDoSistema.Models;


namespace MenuDoSistema.Views
{
    public partial class FrmMarcas : Form
    {
        Marca m;
        public FrmMarcas()
        {
            InitializeComponent();
        }
        void limpaControles()
        {
            txtCodigo.Clear();
            txtMarca.Clear();
            txtConsulta.Clear();
        }
        void carregarGrid(string consulta)
        {
            m = new Marca() { marca = consulta };
            dgvMarcas.DataSource = m.Consultar();
        }
        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtMarca.Text == string.Empty) return;
            m = new Marca() { marca = txtMarca.Text};
            m.Incluir();
            limpaControles();
            carregarGrid("");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            m = new Marca()
            {
                id = Convert.ToInt32(txtCodigo.Text),
                marca = txtMarca.Text
            };
            m.Alterar();
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
            m = new Marca() { id = Convert.ToInt32(txtCodigo.Text) };
            m.Excluir();
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

        private void dgvMarcas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMarcas.RowCount > 0)
            {
                txtCodigo.Text = dgvMarcas.CurrentRow.Cells["id"].Value.ToString();
                txtMarca.Text = dgvMarcas.CurrentRow.Cells["marca"].Value.ToString();
            }
        }
    }
}
