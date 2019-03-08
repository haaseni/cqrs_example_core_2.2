using cqrs_example.dapper.Interfaces;

namespace cqrs_example.dapper.Commands
{
    public class DeleteComment : ICommand
    {
        public int Id { get; set; }

        public int PostId { get; set; }
    }
}
