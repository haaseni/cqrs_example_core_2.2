using cqrs_example.dapper.Interfaces;

namespace cqrs_example.dapper.Commands.Handlers
{
    public class PostCommandHandler : ICommandHandler<AddPost>,
                                      ICommandHandler<UpdatePost>,
                                      ICommandHandler<DeletePost>
    {
        private PostCommandRepository repository;

        public PostCommandHandler(PostCommandRepository repository)
        {
            this.repository = repository;
        }

        public void Handle(AddPost command)
        {
            repository.Add(command);
        }

        public void Handle(UpdatePost command)
        {
            repository.Update(command);
        }

        public void Handle(DeletePost command)
        {
            
            repository.Delete(command);
        }
    }
}
