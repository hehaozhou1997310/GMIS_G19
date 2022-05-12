using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;        //for generating a MessageBox upon encountering an error


namespace GMIS_G19
{
    abstract class Agency
    {
        private static bool reportingErrors = false;

        //Get database access
        private const string db = "gmis";
        private const string user = "gmis";
        private const string pass = "gmis";
        private const string server = "alacritas.cis.utas.edu.au";

        private static MySqlConnection conn = null;

        //Converting strings to Enums
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        
        // Creates and returns (but does not open) the connection to the database.
        private static MySqlConnection GetConnection()
        {
            if (conn == null)
            {
                string connectionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}", db, server, user, pass);
                conn = new MySqlConnection(connectionString);
            }
            return conn;
        }

        public static List<Class> LoadAll()
        {
            List<Class> student = new List<Class>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select class_id, group_id, day, start, end, room from class", conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //Note that in your assignment you will need to inspect the *type* of the
                    //class/student before deciding which kind of concrete class to create.
                    student.Add(new Class { 
                        Class_id = rdr.GetInt32(0), 
                        Group_id = rdr.GetInt32(1),
                        Day = ParseEnum<Day>(rdr.GetString(2)),
                        Start = rdr.GetString(3),
                        End = rdr.GetString(3),
                        Room = rdr.GetString(4) + " " + rdr.GetString(5) });
                }
            }
            catch (MySqlException e)
            {
                ReportError("loading class", e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return student;
        }

        public static List<Class> LoadClass(int id)
        {
            List<Class> work = new List<Class>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select class_id, group_id, day, start, end, room " +
                                                    "from class as pub, student as respub " +
                                                    "where pub.group_id=respub.group_id and student_id=?id", conn);

                cmd.Parameters.AddWithValue("id", id);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    work.Add(new Class
                    {
                        Class_id = rdr.GetInt32(0),
                        Group_id = rdr.GetInt32(1),
                        Day = ParseEnum<Day>(rdr.GetString(2)),
                        Start = rdr.GetString(3),
                        End = rdr.GetString(3),
                        Room = rdr.GetString(4)
                    });
                }
            }
            catch (MySqlException e)
            {
                ReportError("loading classes", e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return work;
        }

        public static List<StudentGroup> LoadAllStudentGroup()
        {
            List<StudentGroup> student = new List<StudentGroup>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select group_id, group_name from studentgroup", conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    student.Add(new StudentGroup
                    {
                        Group_id = rdr.GetInt32(0),
                        Group_name = rdr.GetString(1) + " " + rdr.GetString(2)
                    });
                }
            }
            catch (MySqlException e)
            {
                ReportError("loading studentgroup", e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return student;
        }

        public static List<StudentGroup> LoadStudentGroup(int id)
        {
            List<StudentGroup> work = new List<StudentGroup>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select group_id, group_name from studentgroup as pub, student as respub " +
                                                    "where pub.group_id=respub.group_id and student_id=?id", conn);

                cmd.Parameters.AddWithValue("id", id);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    work.Add(new StudentGroup
                    {
                        Group_id = rdr.GetInt32(0),
                        Group_name = rdr.GetString(1) + " " + rdr.GetString(2)
                    });
                }
            }
            catch (MySqlException e)
            {
                ReportError("loading studentgroups", e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return work;
        }



            public static List<Meeting> LoadAllMeeting()
        {
            List<Meeting> student = new List<Meeting>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select meeting_id, group_id, day, start, end, room from class", conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //Note that in your assignment you will need to inspect the *type* of the
                    //class/student before deciding which kind of concrete class to create.
                    student.Add(new Meeting
                    {
                        Meeting_id = rdr.GetInt32(0),
                        Group_id = rdr.GetInt32(1),
                        Day = ParseEnum<Day>(rdr.GetString(2)),
                        Start = rdr.GetString(3),
                        End = rdr.GetString(3),
                        Room = rdr.GetString(4) + " " + rdr.GetString(5)
                    });
                }
            }
            catch (MySqlException e)
            {
                ReportError("loading meeting", e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return student;
        }


        public static List<Meeting> LoadMeeting(int id)
        {
            List<Meeting> work = new List<Meeting>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select meeting_id, group_id, day, start, end, room " +
                                                    "from meeting as pub, student as respub " +
                                                    "where pub.group_id=respub.group_id and student_id=?id", conn);

                cmd.Parameters.AddWithValue("id", id);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    work.Add(new Meeting
                    {
                        Meeting_id = rdr.GetInt32(0),
                        Group_id = rdr.GetInt32(1),
                        Day = ParseEnum<Day>(rdr.GetString(2)),
                        Start = rdr.GetString(3),
                        End = rdr.GetString(3),
                        Room = rdr.GetString(4)
                    });
                }
            }
            catch (MySqlException e)
            {
                ReportError("loading meetinges", e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return work;

        }
        
        


        private static void ReportError(string msg, Exception e)
        {
            if (reportingErrors)
            {
                MessageBox.Show("An error occurred while " + msg + ". Try again later.\n\nError Details:\n" + e,
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}