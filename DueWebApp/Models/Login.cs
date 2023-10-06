namespace DueWebApp.Models
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public Login(string email, string passsword)
        {
            this.Email = email;
            this.Password = passsword;
        }
        public Login()
        {
        }
       
    }
}
