using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using WA.DataAccess.Entities;
using System.Windows.Forms;

namespace WA.DataAccess
{
    public class PersonDao
    {
        private static WorkwearDirectory LoadWorkwearDirectory(SqlDataReader reader)
        {
            WorkwearDirectory workwearDirectory = new WorkwearDirectory();
            workwearDirectory.Id = reader.GetInt32(reader.GetOrdinal("ID_Workwear"));
            workwearDirectory.Name = reader.GetString(reader.GetOrdinal("Name_Workwear"));
            workwearDirectory.Category = reader.GetString(reader.GetOrdinal("Category"));
            workwearDirectory.Description = reader.GetString(reader.GetOrdinal("Description"));
            workwearDirectory.TimeOfWear = reader.GetInt32(reader.GetOrdinal("Time_of_Wear"));
            workwearDirectory.Unit = reader.GetString(reader.GetOrdinal("Unit"));
            return workwearDirectory;
        }

        public WorkwearDirectory Get(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ID_Workwear, Name_Workwear, Category, Description, Time_of_Wear, Unit FROM WORKWEAR_DIRECTORY WHERE ID_Workwear = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return !dataReader.Read() ? null : LoadWorkwearDirectory(dataReader);
                    }
                }
            }
        }

        public IList<WorkwearDirectory> GetAll()
        {
            IList<WorkwearDirectory> workwearDirectories = new List<WorkwearDirectory>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ID_Workwear, Name_Workwear, Category, Description, Time_of_Wear, Unit FROM WORKWEAR_DIRECTORY";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            workwearDirectories.Add(LoadWorkwearDirectory(dataReader));
                        }
                    }
                }
                return workwearDirectories;
            }
        }

        public void Add(WorkwearDirectory workwearDirectory)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO WORKWEAR_DIRECTORY (Name_Workwear, Category, Description, Time_of_Wear, Unit) VALUES (@Name_Workwear, @Category, @Description, @Time_of_Wear, @Unit)";
                    cmd.Parameters.AddWithValue("@Name_Workwear", workwearDirectory.Name);
                    cmd.Parameters.AddWithValue("@Category", workwearDirectory.Category);
                    cmd.Parameters.AddWithValue("@Description", workwearDirectory.Description);
                    cmd.Parameters.AddWithValue("@Time_of_Wear", workwearDirectory.TimeOfWear);
                    cmd.Parameters.AddWithValue("@Unit", workwearDirectory.Unit);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void Update(WorkwearDirectory workwearDirectory)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE WORKWEAR_DIRECTORY SET Name_Workwear = @Name_Workwear, Category = @Category, Description = @Description, Time_of_Wear = @Time_of_Wear, Unit = @Unit WHERE ID_Workwear = @ID";
                    cmd.Parameters.AddWithValue("@Name_Workwear", workwearDirectory.Name);
                    cmd.Parameters.AddWithValue("@Category", workwearDirectory.Category);
                    cmd.Parameters.AddWithValue("@Description", workwearDirectory.Description);
                    cmd.Parameters.AddWithValue("@Time_of_Wear", workwearDirectory.TimeOfWear);
                    cmd.Parameters.AddWithValue("@Unit", workwearDirectory.Unit);
                    cmd.Parameters.AddWithValue("@ID_Workwear", workwearDirectory.Id);
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
                    cmd.CommandText = "DELETE FROM WORKWEAR_DIRECTORY WHERE ID_Workwear = @ID";
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

        public IList<WorkwearDirectory> SearchWorkwearDirectories(string Name)
        {
            IList<WorkwearDirectory> workwearDirectories = new List<WorkwearDirectory>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ID_Workwear, Name_Workwear, Category, Description, Time_of_Wear, Unit FROM WORKWEAR_DIRECTORY WHERE Name_Workwear like @Name";
                    cmd.Parameters.AddWithValue("@Name", "%" + Name + "%");
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            workwearDirectories.Add(LoadWorkwearDirectory(dataReader));
                        }
                    }
                }
            }
            return workwearDirectories;
        }
    }
}
