using cqrs_example.console.Interfaces;
using cqrs_example.dapper;

namespace cqrs_example.console.Actions
{
    public class ShowPostAction : IAction
    {
        private readonly PostQueryRepository _postRepository;
        private readonly CommentQueryRepository _commentRepository;

        public ShowPostAction()
        {
            _postRepository = new PostQueryRepository();
            _commentRepository = new CommentQueryRepository();
        }

        public void ExecuteAction()
        {
            var id = Ask.PostId();
            var post = _postRepository.GetById(id);
            var comments = _commentRepository.GetAll(id);

            Write.Post(post, comments);
        }
    }
}
