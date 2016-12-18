using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using WA.DataAccess.Entities;
using System.Windows.Forms;

namespace WA.DataAccess
{
    public class CancellationDao
    {
        private static Cancellation LoadCancellation(SqlDataReader reader)
        {
            Cancellation cancellation = new Cancellation();
            cancellation.Id = reader.GetInt32(reader.GetOrdinal("ID_Cancellation"));
            cancellation.Id_Issued = reader.GetInt32(reader.GetOrdinal("Id_Issued"));
            cancellation.Date_Cancellation = reader.GetDateTime(reader.GetOrdinal("Date_Cancellation"));
            return cancellation;
        }

        public Cancellation Get(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ID_Cancellation, Id_Issued, Date_Cancellation FROM CANCELLATION WHERE ID_Cancellation = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return !dataReader.Read() ? null : LoadCancellation(dataReader);
                    }
                }
            }
        }

        public IList<Cancellation> GetAll()
        {
            IList<Cancellation> cancellation = new List<Cancellation>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ID_Cancellation, Id_Issued, Date_Cancellation FROM CANCELLATION";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            cancellation.Add(LoadCancellation(dataReader));
                        }
                    }
                }
                return cancellation;
            }
        }

        public void Add(Cancellation cancellation)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO CANCELLATION (Id_Issued, Date_Cancellation) VALUES (@Id_Issued, @Date_Cancellation)";
                    cmd.Parameters.AddWithValue("@Id_Issued", cancellation.Id_Issued);
                    cmd.Parameters.AddWithValue("@Date_Cancellation", cancellation.Date_Cancellation);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void Update(Cancellation cancellation)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE CANCELLATION SET Date_revenue = @Date_revenue, Clothing_size = @Clothing_size WHERE ID_Cancellation = @ID";
                    cmd.Parameters.AddWithValue("@Id_Issued", cancellation.Id_Issued);
                    cmd.Parameters.AddWithValue("@Date_Cancellation", cancellation.Date_Cancellation);
                    cmd.Parameters.AddWithValue("@ID_Cancellation", cancellation.Id);
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
                    cmd.CommandText = "DELETE FROM CANCELLATION WHERE ID_Cancellation = @ID";
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
    }
}
