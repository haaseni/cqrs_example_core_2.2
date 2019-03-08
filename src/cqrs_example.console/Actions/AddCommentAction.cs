using cqrs_example.console.Interfaces;
using cqrs_example.dapper;
using cqrs_example.dapper.Commands;
using cqrs_example.dapper.Commands.Handlers;

namespace cqrs_example.console.Actions
{
    public class AddCommentAction : IAction
    {
        private readonly CommentCommandHandler _commentCommandHandler;
        private readonly CommentQueryRepository _commentQueryRepository;

        public AddCommentAction()
        {
            _commentCommandHandler = new CommentCommandHandler(new CommentCommandRepository());
            _commentQueryRepository = new CommentQueryRepository();
        }

        public void ExecuteAction()
        {
            var id = Ask.PostId();
            var text = Ask.CommentText();

            _commentCommandHandler.Handle(new AddComment { PostId = id, Text = text });

            var comments = _commentQueryRepository.GetAll(id);
            Write.Comments(comments);
        }
    }
}
