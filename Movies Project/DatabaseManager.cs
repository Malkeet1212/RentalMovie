using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Movies_Project
{
    public class DatabaseManager
    {
        public string str = "Data Source=WT135-826LSW\\SQLEXPRESS;Initial Catalog=Movies_Project;Integrated Security=True";
       
        SqlCommand SqlStr = new SqlCommand();
        SqlDataReader SqlReader;
        String SqlStmt;
        SqlConnection SqlConn = new SqlConnection("Data Source=WT135-826LSW\\SQLEXPRESS;Initial Catalog=Movies_Project;Integrated Security=True");


        // Customers Function
        // Read Customers from Database
        public DataTable Customer()
        {
            DataTable dt = new DataTable();
            SqlDataReader SqlReader;

            try
            {
                SqlStr.Connection = SqlConn;
                SqlStmt = "Select * from Customer";

                using (SqlStr = new SqlCommand(SqlStmt, SqlConn))
                {
                    SqlConn.Open();
                    SqlReader = SqlStr.ExecuteReader();

                    if (SqlReader.HasRows)
                    {
                        dt.Load(SqlReader);
                    }
                    SqlConn.Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
                SqlConn.Close();
                return null;
            }
        }
        // Create or Add Customer in Databse
        public bool AddCustomer(string FirstName, string LastName, string Address, string Phone)
        {
            bool CustomerAdded = false;

            try
            {
                SqlStr.Connection = SqlConn;
                SqlStmt = "Insert into Customer(FirstName,LastName,Address,Phone) values (@FirstName, @LastName, @Address, @Phone)";

                using (SqlStr = new SqlCommand(SqlStmt, SqlConn))
                {
                    SqlStr.Parameters.AddWithValue("@FirstName", FirstName);
                    SqlStr.Parameters.AddWithValue("@LastName", LastName);
                    SqlStr.Parameters.AddWithValue("@Address", Address);
                    SqlStr.Parameters.AddWithValue("@Phone", Phone);

                    SqlStr.CommandText = SqlStmt;

                    SqlConn.Open();
                    int rowsadded = SqlStr.ExecuteNonQuery();

                    if (rowsadded > 0)
                    {
                        CustomerAdded = true;
                    }
                    SqlConn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
                SqlConn.Close();
            }
            return CustomerAdded;
        }
        // Delete Customer from DataBase
        public bool DeleteCustomer(int CustID)
        {
            bool CustomerDeleted = false;

            try
            {
                SqlStr.Connection = SqlConn;
                SqlStmt = "Delete from Customer where CustID= @CustID";

                using (SqlStr = new SqlCommand(SqlStmt, SqlConn))
                {
                    SqlStr.Parameters.AddWithValue("@CustID", CustID);
                    SqlConn.Open();
                    Int32 rowsadded = SqlStr.ExecuteNonQuery();

                    if (rowsadded > 0)
                    {
                        CustomerDeleted = true;
                    }
                    SqlConn.Close();
                }
                return CustomerDeleted;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
                SqlConn.Close();
                return false;
            }
        }
        // Edit Customer in Database
        public bool EditCustomer(string FirstName, string LastName, string Address, string Phone, int CustID)
        {
            bool customerEdited = false;

            try
            {
                SqlStr.Connection = SqlConn;
                SqlStmt = "Update Customer set FirstName = @FirstName, LastName = @LastName, Address = @Address, Phone = @Phone where CustID = @CustID";

                using (SqlStr = new SqlCommand(SqlStmt, SqlConn))
                {
                    SqlStr.Parameters.AddWithValue("@FirstName", FirstName);
                    SqlStr.Parameters.AddWithValue("@LastName", LastName);
                    SqlStr.Parameters.AddWithValue("@Address", Address);
                    SqlStr.Parameters.AddWithValue("@Phone", Phone);
                    SqlStr.Parameters.AddWithValue("@CustID", CustID);

                    SqlStr.CommandText = SqlStmt;

                    SqlConn.Open();
                    int rowsmodified = SqlStr.ExecuteNonQuery();

                    if (rowsmodified > 0)
                    {
                        customerEdited = true;
                    }
                    SqlConn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
                SqlConn.Close();
            }
            return customerEdited;
        }
        //Search Customers in Database
        public DataTable SearchCustomer(string firstname, string LastName, string Address, string Phone)
        {
            DataTable dt = new DataTable();
            SqlDataReader SqlReader;

            try
            {
                SqlStr.Connection = SqlConn;
                SqlStmt = "Select * from Customer where firstname like '%" + firstname + "%' and lastname like '%" + LastName + "%' and Address like '%" + Address + "%' and Phone like '%" + Phone + "%'";

                using (SqlStr = new SqlCommand(SqlStmt, SqlConn))
                {
                    SqlConn.Open();
                    SqlReader = SqlStr.ExecuteReader();

                    if (SqlReader.HasRows)
                    {
                        dt.Load(SqlReader);
                    }
                    SqlConn.Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
                SqlConn.Close();
                return null;
            }
        }
        // Movies functions
        // Read Movies from Database
        public DataTable Movies()
        {
            DataTable dt = new DataTable();
            SqlDataReader SqlReader;

            try
            {
                SqlStr.Connection = SqlConn;
                SqlStmt = "Select * from Movies";

                using (SqlStr = new SqlCommand(SqlStmt, SqlConn))
                {
                    SqlConn.Open();
                    SqlReader = SqlStr.ExecuteReader();

                    if (SqlReader.HasRows)
                    {
                        dt.Load(SqlReader);
                    }
                    SqlConn.Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
                SqlConn.Close();
                return null;
            }
        }
        // Add Movies to Database
        public bool AddMovie(string Title, string Genre, string RentalCost, string Year, string Plot, string Copies, string Rating)
        {
            bool MovieAdded = false;

            try
            {
                SqlStr.Connection = SqlConn;
                SqlStmt = "Insert into Movies(Title,Genre,Rental_Cost,Year,Plot,Copies,Rating) values (@Title, @Genre, @Rental_Cost, @Year, @Plot, @Copies, @Rating)";

                using (SqlStr = new SqlCommand(SqlStmt, SqlConn))
                {
                    SqlStr.Parameters.AddWithValue("@Title", Title);
                    SqlStr.Parameters.AddWithValue("@Genre", Genre);
                    SqlStr.Parameters.AddWithValue("@Rental_Cost", RentalCost);
                    SqlStr.Parameters.AddWithValue("@Year", Year);
                    SqlStr.Parameters.AddWithValue("@Plot", Plot);
                    SqlStr.Parameters.AddWithValue("@Copies", Copies);
                    SqlStr.Parameters.AddWithValue("@Rating", Rating);

                    SqlStr.CommandText = SqlStmt;

                    SqlConn.Open();
                    int rowsadded = SqlStr.ExecuteNonQuery();

                    if (rowsadded > 0)
                    {
                        MovieAdded = true;
                    }
                    SqlConn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
                SqlConn.Close();
            }
            return MovieAdded;
        }
        // Edit Movies in Database
        public bool EditMovies(string Title, string Genre, string RentalCost, string Year, string Plot, string Copies, string Rating, int MovieID)
        {
            bool MovieEdited = false;

            try
            {
                SqlStr.Connection = SqlConn;
                SqlStmt = "Update Movies set Title = @Title, Genre = @Genre, Rental_Cost = @Rental_Cost, Year = @Year, " +
                    " Plot = @Plot, Copies = @Copies, Rating = @Rating where MovieID = @MovieID";

                using (SqlStr = new SqlCommand(SqlStmt, SqlConn))
                {
                    SqlStr.Parameters.AddWithValue("@Title", Title);
                    SqlStr.Parameters.AddWithValue("@Genre", Genre);
                    SqlStr.Parameters.AddWithValue("@Rental_Cost", RentalCost);
                    SqlStr.Parameters.AddWithValue("@Year", Year);
                    SqlStr.Parameters.AddWithValue("@Plot", Plot);
                    SqlStr.Parameters.AddWithValue("@Copies", Copies);
                    SqlStr.Parameters.AddWithValue("@Rating", Rating);
                    SqlStr.Parameters.AddWithValue("@MovieID", MovieID);

                    SqlStr.CommandText = SqlStmt;

                    SqlConn.Open();
                    int rowsmodified = SqlStr.ExecuteNonQuery();

                    if (rowsmodified > 0)
                    {
                        MovieEdited = true;
                    }
                    SqlConn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
                SqlConn.Close();
            }
            return MovieEdited;
        }
        // Delete Movies from Database
        public bool DeleteMovies(int MovieID)
        {
            bool MovieDeleted = false;

            try
            {
                using (SqlCommand SqlStr = SqlConn.CreateCommand())
                {
                    SqlStr.CommandText = "DeleteMovie";
                    SqlStr.CommandType = CommandType.StoredProcedure;
                    SqlStr.Parameters.AddWithValue("@MovieID", MovieID);
                    SqlConn.Open();
                    Int32 rowsadded = SqlStr.ExecuteNonQuery();

                    if (rowsadded > 0)
                    {
                        MovieDeleted = true;
                    }
                    SqlConn.Close();
                }
                return MovieDeleted;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
                SqlConn.Close();
                return false;
            }
        }
        //Search Movies in Database
        public DataTable SearchMovie(string Title, string Genre, string Year)
        {
            DataTable dt = new DataTable();
            SqlDataReader SqlReader;

            try
            {
                SqlStr.Connection = SqlConn;
                SqlStmt = "Select * from Movies where Title like '%" + Title + "%' and Genre like '%" + Genre + "%' and Year like '%" + Year + "%'";

                using (SqlStr = new SqlCommand(SqlStmt, SqlConn))
                {
                    SqlConn.Open();
                    SqlReader = SqlStr.ExecuteReader();

                    if (SqlReader.HasRows)
                    {
                        dt.Load(SqlReader);
                    }
                    SqlConn.Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
                SqlConn.Close();
                return null;
            }
        }
        // Issues Functions
        // Customer search issue page search by address
        public DataTable SearchCustomer1(string Address)
        {
            DataTable dt = new DataTable();
            SqlDataReader SqlReader;

            try
            {
                SqlStr.Connection = SqlConn;
                SqlStmt = "Select * from Customer where Address like '%" + Address + "%'";

                using (SqlStr = new SqlCommand(SqlStmt, SqlConn))
                {
                    SqlConn.Open();
                    SqlReader = SqlStr.ExecuteReader();

                    if (SqlReader.HasRows)
                    {
                        dt.Load(SqlReader);
                    }
                    SqlConn.Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
                SqlConn.Close();
                return null;
            }
        }
        // Movies Search Issue page
        public DataTable SearchMovie1(string Title)
        {
            DataTable dt = new DataTable();
            SqlDataReader SqlReader;

            try
            {
                SqlStr.Connection = SqlConn;
                SqlStmt = "Select * from Movies where Title like '%" + Title + "%'";

                using (SqlStr = new SqlCommand(SqlStmt, SqlConn))
                {
                    SqlConn.Open();
                    SqlReader = SqlStr.ExecuteReader();

                    if (SqlReader.HasRows)
                    {
                        dt.Load(SqlReader);
                    }
                    SqlConn.Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
                SqlConn.Close();
                return null;
            }
        }
        // Select Customer for issue updates datagrid to all current and previously rented movies
        public DataTable Issued(int CustID)
        {
            DataTable dt = new DataTable();
            SqlDataReader SqlReader;

            try
            {
                SqlStr.Connection = SqlConn;
                SqlStmt = "Select FirstName, LastName, Address, Title, RMID, DateRented, DateReturned " +
                    "from Customer c INNER JOIN RentedMovies rm on c.CustID = rm.CustIDFK INNER JOIN Movies m on m.MovieID = rm.MovieIDFK where CustID = " + CustID + "order by DateRented desc";

                using (SqlStr = new SqlCommand(SqlStmt, SqlConn))
                {
                    SqlConn.Open();
                    SqlReader = SqlStr.ExecuteReader();

                    if (SqlReader.HasRows)
                    {
                        dt.Load(SqlReader);
                    }
                    SqlConn.Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
                SqlConn.Close();
                return null;
            }
        }
        // Issue Movies to Customer
        public bool IssueMovie(string MovieID, string CustID, DateTime DateTime)
        {
            bool IssueMovie = false;

            try
            {
                SqlStr.Connection = SqlConn;
                SqlStmt = "Insert into RentedMovies(MovieIDFK,CustIDFK,DateRented) values(@MovieIDFK, @CustIDFK, @DateRented)";

                using (SqlStr = new SqlCommand(SqlStmt, SqlConn))
                {
                    SqlStr.Parameters.AddWithValue("@MovieIDFK", MovieID);
                    SqlStr.Parameters.AddWithValue("@CustIDFK", CustID);
                    SqlStr.Parameters.AddWithValue("@DateRented", DateTime.Now);

                    SqlStr.CommandText = SqlStmt;

                    SqlConn.Open();
                    int rowsadded = SqlStr.ExecuteNonQuery();

                    if (rowsadded > 0)
                    {
                        IssueMovie = true;
                    }
                    SqlConn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
                SqlConn.Close();
            }
            return IssueMovie;
        }
        // Return Movie
        public bool ReturnMovie(string RMID, DateTime DateTime)
        {
            bool ReturnMovie = false;

            try
            {
                SqlStr.Connection = SqlConn;
                SqlStmt = "Update RentedMovies set DateReturned = @DateReturned where RMID = @RMID;";
                


                using (SqlStr = new SqlCommand(SqlStmt, SqlConn))
                {
                    SqlStr.Parameters.AddWithValue("@DateReturned", DateTime.Now);
                    SqlStr.Parameters.AddWithValue("@RMID", RMID);
                    SqlStr.CommandText = SqlStmt;

                    SqlConn.Open();
                    int rowsadded = SqlStr.ExecuteNonQuery();

                    if (rowsadded > 0)
                    {
                        ReturnMovie = true;
                    }
                    SqlConn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
                SqlConn.Close();
            }
            return ReturnMovie;
        }
        // Stats Page data
        public DataTable Stats()
        {
            DataTable dt = new DataTable();
            SqlDataReader SqlReader;

            try
            {
                SqlStr.Connection = SqlConn;
                SqlStmt = "select * from PopularVideo";

                using (SqlStr = new SqlCommand(SqlStmt, SqlConn))
                {
                    SqlConn.Open();
                    SqlReader = SqlStr.ExecuteReader();

                    if (SqlReader.HasRows)
                    {
                        dt.Load(SqlReader);
                    }
                    SqlConn.Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
                SqlConn.Close();
                return null;
            }
        }
        public DataTable BestCustomer()
        {
            DataTable dt = new DataTable();
            SqlDataReader SqlReader;

            try
            {
                SqlStr.Connection = SqlConn;
                SqlStmt = "select * from PopularCustomer";

                using (SqlStr = new SqlCommand(SqlStmt, SqlConn))
                {
                    SqlConn.Open();
                    SqlReader = SqlStr.ExecuteReader();

                    if (SqlReader.HasRows)
                    {
                        dt.Load(SqlReader);
                    }
                    SqlConn.Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
                SqlConn.Close();
                return null;
            }
        }
    }
}