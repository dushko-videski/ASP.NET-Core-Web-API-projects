using System.Collections.Generic;

namespace DomainModels
{
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        public IEnumerable<ToDo> Tasks { get; set; }

    }
}
