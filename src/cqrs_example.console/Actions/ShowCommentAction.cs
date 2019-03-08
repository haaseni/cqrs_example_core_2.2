using cqrs_example.console.Interfaces;
using cqrs_example.dapper;

namespace cqrs_example.console.Actions
{
    public class ShowCommentAction : IAction
    {
        private readonly CommentQueryRepository _commentRepository;

        public ShowCommentAction()
        {
            _commentRepository = new CommentQueryRepository();
        }

        public void ExecuteAction()
        {
            var id = Ask.CommentId();
            var comment = _commentRepository.GetById(id);

            Write.Comment(comment);
        }
    }
}
