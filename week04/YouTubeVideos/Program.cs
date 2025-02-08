using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the YouTubeVideos Project.");
        Video video1 = new Video("Video 1", "Group1", 180);
        Video video2 = new Video("Video 2", "Group2", 180);
        Video video3 = new Video("Video 3", "Group3", 180);
        Video video4 = new Video("Video 4", "Group4", 180);

        Comment commentvideo1a = new Comment("Jose", "This is a string?");
        Comment commentvideo1b = new Comment("Jaryne", "This is a string?");


        Comment commentvideo2a = new Comment("Lilly", "This is a string?");
        Comment commentvideo2b = new Comment("Cristian", "This is a string?");

        video1.AddComment(commentvideo1a);
        video1.AddComment(commentvideo1b);

        video2.AddComment(commentvideo2a);
        video2.AddComment(commentvideo2b);

        video1.DisplayInfo();
        video2.DisplayInfo();



        // alt + shit + f







    }
}