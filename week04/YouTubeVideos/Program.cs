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
        Video video5 = new Video("Video 5", "Group5", 200);
        Video video6 = new Video("Video 6", "Group6", 220);
        Video video7 = new Video("Video 7", "Group7", 150);
        Video video8 = new Video("Video 8", "Group8", 175);
        Video video9 = new Video("Video 9", "Group9", 190);

        Comment commentvideo1a = new Comment("Jose", "This is a string?");
        Comment commentvideo1b = new Comment("Jaryne", "This is a string?");

        Comment commentvideo2a = new Comment("Lilly", "This is a string?");
        Comment commentvideo2b = new Comment("Cristian", "This is a string?");

        Comment commentvideo3a = new Comment("LillAlexy", "This is a string?");
        Comment commentvideo3b = new Comment("Alexander", "This is a string?");

        Comment commentvideo4a = new Comment("Michael", "Nice video!");
        Comment commentvideo4b = new Comment("Sophie", "I learned a lot!");

        Comment commentvideo5a = new Comment("Daniel", "Very informative.");
        Comment commentvideo5b = new Comment("Emma", "Great content!");

        Comment commentvideo6a = new Comment("Carlos", "I enjoyed watching this.");
        Comment commentvideo6b = new Comment("Sarah", "This was super helpful!");

        Comment commentvideo7a = new Comment("Brian", "Cool video, thanks!");
        Comment commentvideo7b = new Comment("Megan", "I didn't know that before!");

        Comment commentvideo8a = new Comment("Felix", "Awesome explanations!");
        Comment commentvideo8b = new Comment("Nina", "Loved the visuals!");

        Comment commentvideo9a = new Comment("Oscar", "This content is gold!");
        Comment commentvideo9b = new Comment("Laura", "I'm sharing this with my friends!");

        video1.AddComment(commentvideo1a);
        video1.AddComment(commentvideo1b);

        video2.AddComment(commentvideo2a);
        video2.AddComment(commentvideo2b);

        video3.AddComment(commentvideo3a);
        video3.AddComment(commentvideo3b);

        video4.AddComment(commentvideo4a);
        video4.AddComment(commentvideo4b);

        video5.AddComment(commentvideo5a);
        video5.AddComment(commentvideo5b);

        video6.AddComment(commentvideo6a);
        video6.AddComment(commentvideo6b);

        video7.AddComment(commentvideo7a);
        video7.AddComment(commentvideo7b);

        video8.AddComment(commentvideo8a);
        video8.AddComment(commentvideo8b);

        video9.AddComment(commentvideo9a);
        video9.AddComment(commentvideo9b);

        video1.DisplayInfo();
        video2.DisplayInfo();
        video3.DisplayInfo();
        video4.DisplayInfo();
        video5.DisplayInfo();
        video6.DisplayInfo();
        video7.DisplayInfo();
        video8.DisplayInfo();
        video9.DisplayInfo();
    }
}
