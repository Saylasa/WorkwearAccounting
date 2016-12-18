using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using WA.DataAccess.Entities;
using System.Windows.Forms;

namespace WA.DataAccess
{
    public class RevenueDao
    {
        private static Revenue LoadRevenue(SqlDataReader reader)
        {
            Revenue revenue = new Revenue();
            revenue.Id = reader.GetInt32(reader.GetOrdinal("ID_Revenue"));
            revenue.Issued = reader.GetBoolean(reader.GetOrdinal("Issued"));
            revenue.Date_Revenue = reader.GetDateTime(reader.GetOrdinal("Date_revenue"));
            revenue.Clothing_size = reader.GetString(reader.GetOrdinal("Clothing_size"));
            revenue.Shoe_size = reader.GetInt32(reader.GetOrdinal("Shoe_size"));
            revenue.Size_Headdress = reader.GetInt32(reader.GetOrdinal("Size_Headdress"));
            revenue.Size_Glove = reader.GetInt32(reader.GetOrdinal("Size_Glove"));
            revenue.Id_WorkwearDirectory = reader.GetInt32(reader.GetOrdinal("ID_Workwear"));
            return revenue;
        }

        public Revenue Get(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ID_Revenue, Issued, Date_revenue, Clothing_size, Shoe_size, Size_Headdress, Size_Glove, ID_Workwear FROM REVENUE WHERE ID_Revenue = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return !dataReader.Read() ? null : LoadRevenue(dataReader);
                    }
                }
            }
        }

        public IList<Revenue> GetAll()
        {
            IList<Revenue> revenues = new List<Revenue>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ID_Revenue, Issued, Date_revenue, Clothing_size, Shoe_size, Size_Headdress, Size_Glove, ID_Workwear FROM REVENUE";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            revenues.Add(LoadRevenue(dataReader));
                        }
                    }
                }
                return revenues;
            }
        }

        public void Add(Revenue revenue)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO REVENUE (Date_revenue, Clothing_size, Shoe_size, Size_Headdress, Size_Glove, ID_Workwear) VALUES (@Date_revenue, @Clothing_size, @Shoe_size, @Size_Headdress, @Size_Glove, @ID_Workwear)";
                    cmd.Parameters.AddWithValue("@Date_revenue", revenue.Date_Revenue);
                    cmd.Parameters.AddWithValue("@Clothing_size", revenue.Clothing_size);
                    cmd.Parameters.AddWithValue("@Shoe_size", revenue.Shoe_size);
                    cmd.Parameters.AddWithValue("@Size_Headdress", revenue.Size_Headdress);
                    cmd.Parameters.AddWithValue("@Size_Glove", revenue.Size_Glove);
                    cmd.Parameters.AddWithValue("@ID_Workwear", revenue.Id_WorkwearDirectory);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void Update(Revenue revenue)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE REVENUE SET Date_revenue = @Date_revenue, Clothing_size = @Clothing_size, Shoe_size = @Shoe_size, Size_Headdress = @Size_Headdress, Size_Glove = @Size_Glove, ID_Workwear = @ID_Workwear WHERE ID_Revenue = @ID";
                    cmd.Parameters.AddWithValue("@Date_revenue", revenue.Date_Revenue);
                    cmd.Parameters.AddWithValue("@Clothing_size", revenue.Clothing_size);
                    cmd.Parameters.AddWithValue("@Shoe_size", revenue.Shoe_size);
                    cmd.Parameters.AddWithValue("@Size_Headdress", revenue.Size_Headdress);
                    cmd.Parameters.AddWithValue("@Size_Glove", revenue.Size_Glove);
                    cmd.Parameters.AddWithValue("@ID_Workwear", revenue.Id_WorkwearDirectory);
                    cmd.Parameters.AddWithValue("@ID_Revenue", revenue.Id);
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM REVENUE WHERE ID_revenue = @ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при удалении запроса в БД: " + ex.ToString(), "WARNING!");
                    }
                }
            }
        }

        /// <summary>
        /// Возвращает строку подключения к базе
        /// </summary>
        /// <returns></returns>
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["wadb"].ConnectionString;
        }

        /// <summary>
        /// Возвращает объект подключения к базе
        /// </summary>
        /// <returns></returns>
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }

        public IList<Revenue> SearchRevenue()
        {
            IList<Revenue> revenues = new List<Revenue>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ID_Revenue, Issued, Date_revenue, Clothing_size, Shoe_size, Size_Headdress, Size_Glove, ID_Workwear FROM REVENUE WHERE Issued like 0";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            revenues.Add(LoadRevenue(dataReader));
                        }
                    }
                }
            }
            return revenues;
        }
    }
}
