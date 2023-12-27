using ReadingClub.models;
using ReadingClub.utils.shared;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Windows;

namespace ReadingClub.database{
    class DatabaseHelper {
        
        private static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ReadingClub;Integrated Security=True;Connect Timeout=30;Encrypt=False";
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

        public static List<Room> GetRooms (int userId)
        {
            var rooms = new List<Room>();
            var query = @"
                SELECT r.* 
                FROM [Room] r
                LEFT JOIN [RoomUser] ru ON r.ID = ru.RoomID AND ru.UserID = @UserID
                WHERE ru.RoomID IS NULL";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userId);

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
                    reader.GetInt32(reader.GetOrdinal("RoomId")),
                    reader.GetBoolean(reader.GetOrdinal("Favorite")),
                    reader.GetBoolean(reader.GetOrdinal("CurrentlyReading")),
                    reader.GetBoolean(reader.GetOrdinal("WantToRead"))
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


        public static List<Book> GetAllBooks()
        {
            var books = new List<Book>();
            var query = "SELECT * FROM [Book]";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

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
                            reader.GetInt32(reader.GetOrdinal("RoomId")),
                            reader.GetBoolean(reader.GetOrdinal("Favorite")),
                            reader.GetBoolean(reader.GetOrdinal("CurrentlyReading")),
                            reader.GetBoolean(reader.GetOrdinal("WantToRead"))
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

        public static void UpdateBookStatus(int bookId, bool wantToRead, bool currentlyReading, bool favorite)
        {
            var query = "UPDATE [Book] SET WantToRead = @WantToRead, CurrentlyReading = @CurrentlyReading, Favorite = @Favorite WHERE Id = @BookId";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (var command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@WantToRead", wantToRead);
                    command.Parameters.AddWithValue("@CurrentlyReading", currentlyReading);
                    command.Parameters.AddWithValue("@Favorite", favorite);
                    command.Parameters.AddWithValue("@BookId", bookId);

                    command.ExecuteNonQuery();
                }
            }
        }


        public static void JoinRoom(int roomId, int userId)
        {
            var query = "INSERT INTO [RoomUser] (RoomID, UserID) VALUES (@RoomID, @UserID)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@RoomID", roomId);
                command.Parameters.AddWithValue("@UserID", userId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot join room try again later !!!                      ", "Something went wrong!");
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

        public static bool IsUserInRoom(int roomId, int userId)
        {
            var query = "SELECT COUNT(*) FROM [RoomUser] WHERE RoomID = @RoomID AND UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RoomID", roomId);
                command.Parameters.AddWithValue("@UserID", userId);

                try
                {
                    connection.Open();

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot check if user already joined this room try again later !!!", "Something went wrong!");
                    Console.WriteLine("An error occurred: " + ex.Message);
                    return false;
                }
            }
        }


        public static int RoomNumberOfBooks (int roomId)
        {
            var query = "SELECT COUNT(*) FROM [Book] WHERE RoomId = @RoomId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RoomId", roomId);
                try 
                { 
                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count;
                } 
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot get books count try again later !!!", "Something went wrong!");
                    Console.WriteLine("An error occurred: " + ex.Message);
                    return 0;
                }
            }
        }

        public static int RoomNumberOfMembers(int roomId)
        {
            var query = "SELECT COUNT(*) FROM [RoomUser] WHERE RoomID = @RoomId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RoomId", roomId);
                try
                {
                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot get members count try again later !!!", "Something went wrong!");
                    Console.WriteLine("An error occurred: " + ex.Message);
                    return 0;
                }
            }
        }

        public static List<Room> GetJoinedRooms(int userId)
        {
            List<Room> joinedRooms = new List<Room>();

            // Define the SQL query to retrieve rooms
            string query = @"
        SELECT r.* 
        FROM [Room] r
        INNER JOIN [RoomUser] ru ON r.ID = ru.RoomID
        WHERE ru.UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Create a new Room object from the row data
                                
                                Room room = new Room(
                                    reader.GetInt32(reader.GetOrdinal("ID")),
                                    reader.GetString(reader.GetOrdinal("Name")),
                                    reader.GetString(reader.GetOrdinal("Description")),
                                    reader.GetString(reader.GetOrdinal("Image")),
                                    reader.GetInt32(reader.GetOrdinal("numberOfMembers")),
                                    reader.GetInt32(reader.GetOrdinal("numberOfBooks"))
                                );
                                
                                joinedRooms.Add(room);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred while retrieving joined rooms: " + ex.Message);
                    }
                }
            }

            // Return the list of joined rooms
            return joinedRooms;
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
