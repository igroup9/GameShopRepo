﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Text;
using Hw_1.Models;
using System.Security.Cryptography;
using System.Xml.Linq;



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
            string cStr = configuration.GetConnectionString(conString); //לוודא מה זה PROJDB
            SqlConnection con = new SqlConnection(cStr);
            con.Open();
            return con;
        }


        //--------------------------------------------------------------------------------------------------
        // This method update a student to the student table 
        //--------------------------------------------------------------------------------------------------
        //public int Update(Game game)
        //{

        //    SqlConnection con;
        //    SqlCommand cmd;

        //    try
        //    {
        //        con = connect("myProjDB"); // create the connection
        //    }
        //    catch (Exception ex)
        //    {
        //        // write to log
        //        throw (ex);
        //    }

        //    cmd = CreateCommandWithStoredProcedure("spUpdateStudent1", con, game);             // create the command לשנות שם פרוצדורה

        //    try
        //    {
        //        int numEffected = cmd.ExecuteNonQuery(); // execute the command
        //        return numEffected;
        //    }
        //    catch (Exception ex)
        //    {
        //        // write to log
        //        throw (ex);
        //    }

        //    finally
        //    {
        //        if (con != null)
        //        {
        //            // close the db connection
        //            con.Close();
        //        }
        //    }

        //}



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
        
        //--------------------------------------------------------------------------------------------------
        // This method inserts a game to the game table 
        //--------------------------------------------------------------------------------------------------
        public int InsertGame(int appid, int id)
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
            
            paramDic.Add("@appid", appid);
            paramDic.Add("@id", id);
           




            cmd = CreateCommandWithStoredProcedureGeneral("R_SP_AddGameToUserList", con, paramDic);          // create the command לשנות את הפרוצדורה

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

       
        //SP_Delete Game From user List

        public int DeleteGame(GameRequest gameRequest)
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
            paramDic.Add("@appid", gameRequest.Appid);
            paramDic.Add("@id", gameRequest.Id);
            cmd = CreateCommandWithStoredProcedureGeneral("R_SP_DeleteGameFromList", con, paramDic);          // create the command לשנות את השם

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
        public bool InsertUser(User user)
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
            //paramDic.Add("@id", user.Id);
            paramDic.Add("@name", user.Name);
            paramDic.Add("@email", user.Email);
            paramDic.Add("@password", user.Password);

            cmd = CreateCommandWithStoredProcedureGeneral("R_SP_AddUser", con, paramDic); // create the command   
            
            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                if (numEffected > 0) 
                return true;
                else return false;
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


        //--------------------------------------------------------------------------------------------------
        // This method read all games from a DB
        //--------------------------------------------------------------------------------------------------

        public List<Game> ReadGamesList()
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

            cmd = CreateCommandWithStoredProcedureGeneral("R_SP_ReturnAllGames", con, paramDic);

            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Game game = new Game();

                game.Appid = Convert.ToInt32(dataReader["appid"]) ;
                game.Name = dataReader["name"].ToString();
                game.ReleaseDate = dataReader["releaseDate"].ToString();
                game.Price = Convert.ToDouble(dataReader["price"]);
                game.Description = dataReader["description"].ToString();
                game.Full_audio_languages = dataReader["full_audio_languages"].ToString();
                game.HeaderImage = dataReader["headerImage"].ToString();
                game.Website = dataReader["website"].ToString();
                game.Windows = dataReader["windows"].ToString();
                game.Mac = dataReader["mac"].ToString();
                game.Linux = dataReader["linux"].ToString();
                game.ScoreRank = Convert.ToInt32(dataReader["scoreRank"]);
                game.Recommendations = dataReader["recommendations"].ToString();
                game.Developers = dataReader["developers"].ToString();
                game.Categories = dataReader["categories"].ToString();
                game.Genres = dataReader["genres"].ToString();
                game.Tags = dataReader["tags"].ToString();
                game.Screenshots = dataReader["screenshots"].ToString();
                  
                gameList.Add(game);
            }
            return gameList;
        }


        //--------------------------------------------------------------------------------------------------
        // This method read user games from a DB
        //--------------------------------------------------------------------------------------------------

        public List<Game> ReadMyGamesList(int id)
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
            paramDic.Add("@id",id);


            cmd = CreateCommandWithStoredProcedureGeneral("R_SP_ReturnUserGames", con, paramDic);

            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Game game = new Game();

                game.Appid = Convert.ToInt32(dataReader["appid"]);
                game.Name = dataReader["name"].ToString();
                game.ReleaseDate = dataReader["releaseDate"].ToString();
                game.Price = Convert.ToDouble(dataReader["price"]);
                game.Description = dataReader["description"].ToString();
                game.Full_audio_languages = dataReader["full_audio_languages"].ToString();
                game.HeaderImage = dataReader["headerImage"].ToString();
                game.Website = dataReader["website"].ToString();
                game.Windows = dataReader["windows"].ToString();
                game.Mac = dataReader["mac"].ToString();
                game.Linux = dataReader["linux"].ToString();
                game.ScoreRank = Convert.ToInt32(dataReader["scoreRank"]);
                game.Recommendations = dataReader["recommendations"].ToString();
                game.Developers = dataReader["developers"].ToString();
                game.Categories = dataReader["categories"].ToString();
                game.Genres = dataReader["genres"].ToString();
                game.Tags = dataReader["tags"].ToString();
                game.Screenshots = dataReader["screenshots"].ToString();

                gameList.Add(game);
            }
            return gameList;
        }

        //--------------------------------------------------------------------------------------------------
        // This method read user Unpurchased games from a DB
        //--------------------------------------------------------------------------------------------------

        public List<Game> ReadMyUnpurchasedGamesList(int id)
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
            paramDic.Add("@id", id);


            cmd = CreateCommandWithStoredProcedureGeneral("R_SP_ReturnUnpurchasedGames", con, paramDic);

            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Game game = new Game();

                game.Appid = Convert.ToInt32(dataReader["appid"]);
                game.Name = dataReader["name"].ToString();
                game.ReleaseDate = dataReader["releaseDate"].ToString();
                game.Price = Convert.ToDouble(dataReader["price"]);
                game.Description = dataReader["description"].ToString();
                game.Full_audio_languages = dataReader["full_audio_languages"].ToString();
                game.HeaderImage = dataReader["headerImage"].ToString();
                game.Website = dataReader["website"].ToString();
                game.Windows = dataReader["windows"].ToString();
                game.Mac = dataReader["mac"].ToString();
                game.Linux = dataReader["linux"].ToString();
                game.ScoreRank = Convert.ToInt32(dataReader["scoreRank"]);
                game.Recommendations = dataReader["recommendations"].ToString();
                game.Developers = dataReader["developers"].ToString();
                game.Categories = dataReader["categories"].ToString();
                game.Genres = dataReader["genres"].ToString();
                game.Tags = dataReader["tags"].ToString();
                game.Screenshots = dataReader["screenshots"].ToString();

                gameList.Add(game);
            }
            return gameList;
        }


        //--------------------------------------------------------------------------------------------------
        // This method read user games from a DB over certian price
        //--------------------------------------------------------------------------------------------------

        public List<Game> ReadMyGamesListAbouvePrice(GameRequest gameRequest)
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
            paramDic.Add("@id", gameRequest.Id);
            paramDic.Add("@price", gameRequest.Num);


            cmd = CreateCommandWithStoredProcedureGeneral("R_SP_ReturnAbovePrice", con, paramDic);

            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Game game = new Game();

                game.Appid = Convert.ToInt32(dataReader["appid"]);
                game.Name = dataReader["name"].ToString();
                game.ReleaseDate = dataReader["releaseDate"].ToString();
                game.Price = Convert.ToDouble(dataReader["price"]);
                game.Description = dataReader["description"].ToString();
                game.Full_audio_languages = dataReader["full_audio_languages"].ToString();
                game.HeaderImage = dataReader["headerImage"].ToString();
                game.Website = dataReader["website"].ToString();
                game.Windows = dataReader["windows"].ToString();
                game.Mac = dataReader["mac"].ToString();
                game.Linux = dataReader["linux"].ToString();
                game.ScoreRank = Convert.ToInt32(dataReader["scoreRank"]);
                game.Recommendations = dataReader["recommendations"].ToString();
                game.Developers = dataReader["developers"].ToString();
                game.Categories = dataReader["categories"].ToString();
                game.Genres = dataReader["genres"].ToString();
                game.Tags = dataReader["tags"].ToString();
                game.Screenshots = dataReader["screenshots"].ToString();

                gameList.Add(game);
            }
            return gameList;
        }


        //--------------------------------------------------------------------------------------------------
        // This method read user games from a DB over certian rank score
        //--------------------------------------------------------------------------------------------------

        public List<Game> ReadMyGamesListAbouveRank(GameRequest gameRequest)
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
            paramDic.Add("@id", gameRequest.Id);
            paramDic.Add("@rank", gameRequest.Num);


            cmd = CreateCommandWithStoredProcedureGeneral("R_SP_ReturnAboveRank", con, paramDic);

            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Game game = new Game();

                game.Appid = Convert.ToInt32(dataReader["appid"]);
                game.Name = dataReader["name"].ToString();
                game.ReleaseDate = dataReader["releaseDate"].ToString();
                game.Price = Convert.ToDouble(dataReader["price"]);
                game.Description = dataReader["description"].ToString();
                game.Full_audio_languages = dataReader["full_audio_languages"].ToString();
                game.HeaderImage = dataReader["headerImage"].ToString();
                game.Website = dataReader["website"].ToString();
                game.Windows = dataReader["windows"].ToString();
                game.Mac = dataReader["mac"].ToString();
                game.Linux = dataReader["linux"].ToString();
                game.ScoreRank = Convert.ToInt32(dataReader["scoreRank"]);
                game.Recommendations = dataReader["recommendations"].ToString();
                game.Developers = dataReader["developers"].ToString();
                game.Categories = dataReader["categories"].ToString();
                game.Genres = dataReader["genres"].ToString();
                game.Tags = dataReader["tags"].ToString();
                game.Screenshots = dataReader["screenshots"].ToString();

                gameList.Add(game);
            }
            return gameList;
        }


        //--------------------------------------------------------------------------------------------------
        // This method read all users from a DB
        //--------------------------------------------------------------------------------------------------
        public List<User> ReadUserList()
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

            List<User> userList = new List<User>();

            Dictionary<string, object> paramDic = new Dictionary<string, object>();

            cmd = CreateCommandWithStoredProcedureGeneral("R_SP_ReturnAllUsers", con, paramDic);

            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                User user = new User();

                user.Id = Convert.ToInt32(dataReader["id"]);
                user.Name = dataReader["name"].ToString();
                user.Email = dataReader["email"].ToString();
                user.Password = dataReader["password"].ToString();
                user.IsActive=Convert.ToBoolean(dataReader["isActive"]);
            
                userList.Add(user);
            }
            return userList;
        }



        //--------------------------------------------------------------------------------------------------
        // This method read all users with specific data for admin from a DB
        //--------------------------------------------------------------------------------------------------
        public List<object> ReadAdminUserList()
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

            cmd = CreateCommandWithStoredProcedureGeneral("R_SP_ReturnAllUsersForAdmin", con, paramDic);

            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            List<object> listObjs = new List<object>();
            while (dataReader.Read())
            {
                listObjs.Add(new
                {
                    Id = Convert.ToInt32(dataReader["id"]),
                    Name = dataReader["name"].ToString(),
                    NumOfGames= Convert.ToInt32(dataReader["NumOfGames"]),
                    AmountOfMoneySpent = Convert.ToSingle(dataReader["AmountOfMoneySpent"]),
                    isActive = Convert.ToBoolean(dataReader["isActive"])
                });

             
            }
            return listObjs;
        }


        //--------------------------------------------------------------------------------------------------
        // This method read all Games with specific data for admin from a DB
        //--------------------------------------------------------------------------------------------------
        public List<object> ReadAdminGameList()
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

            cmd = CreateCommandWithStoredProcedureGeneral("R_SP_ReturnAllGamesForAdmin", con, paramDic);

            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            List<object> listObjs = new List<object>();
            while (dataReader.Read())
            {
                listObjs.Add(new
                {
                    Appid = Convert.ToInt32(dataReader["appid"]),
                    Name = dataReader["name"].ToString(),
                    numberOfPurchases = Convert.ToInt32(dataReader["numberOfPurchases"]),
                    amountPaidFor = Convert.ToSingle(dataReader["amountPaidFor"])
                    
                });


            }
            return listObjs;
        }


        //--------------------------------------------------------------------------------------------------
        // This method Login the user and return all of his details from a DB
        //--------------------------------------------------------------------------------------------------
        public User LoginUser(User user)
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
            paramDic.Add("@email", user.Email);
            paramDic.Add("@password", user.Password);

            cmd = CreateCommandWithStoredProcedureGeneral("R_SP_ReturnUserByEmailAndPassword", con, paramDic);

            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (dataReader.Read())
            {
                user.Id = Convert.ToInt32(dataReader["id"]);
                user.Name = dataReader["name"].ToString();
                user.Email = dataReader["email"].ToString();
                user.Password = dataReader["password"].ToString();
                user.IsActive = Convert.ToBoolean(dataReader["isActive"]);

                return user;
            }
            else
            {
                return null;
            }
        }


        //--------------------------------------------------------------------------------------------------
        // This method Update the user and return all of his new details from a DB
        //--------------------------------------------------------------------------------------------------
        public User UpdateUser(User user)
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
            //paramDic.Add("@isActive", user.IsActive);



            cmd = CreateCommandWithStoredProcedureGeneral("R_SP_UpdateUser", con, paramDic);

            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (dataReader.Read())
            {
                user.Id = Convert.ToInt32(dataReader["id"]);
                user.Name = dataReader["name"].ToString();
                user.Email = dataReader["email"].ToString();
                user.Password = dataReader["password"].ToString();
                //user.IsActive = Convert.ToBoolean(dataReader["isActive"]);
                return user;
            }
            else
            {
                return null;
            }
        }




        //--------------------------------------------------------------------------------------------------
        // This method Update the user isActive
        //--------------------------------------------------------------------------------------------------
        public bool UpdateUserIsActive(int id, bool isActive)
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
            paramDic.Add("@isActive", isActive);


            cmd = CreateCommandWithStoredProcedureGeneral("R_SP_UpdateUserIsActiveField", con, paramDic);

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                if (numEffected > 0)
                    return true;
                else return false;
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
    }
}
