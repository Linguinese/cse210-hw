using System;
using System.Collections.Generic;

namespace Foundation1
{
    // Class to represent a comment on a video
    public class Comment
    {
        public string CommenterName { get; set; }
        public string Text { get; set; }

        public Comment(string commenterName, string text)
        {
            CommenterName = commenterName;
            Text = text;
        }
    }

    // Class to represent a YouTube video
    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Length { get; set; } // Length in seconds
        private List<Comment> comments;

        public Video(string title, string author, int length)
        {
            Title = title;
            Author = author;
            Length = length;
            comments = new List<Comment>();
        }

        // Method to add a comment to the video
        public void AddComment(Comment comment)
        {
            comments.Add(comment);
        }

        // Method to get the number of comments
        public int GetNumberOfComments()
        {
            return comments.Count;
        }

        // Method to get all comments
        public List<Comment> GetComments()
        {
            return comments;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a list to hold videos
            List<Video> videos = new List<Video>();

            // Create some video objects
            Video video1 = new Video("Learning C# Programming", "John Doe", 300);
            video1.AddComment(new Comment("Alice", "Great tutorial!"));
            video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
            video1.AddComment(new Comment("Charlie", "I learned a lot."));
            
            Video video2 = new Video("Understanding OOP Concepts", "Jane Smith", 450);
            video2.AddComment(new Comment("David", "This is so clear and concise!"));
            video2.AddComment(new Comment("Eve", "I wish I found this sooner."));
            video2.AddComment(new Comment("Frank", "Excellent explanation!"));

            Video video3 = new Video("Advanced C# Techniques", "Alice Johnson", 600);
            video3.AddComment(new Comment("Grace", "I love the examples you provided."));
            video3.AddComment(new Comment("Heidi", "Can you do a follow-up on this?"));
            
            // Add videos to the list
            videos.Add(video1);
            videos.Add(video2);
            videos.Add(video3);

            // Display video information
            foreach (var video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.Length} seconds");
                Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
                Console.WriteLine("Comments:");
                
                foreach (var comment in video.GetComments())
                {
                    Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
                }
                
                Console.WriteLine(); // Blank line for better readability
            }
        }
    }
}