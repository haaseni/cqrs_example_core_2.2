using cqrs_example.console.Interfaces;
using cqrs_example.dapper;
using cqrs_example.dapper.Commands;
using cqrs_example.dapper.Commands.Handlers;

namespace cqrs_example.console.Actions
{
    public class AddPostAction : IAction
    {
        private readonly PostCommandHandler _postCommandHandler;
        private readonly PostQueryRepository _postQueryRepository;

        public AddPostAction()
        {
            _postCommandHandler = new PostCommandHandler(new PostCommandRepository());
            _postQueryRepository = new PostQueryRepository();
        }

        public void ExecuteAction()
        {
            var title = Ask.PostTitle();
            var text = Ask.PostText();

            _postCommandHandler.Handle(new AddPost { Title = title, Text = text});
            
            var posts = _postQueryRepository.GetAll();
            Write.Posts(posts);
        }
    }
}
