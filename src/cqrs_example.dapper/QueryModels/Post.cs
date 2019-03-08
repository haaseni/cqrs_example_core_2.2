using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cqrs_example.dapper.QueryModels
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
