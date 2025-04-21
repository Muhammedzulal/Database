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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        ProductDal _productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _productDal.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product()
            {
                Name = txtBoxName.Text,
                UnitPrice = Convert.ToDecimal(txtBoxPrice.Text),
                StockAmount = Convert.ToInt32(txtBoxAmount.Text)
            });
            dataGridView1.DataSource = _productDal.GetAll();
            MessageBox.Show("Product Added");
        }
    }
}
