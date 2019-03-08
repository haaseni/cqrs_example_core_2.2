using cqrs_example.console.Actions;
using cqrs_example.console.Interfaces;
using Action = cqrs_example.console.Structs.Action;
using Type = cqrs_example.console.Structs.Type;

namespace cqrs_example.console
{
    public class ActionFactory
    {
        public IAction Create(string action, string type)
        {
            switch (action.ToLower())
            {
                case Action.Add:
                    if (type.ToLower() == Type.Post)
                        return new AddPostAction();
                    else if (type.ToLower() == Type.Comment)
                        return new AddCommentAction();
                    else
                        return new InvalidSelectionAction();
                case Action.Update:
                    if (type.ToLower() == Type.Post)
                        return new UpdatePostAction();
                    else if (type.ToLower() == Type.Comment)
                        return new NoUpdateForCommentAction();
                    else
                        return new InvalidSelectionAction();
                case Action.Delete:
                    if (type.ToLower() == Type.Post)
                        return new DeletePostAction();
                    else if (type.ToLower() == Type.Comment)
                        return new DeleteCommentAction();
                    else
                        return new InvalidSelectionAction();
                case Action.Show:
                    if (type.ToLower() == Type.Post)
                        return new ShowPostAction();
                    else if (type.ToLower() == Type.Comment)
                        return new ShowCommentAction();
                    else
                        return new InvalidSelectionAction();
                default:
                    return new InvalidSelectionAction();
            }
        }
    }
}
