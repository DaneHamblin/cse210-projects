using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Learning C# Programming", "TechTeacher", 600);
        video1.AddComment(new Comment("JohnDoe", "Great tutorial! Very helpful."));
        video1.AddComment(new Comment("CodeMaster", "I finally understand classes now."));
        video1.AddComment(new Comment("NewbieDev", "Thanks for explaining this clearly."));
        video1.AddComment(new Comment("SarahCoder", "Can you make a video about inheritance?"));
        videos.Add(video1);

        Video video2 = new Video("10 Tips for Better Code", "DevExpert", 450);
        video2.AddComment(new Comment("JamesW", "Tip #5 was a game changer for me."));
        video2.AddComment(new Comment("AnnaDev", "I've been doing tip #3 wrong all along."));
        video2.AddComment(new Comment("CodeNewbie", "These tips are gold! Thanks!"));
        videos.Add(video2);

        Video video3 = new Video("Understanding Object Oriented Programming", "OOPGuru", 720);
        video3.AddComment(new Comment("MikeSmith", "This made OOP click for me."));
        video3.AddComment(new Comment("JennyDev", "The examples were perfect."));
        video3.AddComment(new Comment("TomCoder", "Encapsulation finally makes sense."));
        video3.AddComment(new Comment("LisaProgram", "Best OOP explanation I've seen."));
        videos.Add(video3);

        Video video4 = new Video("Debugging Like a Pro", "DebugMaster", 540);
        video4.AddComment(new Comment("RobertK", "The breakpoint section was excellent."));
        video4.AddComment(new Comment("EmilyC", "I never knew about conditional breakpoints."));
        video4.AddComment(new Comment("DavidDev", "This saved me hours of frustration."));
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            video.DisplayComments();
            Console.WriteLine();
        }
    }
}