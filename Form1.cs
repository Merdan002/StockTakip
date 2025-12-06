using Microsoft.VisualBasic;
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
    public partial class Form1 : Form
    {
        List<Product> products = new List<Product>();

        public Form1()
        {
            InitializeComponent();
            LoadCategories();
            LoadDemoProducts();
        }

        void LoadCategories()
        {
            foreach (var cat in Enum.GetValues(typeof(Category)))
                treeView1.Nodes.Add(cat.ToString());
        }

        void LoadDemoProducts()
        {
            products.Add(new Product("Elma", Category.Gida, 10, 50));
            products.Add(new Product("Kulaklık", Category.Elektronik, 350, 10));
            products.Add(new Product("Tişört", Category.Giyim, 120, 25));
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ListViewLoadCategory((Category)Enum.Parse(typeof(Category), e.Node.Text));
        }

        void ListViewLoadCategory(Category cat)
        {
            listView1.Items.Clear();
            var filtered = products.Where(x => x.Category == cat).ToList();

            foreach (var p in filtered)
            {
                ListViewItem item = new ListViewItem(p.Name);
                item.SubItems.Add(p.Price.ToString());
                item.SubItems.Add(p.Stock.ToString());
                item.SubItems.Add(p.IsCampaign ? p.CampaignPrice.ToString() : "-");
                item.Tag = p;
                listView1.Items.Add(item);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            Product p = (Product)listView1.SelectedItems[0].Tag;

            string input = Prompt.ShowDialog("Stok artır (+) veya azalt (-) giriniz.", "Stok Güncelle");

            if (input.StartsWith("+"))
            {
                int amount = int.Parse(input.Substring(1));
                p.IncreaseStock(amount);
            }
            else if (input.StartsWith("-"))
            {
                int amount = int.Parse(input.Substring(1));
                if (!p.DecreaseStock(amount))
                    MessageBox.Show("Negatif stok olamaz!", "Hata");
            }

            ListViewLoadCategory(p.Category);
        }

        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            ListViewLoadCategory((Category)Enum.Parse(typeof(Category), e.Node.Text));
        }


        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (listView1.SelectedItems.Count == 0) return;

            Product p = (Product)listView1.SelectedItems[0].Tag;

            string input = Prompt.ShowDialog("Stok artır (+) veya azalt (-) giriniz.", "Stok Güncelle");

            if (input.StartsWith("+"))
            {
                int amount = int.Parse(input.Substring(1));
                p.IncreaseStock(amount);
            }
            else if (input.StartsWith("-"))
            {
                int amount = int.Parse(input.Substring(1));
                if (!p.DecreaseStock(amount))
                    MessageBox.Show("Negatif stok olamaz!", "Hata");
            }

            ListViewLoadCategory(p.Category);
        
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {

            urunekle f = new urunekle();  // Burada form adın "urunekle"

            if (f.ShowDialog() == DialogResult.OK)
            {
                products.Add(f.NewProduct);

                if (treeView1.SelectedNode != null)
                    ListViewLoadCategory((Category)Enum.Parse(typeof(Category), treeView1.SelectedNode.Text));
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            Product p = (Product)listView1.SelectedItems[0].Tag;

            string input = Prompt.ShowDialog("Yeni fiyat giriniz:", "Fiyat Güncelle");

            if (decimal.TryParse(input, out decimal newPrice))
            {
                p.UpdatePrice(newPrice);
                ListViewLoadCategory(p.Category);
            }
        }

        private void btnKampanya_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            Product p = (Product)listView1.SelectedItems[0].Tag;

            string input = Prompt.ShowDialog("Kampanya fiyatı giriniz:", "Kampanya");

            if (decimal.TryParse(input, out decimal campPrice))
            {
                p.IsCampaign = true;
                p.CampaignPrice = campPrice;
                ListViewLoadCategory(p.Category);
            }
        }

        private void btnDetay_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            Product p = (Product)listView1.SelectedItems[0].Tag;

            string info = $"Ürün: {p.Name}\n" +
                          $"Kategori: {p.Category}\n" +
                          $"Fiyat: {p.Price}\n" +
                          $"Stok: {p.Stock}\n" +
                          $"Kampanya: {(p.IsCampaign ? p.CampaignPrice.ToString() : "Yok")}";

            MessageBox.Show(info, "Ürün Detayları");
        }
    
    }

}
