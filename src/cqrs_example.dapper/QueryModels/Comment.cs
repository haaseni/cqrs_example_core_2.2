using System.ComponentModel.DataAnnotations;

namespace cqrs_example.dapper.QueryModels
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public int PostId { get; set; }

        public string Text { get; set; }
    }
}
