using System;
using System.Linq;

namespace cqrs_example.console
{
    public class Ask
    {
        public static string Action()
        {
            var action = "";

            Console.WriteLine("\nType an action [a] Add [u] Update [d] Delete [s] Show [x] Exit:");
            action = Console.ReadKey().KeyChar.ToString().ToLower();
            
            return action;
        }

        public static string PostOrComment()
        {
            Console.WriteLine("\nType [p] for post or [c] for comment:");
            var postOrComment = Console.ReadKey().KeyChar.ToString().ToLower();
            
            return postOrComment;
        }

        public static string PostTitle()
        {
            Console.WriteLine("\nType the post's new title:");
            var value = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(value))
                PostTitle();

            return value;
        }

        public static string PostText()
        {
            Console.WriteLine("\nType the post's new text:");
            var value = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(value))
                PostText();

            return value;
        }

        public static int PostId()
        {
            Console.WriteLine("\nType post ID:");
            var value = Console.ReadLine();
            int postId;

            if (!int.TryParse(value, out postId))
                PostId();

            return postId;
        }

        public static string CommentText()
        {
            Console.WriteLine("\nType the comment's text:");
            var value = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(value))
                CommentText();

            return value;
        }

        public static int CommentId()
        {
            Console.WriteLine("\nType comment ID:");
            var value = Console.ReadLine();
            int commentId;

            if (!int.TryParse(value, out commentId))
                CommentId();

            return commentId;
        }
    }
}
