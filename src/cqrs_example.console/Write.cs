using cqrs_example.dapper.QueryModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cqrs_example.console
{
    public static class Write
    {
        public static void Posts(IEnumerable<Post> posts)
        {
            if (posts == null)
                return;
            
            foreach (var post in posts)
            {
                Console.WriteLine($"{post.Id}: {post.Title}");
            }
        }

        public static void Post(Post post, IEnumerable<Comment> comments)
        {
            if (post == null)
                return;

            Console.WriteLine($"ID: {post.Id}");
            Console.WriteLine($"Title: {post.Title}");
            Console.WriteLine($"Text: {post.Text}");

            if (comments != null && comments.Any())
            {
                Console.WriteLine("Comments:");

                foreach (var comment in comments)
                {
                    Console.WriteLine($"    Comment ID: {comment.Id}");
                    Console.WriteLine($"    Comment Text: {comment.Text}\n");
                }
            }
        }

        public static void Comment(Comment comment)
        {
            if (comment == null)
                return;

            Console.WriteLine($"Comment ID: {comment.Id}");
            Console.WriteLine($"Comment Text: {comment.Text}");
        }

        public static void Comments(IEnumerable<Comment> comments)
        {
            if (comments == null || !comments.Any())
                return;
            
            Console.WriteLine("Comments:");

            foreach (var comment in comments)
            {
                Console.WriteLine($"    Comment ID: {comment.Id}");
                Console.WriteLine($"    Comment Text: {comment.Text}\n");
            }
        }

        public static void InvalidSelection()
        {
            Console.WriteLine("\nInvalid selection. Please try again.");
        }

        public static void NoUpdateForComment()
        {
            Console.WriteLine("\nComments cannot be updated. Please try again.");
        }
    }
}
