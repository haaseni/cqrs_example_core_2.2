using cqrs_example.console.Interfaces;
using cqrs_example.dapper;
using cqrs_example.dapper.Commands;
using cqrs_example.dapper.Commands.Handlers;

namespace cqrs_example.console.Actions
{
    public class DeleteCommentAction : IAction
    {
        private readonly CommentCommandHandler _commentCommandHandler;
        private readonly CommentQueryRepository _commentQueryRepository;

        public DeleteCommentAction()
        {
            _commentCommandHandler = new CommentCommandHandler(new CommentCommandRepository());
            _commentQueryRepository = new CommentQueryRepository();
        }

        public void ExecuteAction()
        {
            var id = Ask.CommentId();

            _commentCommandHandler.Handle(new DeleteComment { Id = id });

            var comments = _commentQueryRepository.GetAll(id);
            Write.Comments(comments);
        }
    }
}
