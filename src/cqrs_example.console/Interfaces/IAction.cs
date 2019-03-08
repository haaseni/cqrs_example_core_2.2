using cqrs_example.dapper;

namespace cqrs_example.console.Interfaces
{
    public interface IAction
    {
        void ExecuteAction();
    }
}
