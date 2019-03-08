using cqrs_example.console.Interfaces;

namespace cqrs_example.console.Actions
{
    public class NoUpdateForCommentAction : IAction
    {
        public void ExecuteAction()
        {
            Write.NoUpdateForComment();
            Program.BeginQuestions();
        }
    }
}
