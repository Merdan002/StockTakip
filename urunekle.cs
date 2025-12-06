using SeverM.StokTakip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeverM
{
    public partial class urunekle : Form
    {
        public Product NewProduct { get; private set; }

        public urunekle()
        {
            InitializeComponent();
            cmbKategori.DataSource = Enum.GetValues(typeof(Category));
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            Category cat = (Category)cmbKategori.SelectedItem;
            decimal price = decimal.Parse(txtFiyat.Text);
            int stock = int.Parse(txtStok.Text);

            NewProduct = new Product(name, cat, price, stock);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
