using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        ProductDal _productDal = new ProductDal();

        //Veritabanından verileri çekme
        private void LoadProducts()
        {
            dataGridView1.DataSource = _productDal.GetAll();
        }

        //Form yüklendiğinde verileri çekme
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }


        //Product ekleme    
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product()
            {
                Name = txtBoxName.Text,
                UnitPrice = Convert.ToDecimal(txtBoxPrice.Text),
                StockAmount = Convert.ToInt32(txtBoxAmount.Text)
            });
            LoadProducts();
            txtBoxName.Clear();
            txtBoxPrice.Clear();
            txtBoxAmount.Clear();
            MessageBox.Show("Product Added");
        }

        //Seçilen Product'u boxlara yükleme
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBoxNameU.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtBoxPriceU.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtBoxAmountU.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        //Product Güncelleme
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product product = new Product()
            {
                Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                Name = txtBoxNameU.Text,
                UnitPrice = Convert.ToDecimal(txtBoxPriceU.Text),
                StockAmount = Convert.ToInt32(txtBoxAmountU.Text)
            };
            _productDal.Update(product);
            txtBoxNameU.Clear();
            txtBoxPriceU.Clear();
            txtBoxAmountU.Clear();
            LoadProducts();
            MessageBox.Show("Product Updated");
        }
        //Product Silme
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            _productDal.Delete(id);
            LoadProducts();
            txtBoxNameU.Clear();
            txtBoxPriceU.Clear();
            txtBoxAmountU.Clear();
            MessageBox.Show("Product Deleted");
        }

    }
}
