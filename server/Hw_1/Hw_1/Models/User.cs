using Hw_1.DAL;

namespace Hw_1.Models
{
    public class User
    {
        int id;
        string name;
        string email;
        string password;
        bool isActive;
        List<User> UsersList = new List<User>();

        public User()
        {

        }
        public User(int id, string name, string email, string password, bool isActive)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            IsActive = isActive;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public bool IsActive { get => isActive; set => isActive = value; }

        public bool insert()
        {
            DBservices DB= new DBservices();
            UsersList=DB.ReadUserList();

            foreach (User U in UsersList)
            {
                if ((this.Email == U.Email))
                    return false;
            }
            
            return DB.InsertUser(this);
        }
        public List<User> read()
        {
            return UsersList;
        }

        public List<object> ReadAdminUserList()
        {

            DBservices DB = new DBservices();
            return DB.ReadAdminUserList();
        }

        public User Login()
        {
            DBservices DB = new DBservices();
            UsersList = DB.ReadUserList();

            foreach (User U in UsersList)
            {
                if ((this.Email == U.Email)&&(this.Password == U.Password))
                    return DB.LoginUser(this);
            }
            return null;
        }

        public bool Delete(int id)
        {
            for (int i = 0; i < UsersList.Count; i++)
            {
                if (UsersList[i].Id == id)
                {
                    UsersList.Remove(UsersList[i]);
                    return true;
                }

            }
            return false;
        }

        public User Upadte()
        {
            DBservices DB = new DBservices();
            UsersList = DB.ReadUserList();

            foreach (User U in UsersList)
            {
                if ((this.id == U.id))
                {
                    foreach (User User in UsersList)
                    {
                        if ((this.email == User.email) && (this.id != User.id))
                        { return null; }
                    }
                    return DB.UpdateUser(this);
                }
            }
            return null;
        }

        public bool UpdateUserIsActive(int id, bool isActive)
        {
            DBservices DB = new DBservices();
            return DB.UpdateUserIsActive(id, isActive);

        }
    }
}
