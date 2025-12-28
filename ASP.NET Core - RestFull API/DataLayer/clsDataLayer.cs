using Microsoft.Data.SqlClient;
using System.Data;

namespace DataLayer
{
    public class clsStudentsDOT
    {
        public int id {  get; set; }
        public string? name {  get; set; }
        public int age {  get; set; }
        public string? address {  get; set; }
        public clsStudentsDOT(int id, string? name, int age, string? address)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.address = address;
        }
    }
    public class clsDataLayer
    {
        public static List<clsStudentsDOT> GetAllStudents()
        {
            List<clsStudentsDOT> students = new();
            using(SqlConnection connection = new (clsDataAccessConnection.connectionString))
            {
                using(SqlCommand command = new ("SP_GetAllStudents", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            students.Add(
                                new clsStudentsDOT(
                                    reader.GetInt32(reader.GetOrdinal("id")),
                                    reader.GetString(reader.GetOrdinal("name")),
                                    reader.GetInt32(reader.GetOrdinal("age")),
                                    reader.GetString(reader.GetOrdinal("address"))
                                )
                            );
                        }
                    }
                }
            }
            return students;
        }
        public static clsStudentsDOT? GetStudentByID(int ID)
        {
            using (SqlConnection connection = new(clsDataAccessConnection.connectionString))
            {
                using (SqlCommand command = new("SP_GetStudentByID", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", ID);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new clsStudentsDOT(
                                reader.GetInt32(reader.GetOrdinal("id")),
                                reader.GetString(reader.GetOrdinal("name")),
                                reader.GetInt32(reader.GetOrdinal("age")),
                                reader.GetString(reader.GetOrdinal("address"))
                            );
                        }
                        else
                            return null;
                    }
                }
            }
        }
        public static int AddNewStudent(clsStudentsDOT StDOT)
        {
            using (SqlConnection connection = new(clsDataAccessConnection.connectionString))
            {
                using (SqlCommand command = new("SP_AddNewStudent", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", StDOT.name);
                    command.Parameters.AddWithValue("@age", StDOT.age);
                    command.Parameters.AddWithValue("@address", StDOT.address);
                    var getID = new SqlParameter("@id", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(getID);
                    connection.Open();
                    command.ExecuteNonQuery();
                    int NewID = (int)getID.Value;
                    return NewID;
                }
            }
        }
        public static bool UpdateStudent(clsStudentsDOT StDOT)
        {
            using (SqlConnection connection = new(clsDataAccessConnection.connectionString))
            {
                using (SqlCommand command = new("SP_UpdateStudent", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", StDOT.name);
                    command.Parameters.AddWithValue("@age", StDOT.age);
                    command.Parameters.AddWithValue("@address", StDOT.address);
                    command.Parameters.AddWithValue("@id", StDOT.id);
                    connection.Open();
                    int rowAffected = (int)command.ExecuteScalar();
                    return rowAffected > 0;
                }
            }
        }
        public static bool DeleteStudent(int ID)
        {
            using (SqlConnection connection = new(clsDataAccessConnection.connectionString))
            {
                using (SqlCommand command = new("SP_DeleteStudent", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", ID);
                    connection.Open();
                    int rowAffected = (int)command.ExecuteScalar();
                    return rowAffected > 0;
                }
            }
        }
    }
}
