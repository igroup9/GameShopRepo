using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Text;
using Hw_1.Models;



namespace Hw_1.DAL
{
 

    /// <summary>
    /// DBServices is a class created by me to provides some DataBase Services
    /// </summary>
    public class DBservices
    {

        public DBservices()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //--------------------------------------------------------------------------------------------------
        // This method creates a connection to the database according to the connectionString name in the web.config 
        //--------------------------------------------------------------------------------------------------
        public SqlConnection connect(String conString)
        {

            // read the connection string from the configuration file
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json").Build();
            string cStr = configuration.GetConnectionString("myProjDB"); //לוודא מה זה PROJDB
            SqlConnection con = new SqlConnection(cStr);
            con.Open();
            return con;
        }


        //--------------------------------------------------------------------------------------------------
        // This method update a student to the student table 
        //--------------------------------------------------------------------------------------------------
        public int Update(Game game)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("myProjDB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            cmd = CreateCommandWithStoredProcedure("spUpdateStudent1", con, game);             // create the command לשנות שם פרוצדורה

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }



        //---------------------------------------------------------------------------------
        // Create the SqlCommand using a stored procedure
        //---------------------------------------------------------------------------------
        private SqlCommand CreateCommandWithStoredProcedure(String spName, SqlConnection con, Game game)
        {

            SqlCommand cmd = new SqlCommand(); // create the command object

            cmd.Connection = con;              // assign the connection to the command object

            cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

            cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

            cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

            cmd.Parameters.AddWithValue("@appid", game.Appid);

            cmd.Parameters.AddWithValue("@name", game.Name);

            cmd.Parameters.AddWithValue("@releaseDate", game.ReleaseDate);

            cmd.Parameters.AddWithValue("@price", game.Price);

            cmd.Parameters.AddWithValue("@description", game.Description);

            cmd.Parameters.AddWithValue("@full_audio_languages", game.Full_audio_languages);

            cmd.Parameters.AddWithValue("@headerImage", game.HeaderImage);

            cmd.Parameters.AddWithValue("@website", game.Website);

            cmd.Parameters.AddWithValue("@windows", game.Windows);

            cmd.Parameters.AddWithValue("@mac", game.Mac);

            cmd.Parameters.AddWithValue("@linux", game.Linux);

            cmd.Parameters.AddWithValue("@scoreRank", game.ScoreRank);

            cmd.Parameters.AddWithValue("@recommendations", game.Recommendations);

            cmd.Parameters.AddWithValue("@developers", game.Developers);

            cmd.Parameters.AddWithValue("@categories", game.Categories);

            cmd.Parameters.AddWithValue("@genres", game.Genres);

            cmd.Parameters.AddWithValue("@tags", game.Tags);

            cmd.Parameters.AddWithValue("@screenshots", game.Screenshots);


            return cmd;
        }
        //SP_InsertFlight2025
        //--------------------------------------------------------------------------------------------------
        // This method inserts a game to the game table 
        //--------------------------------------------------------------------------------------------------
        public int Insert(Game game)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("myProjDB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            Dictionary<string, object> paramDic = new Dictionary<string, object>();
            
            paramDic.Add("@appid", game.Appid);
            paramDic.Add("@name", game.Name);
            paramDic.Add("@releaseDate", game.ReleaseDate);
            paramDic.Add("@price", game.Price);
            paramDic.Add("@description", game.Description);
            paramDic.Add("@full_audio_languages", game.Full_audio_languages);
            paramDic.Add("@headerImage", game.HeaderImage);
            paramDic.Add("@website", game.Website);
            paramDic.Add("@windows", game.Windows);
            paramDic.Add("@mac", game.Mac);
            paramDic.Add("@linux", game.Linux);
            paramDic.Add("@scoreRank", game.ScoreRank);
            paramDic.Add("@recommendations", game.Recommendations);
            paramDic.Add("@developers", game.Developers);
            paramDic.Add("@categories", game.Categories);
            paramDic.Add("@genres", game.Genres);
            paramDic.Add("@tags", game.Tags);
            paramDic.Add("@screenshots", game.Screenshots);




            cmd = CreateCommandWithStoredProcedureGeneral("SP_InsertFlight2025", con, paramDic);          // create the command לשנות את הפרוצדורה

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }

        //SP_DeleteFlight2025

        public int Delete(int id)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("myProjDB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            Dictionary<string, object> paramDic = new Dictionary<string, object>();
            paramDic.Add("@id", id);

            cmd = CreateCommandWithStoredProcedureGeneral("SP_DeleteFlight2025", con, paramDic);          // create the command לשנות את השם

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }


        //--------------------------------------------------------------------------------------------------
        // This method inserts a user to the user table 
        //--------------------------------------------------------------------------------------------------
        public int Insert(User user)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("myProjDB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            Dictionary<string, object> paramDic = new Dictionary<string, object>();
            paramDic.Add("@id", user.Id);
            paramDic.Add("@name", user.Name);
            paramDic.Add("@email", user.Email);
            paramDic.Add("@password", user.Password);

            cmd = CreateCommandWithStoredProcedureGeneral("SP_InsertStudent25", con, paramDic);          // create the command לשנות שם פרוצדורה

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }


        //---------------------------------------------------------------------------------
        // Create the SqlCommand
        //---------------------------------------------------------------------------------
        private SqlCommand CreateCommandWithStoredProcedureGeneral(String spName, SqlConnection con, Dictionary<string, object> paramDic)
        {

            SqlCommand cmd = new SqlCommand(); // create the command object

            cmd.Connection = con;              // assign the connection to the command object

            cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

            cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

            cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

            if (paramDic != null)
                foreach (KeyValuePair<string, object> param in paramDic)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);

                }


            return cmd;
        }


        // read from a table
        public List<Game> Read()
        {
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("myProjDB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            List<Game> gameList = new List<Game>();

            Dictionary<string, object> paramDic = new Dictionary<string, object>();






            cmd = CreateCommandWithStoredProcedureGeneral("SP_ReadStudent25", con, paramDic);

            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Game game = new Game();
                s.Id = Convert.ToInt32(dataReader["Id"]);
                s.Name = dataReader["Name"].ToString();
                s.Age = Convert.ToDouble(dataReader["Age"]);
                students.Add(s);

            }
            return gameList;

        }
    }

}
