using cqrs_example.dapper.Interfaces;

namespace cqrs_example.dapper.Commands
{
    public class DeletePost : ICommand
    {
        public int Id { get; set; }
    }
}
