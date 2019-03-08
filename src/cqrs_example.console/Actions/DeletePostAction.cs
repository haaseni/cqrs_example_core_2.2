using cqrs_example.console.Interfaces;
using cqrs_example.dapper;
using cqrs_example.dapper.Commands;
using cqrs_example.dapper.Commands.Handlers;

namespace cqrs_example.console.Actions
{
    public class DeletePostAction : IAction
    {
        private readonly PostCommandHandler _postCommandHandler;
        private readonly CommentCommandHandler _commentCommandHandler;
        private readonly PostQueryRepository _postQueryRepository;

        public DeletePostAction()
        {
            _postCommandHandler = new PostCommandHandler(new PostCommandRepository());
            _commentCommandHandler = new CommentCommandHandler(new CommentCommandRepository());
            _postQueryRepository = new PostQueryRepository();
        }

        public void ExecuteAction()
        {
            var id = Ask.PostId();

            _commentCommandHandler.Handle(new DeletePostComments { PostId = id });
            _postCommandHandler.Handle(new DeletePost { Id = id });

            var posts = _postQueryRepository.GetAll();
            Write.Posts(posts);
        }
    }
}
