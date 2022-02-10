using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Demo.Controllers
{
    public class UsersController : Controller
    {
        private const string LoginForm = @"
            <form action='/Login' method='POST'>
               Username: <input type='text' name='Username'/>
               Password: <input type='text' name='Password'/>
               <input type='submit' value ='Log In' /> 
            </form>";
        
        private const string Username = "admin";
        
        private const string Password = "admin";
        
        public UsersController(Request request) 
            : base(request)
        {
            
        }
        
        public Response LoginPage() => Html(LoginForm);
        
        public Response Login()
        {
            this.Request.Session.Clear();
            
            var usernameMatches = this.Request.Form["Username"] == Username;

            var passwordMatches = this.Request.Form["Password"] == Password;
            
            if (usernameMatches && passwordMatches)
            {
                if (this.Request.Session.ContainsKey(Session.SessionUserKey))
                {
                    return Html("<h3>Logged successfully!</h3>");
                }
                
                var cookies = new CookieCollection();
                
                this.Request.Session[Session.SessionUserKey] = "MyUserId";

                cookies.Add(Session.SessionCookieName, this.Request.Session.Id);
                
                return Html("<h3>Logged successfully!</h3>", cookies);
            }

            return Redirect("/Login");
        }
        
        public Response Logout()
        {
            this.Request.Session.Clear();

            return Html("<h3>Logged out successfully!</h3>");
        }

        public Response Userdata()
        {
            if (this.Request.Session.ContainsKey(Session.SessionUserKey))
            {
                return Html($"<h3>Welcome {Username}</h3>");
            }

            return Redirect("/Login");
        }
    }
}