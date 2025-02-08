using System;
using System.Collections.Generic;

class Video
{
    private string _title;
    private string _author;
    private int _lengthInSeconds;
    private List<Comment> Comments;
    public Video(string title, string author, int lengthInSeconds)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
        Comments = new List<Comment>();
    }
    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }
    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_lengthInSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        foreach (var comment in Comments)
        {
            Console.WriteLine($"- {comment.CommenterName()}: {comment.Text()}");
        }
        Console.WriteLine();
    }
}