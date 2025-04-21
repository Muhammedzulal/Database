using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class ProductDal
    {
        //Veritabanı bağlantısı
        SqlConnection _connection = new SqlConnection(@"server=(localdb)\mssqllocaldb;initial catalog=ETrade;integrated security=true");

        //Bağlantı kontrolü
        private void ConnetionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        //List <Product> kullanarak verileri çekme
        public List<Product> GetAll()
        {
            ConnetionControl();

            SqlCommand command = new SqlCommand("select * from Products", _connection);
            SqlDataReader reader = command.ExecuteReader();

            List<Product> products = new List<Product>();

            while (reader.Read()) 
            {
                Product product = new Product();
                product.Id = Convert.ToInt32(reader["Id"]);
                product.Name = Convert.ToString(reader["Name"]);
                product.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
                product.StockAmount = Convert.ToInt32(reader["StockAmount"]);
                products.Add(product);
            }

            reader.Close();
            _connection.Close();
            return products;
        }


        //DataTable kullanarak verileri çekme
        public DataTable GetAll2()
        {
            ConnetionControl();

            SqlCommand command = new SqlCommand("select * from Products", _connection);
            SqlDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            reader.Close();
            _connection.Close();
            return dataTable;
        }


        public void Add(Product product)
        {
            ConnetionControl();
            SqlCommand command = new SqlCommand(
                "insert into Products values(@name,@unitPrice,@stockAmount)", _connection);
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@unitPrice",product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            command.ExecuteNonQuery();
            _connection.Close();
        }
    }
}
