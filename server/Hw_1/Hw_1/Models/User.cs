namespace Hw_1.Models
{
    public class User
    {
        int id;
        string name;
        string email;
        string password;
        static List<User> UsersList=new List<User>();

        public User()
        {
                
        }
        public User(int id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }

        public bool insert()
        {
            foreach (User U in UsersList)
            {
                if ((this.Id == U.Id))
                    return false;
            }
            UsersList.Add(this);
            return true;
        }
        public List<User> read()
        {
            return UsersList;
        }

        public bool Delete(int id)
        {
            for (int i = 0; i < UsersList.Count; i++) 
            {  if (UsersList[i].Id == id)
                { UsersList.Remove(UsersList[i]);
                    return true;
                }

            }
            return false;
    }
}
