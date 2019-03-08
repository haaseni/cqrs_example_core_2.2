namespace cqrs_example.dapper.Interfaces
{
    public interface ICommandRepository
    {
        void Add(ICommand command);

        void Delete(ICommand command);
    }
}
