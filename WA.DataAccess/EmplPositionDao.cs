using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using WA.DataAccess.Entities;
using System.Windows.Forms;

namespace WA.DataAccess
{
    public class EmplPositionDao
    {
        private static EmplPosition LoadEmplPosition(SqlDataReader reader)
        {
            EmplPosition emplPosition = new EmplPosition();
            emplPosition.Id = reader.GetInt32(reader.GetOrdinal("ID_Position"));
            emplPosition.Name = reader.GetString(reader.GetOrdinal("Name_Empl_Position"));
            emplPosition.Id_Manufactory = reader.GetInt32(reader.GetOrdinal("ID_Manufactory"));
            return emplPosition;
        }

        public EmplPosition Get(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ID_Position, Name_Empl_Position, ID_Manufactory FROM EMPL_POSITION WHERE ID_Position = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return !dataReader.Read() ? null : LoadEmplPosition(dataReader);
                    }
                }
            }
        }

        public IList<EmplPosition> GetAll()
        {
            IList<EmplPosition> emplPosition = new List<EmplPosition>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ID_Position, Name_Empl_Position, ID_Manufactory FROM EMPL_POSITION";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            emplPosition.Add(LoadEmplPosition(dataReader));
                        }
                    }
                }
                return emplPosition;
            }
        }

        public void Add(EmplPosition emplPosition)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO EMPL_POSITION (Name_Empl_Position, ID_Manufactory) VALUES (@Name_Empl_Position, @ID_Manufactory)";
                    cmd.Parameters.AddWithValue("@Name_Empl_Position", emplPosition.Name);
                    cmd.Parameters.AddWithValue("@ID_Manufactory", emplPosition.Id_Manufactory);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void Update(EmplPosition emplPosition)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE EMPL_POSITION SET Name_Empl_Position = @Name_Empl_Position, ID_Manufactory = @ID_Manufactory WHERE ID_Position = @ID";
                    cmd.Parameters.AddWithValue("@Name_Empl_Position", emplPosition.Name);
                    cmd.Parameters.AddWithValue("@ID_Manufactory", emplPosition.Id_Manufactory);
                    cmd.Parameters.AddWithValue("@ID_Position", emplPosition.Id);
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
                    cmd.CommandText = "DELETE FROM EMPL_POSITION WHERE ID_Position = @ID";
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

        public IList<EmplPosition> SearchEmplPosition(int Id_Manufactory)
        {
            IList<EmplPosition> emplPosition = new List<EmplPosition>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ID_Position, Name_Empl_Position, ID_Manufactory FROM EMPL_POSITION WHERE Id_Manufactory like @Id_Manufactory";
                    cmd.Parameters.AddWithValue("@Id_Manufactory", "%" + Id_Manufactory + "%");
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            emplPosition.Add(LoadEmplPosition(dataReader));
                        }
                    }
                }
            }
            return emplPosition;
        }
    }
}
