using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace GBE.Models {

    [Table("[Post]")]
    public class Post 
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public string Slug { get; set; }

        [Write(false)]
        public DateTime CreateDate { get; }
        
        [Write(false)]
        public DateTime LastUpdateDate { get; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }

        [Write(false)]
        public Category Category { get; set; }

        [Write(false)]
        public User Author { get; set; }
    }
}