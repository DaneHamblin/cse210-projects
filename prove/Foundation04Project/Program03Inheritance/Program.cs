public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== EVENT PLANNING MARKETING SYSTEM ===\n");

        Address lectureAddress = new Address("123 University Ave", "Provo", "UT", "USA", "84601");
        Address receptionAddress = new Address("456 Main St", "Salt Lake City", "UT", "USA", "84101");
        Address outdoorAddress = new Address("789 Park Rd", "Boise", "ID", "USA", "83701");

        Lecture lecture = new Lecture(
            "Introduction to Artificial Intelligence",
            "Learn the fundamentals of AI and machine learning in this comprehensive lecture",
            "May 15, 2026",
            "2:00 PM",
            lectureAddress,
            "Dr. Sarah Johnson",
            150
        );

        Reception reception = new Reception(
            "Annual Networking Gala",
            "Connect with industry professionals and enjoy an evening of networking and refreshments",
            "June 20, 2026",
            "7:00 PM",
            receptionAddress,
            "rsvp@events.com"
        );

        OutdoorGathering outdoorGathering = new OutdoorGathering(
            "Summer Music Festival",
            "A day of live music, food trucks, and family-friendly activities",
            "July 4, 2026",
            "12:00 PM",
            outdoorAddress,
            "Sunny with a high of 85°F, light breeze expected"
        );

        DisplayEventMessages(lecture, "LECTURE EVENT");
        Console.WriteLine(new string('-', 60) + "\n");

        DisplayEventMessages(reception, "RECEPTION EVENT");
        Console.WriteLine(new string('-', 60) + "\n");

        DisplayEventMessages(outdoorGathering, "OUTDOOR GATHERING EVENT");
        Console.WriteLine(new string('-', 60) + "\n");
    }

    private static void DisplayEventMessages(Event eventItem, string eventTypeLabel)
    {
        Console.WriteLine($"=== {eventTypeLabel} ===\n");
        
        Console.WriteLine("STANDARD DETAILS:");
        Console.WriteLine(eventItem.GetStandardDetails());
        Console.WriteLine();
        
        Console.WriteLine("FULL DETAILS:");
        Console.WriteLine(eventItem.GetFullDetails());
        Console.WriteLine();
        
        Console.WriteLine("SHORT DESCRIPTION:");
        Console.WriteLine(eventItem.GetShortDescription());
        Console.WriteLine();
    }
}