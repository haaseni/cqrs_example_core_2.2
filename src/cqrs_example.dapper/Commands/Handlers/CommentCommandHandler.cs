using cqrs_example.dapper.Interfaces;

namespace cqrs_example.dapper.Commands.Handlers
{
    public class CommentCommandHandler : ICommandHandler<AddComment>,
                                      ICommandHandler<DeleteComment>
    {
        private CommentCommandRepository repository;

        public CommentCommandHandler(CommentCommandRepository repository)
        {
            this.repository = repository;
        }

        public void Handle(AddComment command)
        {
            repository.Add(command);
        }

        public void Handle(DeletePostComments command)
        {

            repository.DeleteAllForPost(command);
        }

        public void Handle(DeleteComment command)
        {
            
            repository.Delete(command);
        }
    }
}
