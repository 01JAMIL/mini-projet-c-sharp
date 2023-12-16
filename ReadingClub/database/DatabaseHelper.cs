using ReadingClub.models;
using ReadingClub.utils.shared;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Windows;

namespace ReadingClub.database{
    class DatabaseHelper {
        
        private static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=reading_club_db;Integrated Security=True;Connect Timeout=30;Encrypt=False";
        public static AuthActionResult SignUp (User user)
        {
            if (EmailExists(user.email))
            {
                return new AuthActionResult { 
                    Status = OperationStatus.ERROR,
                    Message = "This email is already in use."
                };
            }

            var query = "INSERT INTO [USER] (first_name, last_name, email, username, password) VALUES (@first_name, @last_name, @email, @username, @password)";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (var command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@first_name",user.firstName);
                    command.Parameters.AddWithValue("@last_name", user.lastName);
                    command.Parameters.AddWithValue("@email", user.email);
                    command.Parameters.AddWithValue("@username", user.username);
                    command.Parameters.AddWithValue("@password", user.password);

                    command.ExecuteNonQuery();
                    return new AuthActionResult
                    {
                        Status = OperationStatus.SUCCESS,
                        Message = "Account created successfully!"
                    };
                }
            }
        }

        public static AuthActionResult SignIn (string email, string password)
        {
            var query = "SELECT COUNT(1) FROM [USER] WHERE email = @email AND password = @password";
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (var command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue ("@email",email);
                    command.Parameters.AddWithValue("@password", password);

                    int count = (int)command.ExecuteScalar();
                    
                    // IF count > 0 => User exists
                    if (count > 0)
                    {
                        User user = GetUserByEmail(email);
                        return new AuthActionResult
                        {
                            Status = OperationStatus.SUCCESS,
                            Message = "User authenticated successfully.",
                            user = user
                        };
                    }
                    else
                    {
                        return new AuthActionResult
                        {
                            Status = OperationStatus.ERROR,
                            Message = "Email or password incorrect."
                        };
                    }
                }
            }
        }


        private static User GetUserByEmail(string email)
        {
            var query = "SELECT Id, first_name, last_name, email, username, password FROM [USER] WHERE email = @email";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open ();

                using (var command = new SqlCommand(query,conn))
                {
                    command.Parameters.AddWithValue("@email", email);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            User user = new User(
                                reader.GetInt32(reader.GetOrdinal("Id")),
                                reader.GetString(reader.GetOrdinal("first_name")),
                                reader.GetString(reader.GetOrdinal("last_name")),
                                reader.GetString(reader.GetOrdinal("email")),
                                reader.GetString(reader.GetOrdinal("username")),
                                ""
                            );
                            return user;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public static List<Room> GetRooms ()
        {
            var rooms = new List<Room>();
            var query = "SELECT * FROM [Room]";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var room = new Room(
                            reader.GetInt32(reader.GetOrdinal("ID")),
                            reader.GetString(reader.GetOrdinal("Name")),
                            reader.GetString(reader.GetOrdinal("Description")),
                            reader.GetString(reader.GetOrdinal("Image")),
                            reader.GetInt32(reader.GetOrdinal("numberOfMembers")),
                            reader.GetInt32(reader.GetOrdinal("numberOfBooks"))
                        );

                        rooms.Add(room);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return rooms;
        }

        public static Room GetRoomById (int roomID)
        {
            var query = "SELECT * FROM [Room] WHERE Id = @Id";
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (var command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Id", roomID);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Room room = new Room(
                                reader.GetInt32(reader.GetOrdinal("ID")),
                                reader.GetString(reader.GetOrdinal("Name")),
                                reader.GetString(reader.GetOrdinal("Description")),
                                reader.GetString(reader.GetOrdinal("Image")),
                                reader.GetInt32(reader.GetOrdinal("numberOfMembers")),
                                reader.GetInt32(reader.GetOrdinal("numberOfBooks"))
                            );
                            return room;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public static List<Book> GetBooks(int roomId)
        {
            var books = new List<Book>();
            var query = "SELECT * FROM [Book] WHERE RoomId = @RoomId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RoomId", roomId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var book = new Book(
                            reader.GetInt32(reader.GetOrdinal("ID")),
                            reader.GetString(reader.GetOrdinal("Name")),
                            reader.GetString(reader.GetOrdinal("Description")),
                            reader.GetString(reader.GetOrdinal("Image")),
                            reader.GetString(reader.GetOrdinal("Language")),
                            reader.GetString(reader.GetOrdinal("AuthorName")),
                            reader.GetInt32(reader.GetOrdinal("NumberOfPages")),
                            reader.GetInt32(reader.GetOrdinal("NumberOfLikes")),
                            reader.GetInt32(reader.GetOrdinal("RoomId"))
                        );

                        books.Add(book);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return books;
        }
        private static bool EmailExists(string email)
        {
            var query = "SELECT COUNT(1) FROM [USER] WHERE email = @email";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (var command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@email", email);

                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
}
