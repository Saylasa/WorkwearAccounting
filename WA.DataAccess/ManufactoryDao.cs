using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using WA.DataAccess.Entities;
using System.Windows.Forms;

namespace WA.DataAccess
{
    public class ManufactoryDao
    {
        private static Manufactory LoadManufactory(SqlDataReader reader)
        {
            Manufactory manufactory = new Manufactory();
            manufactory.Id = reader.GetInt32(reader.GetOrdinal("ID_Manufactory"));
            manufactory.Name = reader.GetString(reader.GetOrdinal("Name_Manufactory"));
            return manufactory;
        }

        public Manufactory Get(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ID_Manufactory, Name_Manufactory FROM MANUFACTORY WHERE ID_Manufactory = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return !dataReader.Read() ? null : LoadManufactory(dataReader);
                    }
                }
            }
        }

        public IList<Manufactory> GetAll()
        {
            IList<Manufactory> manufactory = new List<Manufactory>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ID_Manufactory, Name_Manufactory FROM MANUFACTORY";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            manufactory.Add(LoadManufactory(dataReader));
                        }
                    }
                }
                return manufactory;
            }
        }

        public void Add(Manufactory manufactory)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO MANUFACTORY (Name_Manufactory) VALUES (@Name_Manufactory)";
                    cmd.Parameters.AddWithValue("@Name_Manufactory", manufactory.Name);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void Update(Manufactory manufactory)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE MANUFACTORY SET Name_Manufactory = @Name_Manufactory WHERE ID_Manufactory = @ID";
                    cmd.Parameters.AddWithValue("@Name_Empl_Position", manufactory.Name);
                    cmd.Parameters.AddWithValue("@ID_Manufactory", manufactory.Id);
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
                    cmd.CommandText = "DELETE FROM MANUFACTORY WHERE ID_Manufactory = @ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при передаче запроса в БД: " + ex.ToString(), "WARNING!");
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
