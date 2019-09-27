using System.Collections.Generic;

namespace LoginWeb.Models
{
    public class UserWeb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public string Password { get; set; }

        public IEnumerable<UserWeb> GetUsers()
        {
            var users = new List<UserWeb>
            {
                new UserWeb {Id = 1, Name = "Thiago Araújo", Job = "Developer", Password = "123"},
                new UserWeb {Id = 2, Name = "Luke Skywalker", Job = "Jedi", Password = "321"},
                new UserWeb {Id = 3, Name = "Ben Kenobi", Job = "Jedi", Password = "123"},
                new UserWeb {Id = 4, Name = "Kylo Ren", Job = "Undefined", Password = "123"}
            };

            return users;
        }
    }
}
