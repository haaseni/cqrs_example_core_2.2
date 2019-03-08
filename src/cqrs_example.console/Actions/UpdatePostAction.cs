using System.Collections.Generic;
using cqrs_example.console.Interfaces;
using cqrs_example.dapper;
using cqrs_example.dapper.Commands;
using cqrs_example.dapper.Commands.Handlers;
using cqrs_example.dapper.QueryModels;

namespace cqrs_example.console.Actions
{
    public class UpdatePostAction : IAction
    {
        private readonly PostCommandHandler _postCommandHandler;
        private readonly PostQueryRepository _postQueryRepository;
        private readonly CommentQueryRepository _commentQueryRepository;

        public UpdatePostAction()
        {
            _postCommandHandler = new PostCommandHandler(new PostCommandRepository());
            _postQueryRepository = new PostQueryRepository();
            _commentQueryRepository = new CommentQueryRepository();
        }

        public void ExecuteAction()
        {
            var id = Ask.PostId();
            var title = Ask.PostTitle();
            var text = Ask.PostText();

            _postCommandHandler.Handle(new UpdatePost { Id = id, Title = title, Text = text });

            var post = _postQueryRepository.GetById(id);
            IEnumerable<Comment> comments = null;

            if (post != null)
                comments = _commentQueryRepository.GetAll(post.Id);
            
            Write.Post(post, comments);
        }
    }
}
