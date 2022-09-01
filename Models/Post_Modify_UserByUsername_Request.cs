
namespace TesteAPINuri.Models
{
    public class Post_Modify_UserByUsername_Request
    {
        public long id { get; set; }
      
        public string username { get; set; }
     
        public string firstName { get; set; }
        
        public string lastName { get; set; }
       
        public string email { get; set; }
    
        public string password { get; set; }
     
        public string phone { get; set; }

        public int userStatus { get; set; }
    }
}
