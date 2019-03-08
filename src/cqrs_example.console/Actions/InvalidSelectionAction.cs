using cqrs_example.console.Interfaces;

namespace cqrs_example.console.Actions
{
    public class InvalidSelectionAction : IAction
    {
        public void ExecuteAction()
        {
            Write.InvalidSelection();
            Program.BeginQuestions();
        }
    }
}
