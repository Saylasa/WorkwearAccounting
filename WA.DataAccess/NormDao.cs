using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using WA.DataAccess.Entities;
using System.Windows.Forms;

namespace WA.DataAccess
{
    public class NormDao
    {
        private static Norm LoadNorm(SqlDataReader reader)
        {
            Norm norm = new Norm();
            norm.Id = reader.GetInt32(reader.GetOrdinal("ID_Norm"));
            norm.Amount = reader.GetInt32(reader.GetOrdinal("Amount"));
            norm.Id_EmplPosition = reader.GetInt32(reader.GetOrdinal("ID_Position"));
            norm.Id_WorkwearDirectory = reader.GetInt32(reader.GetOrdinal("ID_Workwear"));
            return norm;
        }

        public Norm Get(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ID_Norm, Amount, ID_Position, ID_Workwear FROM NORM WHERE ID_Norm = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return !dataReader.Read() ? null : LoadNorm(dataReader);
                    }
                }
            }
        }

        public IList<Norm> GetAll()
        {
            IList<Norm> norm = new List<Norm>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ID_Norm, Amount, ID_Position, ID_Workwear FROM NORM";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            norm.Add(LoadNorm(dataReader));
                        }
                    }
                }
                return norm;
            }
        }

        public void Add(Norm norm)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO NORM (Amount, ID_Position, ID_Workwear) VALUES (@Amount, @ID_Position, @ID_Workwear)";
                    cmd.Parameters.AddWithValue("@Amount", norm.Amount);
                    cmd.Parameters.AddWithValue("@ID_Position", norm.Id_EmplPosition);
                    cmd.Parameters.AddWithValue("@ID_Workwear", norm.Id_WorkwearDirectory);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void Update(Norm norm)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE NORM SET Amount = @Amount, Id_Position = @Id_Position, ID_Workwear = @ID_Workwear WHERE ID_Norm = @ID";
                    cmd.Parameters.AddWithValue("@Amount", norm.Amount);
                    cmd.Parameters.AddWithValue("@Id_Position", norm.Id_EmplPosition);
                    cmd.Parameters.AddWithValue("@ID_Workwear", norm.Id_WorkwearDirectory);
                    cmd.Parameters.AddWithValue("@ID", norm.Id);
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
                    cmd.CommandText = "DELETE FROM NORM WHERE ID_Norm = @ID";
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

        public IList<Norm> SearchNorm(int Id_Position )
        {
            IList<Norm> norm = new List<Norm>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ID_Norm, Amount, ID_Position, ID_Workwear FROM NORM WHERE ID_Position like @ID_Position";
                    cmd.Parameters.AddWithValue("@ID_Position", "%" + Id_Position + "%");
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            norm.Add(LoadNorm(dataReader));
                        }
                    }
                }
            }
            return norm;
        }
    }
}
