using System.Collections.Generic;
using System.Data.Common;
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
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }

        [Write(false)]
        public List<Role> Roles { get; set; }
        [Write(false)]
        public List<Post> Posts { get; set; }
        [Write(false)]
        public List<Category> Categories { get; set; }
    }
}