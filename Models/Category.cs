using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace GBE.Models {
    
    [Table("[Category]")]
    public class Category 
    {
        public Category () {
            Posts = new List<Post>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public IList<Post> Posts { get; set; }
    }
}