using cqrs_example.dapper.Interfaces;

namespace cqrs_example.dapper.Commands
{
    public class AddPost : ICommand
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }
    }
}
