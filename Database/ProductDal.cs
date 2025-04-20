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
        public List<Product> GetAll()
        {
            SqlConnection connection = new SqlConnection(@"server=(localdb)\mssqllocaldb;initial catalog=ETrade;integrated security=true");
            if (connection.State == ConnectionState.Closed)//is the connection closed?
            {
                connection.Open();
            }

            SqlCommand command = new SqlCommand("select * from Products", connection);
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
            connection.Close();
            return products;
        }

        public DataTable GetAll2()
        {
            SqlConnection connection = new SqlConnection(@"server=(localdb)\mssqllocaldb;initial catalog=ETrade;integrated security=true");
            if (connection.State == ConnectionState.Closed)//is the connection closed?
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand("select * from Products", connection);
            SqlDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            reader.Close();
            connection.Close();
            return dataTable;
        }
    }
}
