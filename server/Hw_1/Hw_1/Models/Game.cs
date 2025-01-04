using System.Text.Json.Serialization;
using Hw_1.DAL;

namespace Hw_1.Models
{
    public class Game
    {
        int appid;
        string name;
        string releaseDate;
        double price;
        string description;
        string full_audio_languages;//new from Hw2
        string headerImage;
        string website;
        string windows; //string instead of bool
        string mac;//string instead of bool
        string linux;//string instead of bool
        int scoreRank;
        string recommendations;
        string developers;//new from Hw2
        string categories;//new from Hw2
        string genres; //new from Hw2
        string tags;//new from Hw2
        string screenshots;//new from Hw2
       // string publisher; // not in use?
         List<Game> GamesList = new List<Game>();
        public Game()
        {
                
        }

        public Game(int appid, string name, string releaseDate, double price, string description, string full_audio_languages, string headerImage, string website, string windows, string mac, string linux, int scoreRank, string recommendations, string developers, string categories, string genres, string tags, string screenshots/*, string publisher*/)
        {
            this.Appid = appid;
            this.Name = name;
            this.ReleaseDate = releaseDate;
            this.Price = price;
            this.Description = description;
            this.Full_audio_languages = full_audio_languages;
            this.HeaderImage = headerImage;
            this.Website = website;
            this.Windows = windows;
            this.Mac = mac;
            this.Linux = linux;
            this.ScoreRank = scoreRank;
            this.Recommendations = recommendations;
            this.Developers = developers;
            this.Categories = categories;
            this.Genres = genres;
            this.Tags = tags;
            this.Screenshots = screenshots;
           // this.publisher = publisher;
        }

        [JsonPropertyName("AppID")]
        public int Appid { get => appid; set => appid = value; }
        [JsonPropertyName("Name")]
        public string Name { get => name; set => name = value; }
        [JsonPropertyName("Release_date")]
        public string ReleaseDate { get => releaseDate; set => releaseDate = value; }
        [JsonPropertyName("Price")]
        public double Price { get => price; set => price = value; }
        [JsonPropertyName("description")]
        public string Description { get => description; set => description = value; }
        [JsonPropertyName("Full_audio_languages")]
        public string Full_audio_languages { get => full_audio_languages; set => full_audio_languages = value; }
        [JsonPropertyName("Header_image")]
        public string HeaderImage { get => headerImage; set => headerImage = value; }
        [JsonPropertyName("Website")]
        public string Website { get => website; set => website = value; }
        [JsonPropertyName("Windows")]
        public string Windows { get => windows; set => windows = value; }
        [JsonPropertyName("Mac")]
        public string Mac { get => mac; set => mac = value; }
        [JsonPropertyName("Linux")]
        public string Linux { get => linux; set => linux = value; }
        [JsonPropertyName("Score_rank")]
        public int ScoreRank { get => scoreRank; set => scoreRank = value; }
        [JsonPropertyName("Recommendations")]
        public string Recommendations { get => recommendations; set => recommendations = value; }
        [JsonPropertyName("Developers")]
        public string Developers { get => developers; set => developers = value; }
        [JsonPropertyName("Categories")]
        public string Categories { get => categories; set => categories = value; }
        [JsonPropertyName("Genres")]
        public string Genres { get => genres; set => genres = value; }
        [JsonPropertyName("Tags")]
        public string Tags { get => tags; set => tags = value; }
        [JsonPropertyName("Screenshots")]
        public string Screenshots { get => screenshots; set => screenshots = value; }
       // public string Publisher { get => publisher; set => publisher = value; }
        

        public bool insert(int appid,int id)
        {

            DBservices DB = new DBservices();

            
            if (DB.InsertGame(appid, id)>0)
            return true;
            else return false;
     
        }
        public List<Game> read()
        {
            DBservices allGameList = new DBservices();

            return allGameList.ReadGamesList();
        }

        public List<Game> readMyList(int id)
        {
            DBservices myGameList = new DBservices();

            return myGameList.ReadMyGamesList(id);
        }

        public List<Game> readMyUnpurchasedGames(int id)
        {
            DBservices UnpurchasedGamesList = new DBservices();

            return UnpurchasedGamesList.ReadMyUnpurchasedGamesList(id);
        }

        public List<Game> GamesAbovePrice(GameRequest gameRequest)
        {
            DBservices myGameList = new DBservices();
            return myGameList.ReadMyGamesListAbouvePrice(gameRequest);
        }

        public List<Game> GamesAboveRankScore(GameRequest gameRequest)
        {
            DBservices tempGamesList = new DBservices();
            return tempGamesList.ReadMyGamesListAbouveRank(gameRequest);
        }

        public bool DeleteById(GameRequest gameRequest)
        {
            DBservices DB = new DBservices();
            if (DB.DeleteGame(gameRequest) > 0)
                return true;
            else 
                return false;
        }




    }
}
