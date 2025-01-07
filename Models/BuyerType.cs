using System.Collections.Generic;

namespace TaskAuthenticationAuthorization.Models
{
    public class BuyerType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public BuyerType()
        {
            Users = new List<User>();
        }
    }
}
