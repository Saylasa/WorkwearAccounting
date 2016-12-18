using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using WA.DataAccess.Entities;
using System.Windows.Forms;

namespace WA.DataAccess
{
    public class IssuedDao
    {
        private static Issued LoadIssued(SqlDataReader reader)
        {
            Issued issued = new Issued();
            issued.Id = reader.GetInt32(reader.GetOrdinal("ID_Issued"));
            issued.Id_Revenue = reader.GetInt32(reader.GetOrdinal("Id_Revenue"));
            issued.Id_Person = reader.GetInt32(reader.GetOrdinal("Id_Person"));
            issued.Cancellation = reader.GetBoolean(reader.GetOrdinal("Cancellation"));
            issued.Date_Issued = reader.GetDateTime(reader.GetOrdinal("Date_Issued"));
            return issued;
        }

        public Issued Get(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ID_Issued, Id_Revenue, Id_Person, Cancellation, Date_Issued FROM ISSUED WHERE ID_Issued = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return !dataReader.Read() ? null : LoadIssued(dataReader);
                    }
                }
            }
        }

        public IList<Issued> GetAll()
        {
            IList<Issued> issueds = new List<Issued>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ID_Issued, Id_Revenue, Id_Person, Cancellation, Date_Issued FROM ISSUED";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            issueds.Add(LoadIssued(dataReader));
                        }
                    }
                }
                return issueds;
            }
        }

        public void Add(Issued issued)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO ISSUED (Id_Revenue, Id_Person, Cancellation, Date_Issued) VALUES (@Id_Revenue, @Id_Person, @Cancellation, @Date_Issued)";
                    cmd.Parameters.AddWithValue("@Id_Revenue", issued.Id_Revenue);
                    cmd.Parameters.AddWithValue("@Id_Person", issued.Id_Person);
                    cmd.Parameters.AddWithValue("@Cancellation", issued.Cancellation);
                    cmd.Parameters.AddWithValue("@Date_Issued", issued.Date_Issued);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void Update(Issued issued)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE ISSUED SET Id_Revenue = @Id_Revenue, Id_Person = @Id_Person, Cancellation = @Cancellation, Date_Issued = @Date_Issued WHERE ID_Issued = @ID";
                    cmd.Parameters.AddWithValue("@Id_Revenue", issued.Id_Revenue);
                    cmd.Parameters.AddWithValue("@Id_Person", issued.Id_Person);
                    cmd.Parameters.AddWithValue("@Cancellation", issued.Cancellation);
                    cmd.Parameters.AddWithValue("@Date_Issued", issued.Date_Issued);
                    cmd.Parameters.AddWithValue("@ID_Issued", issued.Id);
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
                    cmd.CommandText = "DELETE FROM ISSUED WHERE ID_Issued = @ID";
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

        public IList<Issued> SearchIssued(int id)
        {
            IList<Issued> issueds = new List<Issued>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ID_Issued, Id_Revenue, Id_Person, Cancellation, Date_Issued FROM ISSUED WHERE Id_Person like @id";
                    cmd.Parameters.AddWithValue("@Id", "%" + id + "%");
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            issueds.Add(LoadIssued(dataReader));
                        }
                    }
                }
            }
            return issueds;
        }
    }
}
