using cqrs_example.dapper.Interfaces;

namespace cqrs_example.dapper.Commands
{
    public class AddComment : ICommand
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public string Text { get; set; }
    }
}
