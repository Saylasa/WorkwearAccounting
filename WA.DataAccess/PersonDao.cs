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
        private static Person LoadPerson(SqlDataReader reader)
        {
            Person person = new Person();
            person.Id = reader.GetInt32(reader.GetOrdinal("ID_Person"));
            person.Name = reader.GetString(reader.GetOrdinal("Name"));
            person.Surname = reader.GetString(reader.GetOrdinal("Surname"));
            person.Patronymic = reader.GetString(reader.GetOrdinal("Patronymic"));
            person.Sex = reader.GetString(reader.GetOrdinal("Sex"));
            person.Height = reader.GetInt32(reader.GetOrdinal("Height"));
            person.ShoeSize = reader.GetString(reader.GetOrdinal("Shoe_Size"));
            person.SizeHeadDress = reader.GetInt32(reader.GetOrdinal("Size_HeadDress"));
            person.ClothingSize = reader.GetString(reader.GetOrdinal("Clothing_size"));
            person.SizeGlove = reader.GetString(reader.GetOrdinal("Size_Glove"));
            person.Id_Position = reader.GetInt32(reader.GetOrdinal("Id_Position"));
            return person;
        }

        public Person Get(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ID_Person, Name, Surname, Patronymic, Sex, Height, Shoe_Size, Size_HeadDress, Size_Glove, Id_Position, Clothing_size FROM PERSON WHERE ID_Person = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return !dataReader.Read() ? null : LoadPerson(dataReader);
                    }
                }
            }
        }

        public IList<Person> GetAll()
        {
            IList<Person> persons = new List<Person>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ID_Person, Name, Surname, Patronymic, Sex, Height, Shoe_Size, Size_HeadDress, Size_Glove, Id_Position, Clothing_size FROM PERSON";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            persons.Add(LoadPerson(dataReader));
                        }
                    }
                }
                return persons;
            }
        }

        public void Add(Person person)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO PERSON (Name, Surname, Patronymic, Sex, Height, Shoe_Size, Size_HeadDress, Size_Glove, Id_Position, Clothing_size) VALUES (@Name, @Surname, @Patronymic, @Sex, @Height, @Shoe_Size, @Size_HeadDress, @Size_Glove, @Id_Position, @Clothing_size)";
                    cmd.Parameters.AddWithValue("@Name", person.Name);
                    cmd.Parameters.AddWithValue("@Surname", person.Surname);
                    cmd.Parameters.AddWithValue("@Patronymic", person.Patronymic);
                    cmd.Parameters.AddWithValue("@Sex", person.Sex);
                    cmd.Parameters.AddWithValue("@Height", person.Height);
                    cmd.Parameters.AddWithValue("@Shoe_Size", person.ShoeSize);
                    cmd.Parameters.AddWithValue("@Size_HeadDress", person.SizeHeadDress);
                    cmd.Parameters.AddWithValue("@Size_Glove", person.SizeGlove);
                    cmd.Parameters.AddWithValue("@Clothing_size", person.ClothingSize);
                    cmd.Parameters.AddWithValue("@Id_Position", person.Id_Position);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void Update(Person person)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE PERSON SET Name = @Name, Surname = @Surname, Patronymic = @Patronymic, Sex = @Sex, Height = @Height, Shoe_Size = @Shoe_Size, Size_HeadDress = @Size_HeadDress, Size_Glove = @Size_Glove, Id_Position = @Id_Position, Clothing_size = @Clothing_size WHERE ID_Person = @ID";
                    cmd.Parameters.AddWithValue("@Name", person.Name);
                    cmd.Parameters.AddWithValue("@Surname", person.Surname);
                    cmd.Parameters.AddWithValue("@Patronymic", person.Patronymic);
                    cmd.Parameters.AddWithValue("@Sex", person.Sex);
                    cmd.Parameters.AddWithValue("@Height", person.Height);
                    cmd.Parameters.AddWithValue("@Shoe_Size", person.ShoeSize);
                    cmd.Parameters.AddWithValue("@Size_HeadDress", person.SizeHeadDress);
                    cmd.Parameters.AddWithValue("@Size_Glove", person.SizeGlove);
                    cmd.Parameters.AddWithValue("@Id_Position", person.Id_Position);
                    cmd.Parameters.AddWithValue("@Clothing_size", person.ClothingSize);
                    cmd.Parameters.AddWithValue("@ID_Person", person.Id);
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
                    cmd.CommandText = "DELETE FROM PERSON WHERE ID_Person = @ID";
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

        public IList<Person> SearchPersonsN(string Surname)
        {
            IList<Person> persons = new List<Person>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ID_Person, Name, Surname, Patronymic, Sex, Height, Shoe_Size, Size_HeadDress, Size_Glove, Id_Position, Clothing_size FROM PERSON WHERE Surname like @Surname";
                    cmd.Parameters.AddWithValue("@Surname", "%" + Surname);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            persons.Add(LoadPerson(dataReader));
                        }
                    }
                }
            }
            return persons;
        }

        public IList<Person> SearchPersonsP(int id)
        {
            IList<Person> persons = new List<Person>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ID_Person, Name, Surname, Patronymic, Sex, Height, Shoe_Size, Size_HeadDress, Size_Glove, Id_Position, Clothing_size FROM PERSON WHERE Id_Position like @Id_Position";
                    cmd.Parameters.AddWithValue("@Id_Position", "%" + id + "%");
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            persons.Add(LoadPerson(dataReader));
                        }
                    }
                }
            }
            return persons;
        }
    }
}
