using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace GBE.Models
{
    [Table("[User]")]
    public class User 
    {
        public User() 
        { 
            Roles = new List<Role>();
            Posts = new List<Post>();
        }

        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }
        public List<Role> Roles { get; set; }
        public IList<Post> Posts { get; set; }
        public List<Category> Categories { get; set; }
    }
}