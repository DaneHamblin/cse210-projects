using System;

class Program
{
    static void Main(string[] args)
    {
        Reference ref1 = new Reference("Proverbs", 3, 5, 6);
        string text1 = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        
        Scripture scripture = new Scripture(ref1, text1);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nAll words are hidden.");
                Console.WriteLine("Options: [u] Undo | [quit] Exit");
            }
            else
            {
                Console.WriteLine("\nOptions: [Enter] Hide words | [u] Undo | [quit] Exit");
            }
            
            string input = Console.ReadLine().ToLower();

            if (input == "quit")
            {
                break;
            }
            else if (input == "u")
            {
                scripture.UndoHide(3); 
            }
            else
            {
                if (!scripture.IsCompletelyHidden())
                {
                    scripture.HideNextWords(3);
                }
            }
        }
    }
}