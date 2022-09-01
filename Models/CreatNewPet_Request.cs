using System.Collections.Generic;

namespace TesteAPINuri.Models
{
    public class CreatNewPet_Request
    {
        public int id { get; set; }
        public Category category { get; set; }
        public string name { get; set; }
        public string[] photoUrls { get; set; }
        public List<Tags> tags { get; set; }
        public string status { get; set; }
    }

    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Tags
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
