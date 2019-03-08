using cqrs_example.dapper;
using System;
using Action = cqrs_example.console.Structs.Action;

namespace cqrs_example.console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var postQueryRepository = new PostQueryRepository();
            var posts = postQueryRepository.GetAll();

            Write.Posts(posts);

            BeginQuestions();
        }

        public static void BeginQuestions()
        {
            var actionSelection = Ask.Action();

            if (actionSelection == Action.Exit)
                Environment.Exit(-1);

            var typeSelection = Ask.PostOrComment();
            var action = new ActionFactory().Create(actionSelection, typeSelection);

            action?.ExecuteAction();
            BeginQuestions();
        }
    }
}
