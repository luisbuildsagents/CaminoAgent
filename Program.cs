// CaminoAgent v0.2 - Luis's coach to Path 3
string memoryFile = "memory.txt";
string tasksFile = "tasks.txt";
string name = "Luis";
string myGoal = "pro agent builder in 1 year who creates content";

Console.WriteLine($"Hola {name}! I am Camino, your coach to become a {myGoal}.");
Console.WriteLine("Goal: Path 3 = bot you can message from your iPhone.\n");

// Load or create tasks
List<string> roadmap;
if (File.Exists(tasksFile))
{
    roadmap = File.ReadAllLines(tasksFile).Where(l => !string.IsNullOrWhiteSpace(l)).ToList();
}
else
{
    roadmap = new List<string>
    {
        "Day 1: Setup done - you ran Camino!",
        "Day 2: Edit Program.cs and change myGoal",
        "Day 3: Upgrade to v0.2 and add your own task",
        "Day 4: Build a no-code prompt agent and use it on iPhone",
        "Day 5: Save code to GitHub",
        "Day 6: Create Telegram bot token with BotFather",
        "Day 7: Ship Week 1 post"
    };
    File.WriteAllLines(tasksFile, roadmap);
}

if (File.Exists(memoryFile))
{
    var lines = File.ReadAllLines(memoryFile);
    var doneCount = lines.Count(l => l.StartsWith("DONE:"));
    Console.WriteLine($"Welcome back! You have {doneCount} wins logged.");
    string level = doneCount switch
    {
        < 3 => "Beginner",
        < 10 => "Builder",
        < 20 => "Shipper",
        _ => "Pro"
    };
    Console.WriteLine($"Your level: {level}\n");
}
else
{
    Console.WriteLine("Level: Beginner\n");
}

while (true)
{
    Console.WriteLine("What do you want?");
    Console.WriteLine("1. Get today's task");
    Console.WriteLine("2. Log what I did");
    Console.WriteLine("3. Add a new task to my roadmap");
    Console.WriteLine("4. Turn what I did into a content post");
    Console.WriteLine("5. Exit");
    Console.Write("Choose 1-5: ");
    var choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.WriteLine("\n--- TODAY'S TASK - ONE small action ---");
        var done = File.Exists(memoryFile) ? File.ReadAllText(memoryFile) : "";
        string next = roadmap.FirstOrDefault(t => !done.Contains(t)) ?? "You finished the roadmap! Time for Telegram bot - Path 3!";
        Console.WriteLine(next);
        Console.WriteLine("You have 30 minutes. Do just this.\n");
    }
    else if (choice == "2")
    {
        Console.Write("What did you finish? Type it: ");
        var what = Console.ReadLine();
        string entry = $"DONE: {DateTime.Now:yyyy-MM-dd HH:mm} - {what}{Environment.NewLine}";
        File.AppendAllText(memoryFile, entry);
        Console.WriteLine("Saved to memory.txt! Nice win, Luis.\n");
    }
    else if (choice == "3")
    {
        Console.Write("New task to add (ex: Learn Git and push to GitHub): ");
        var newTask = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newTask))
        {
            roadmap.Add(newTask);
            File.AppendAllText(tasksFile, newTask + Environment.NewLine);
            Console.WriteLine("Added to tasks.txt!\n");
        }
    }
    else if (choice == "4")
    {
        Console.Write("Paste what you did / learned: ");
        var learned = Console.ReadLine();
        Console.WriteLine("\n--- COPY THIS FOR INSTAGRAM ---");
        Console.WriteLine($"Hook: I know almost no coding and I just upgraded my first AI agent 🤯");
        Console.WriteLine($"1. What I tried: {learned}");
        Console.WriteLine($"2. What broke / surprised me: [fill 1 line]");
        Console.WriteLine($"3. What I learned: [fill 1 line]");
        Console.WriteLine($"CTA: Day 3 of becoming an agent builder. Follow for the iPhone bot.\n");
    }
    else if (choice == "5")
    {
        Console.WriteLine($"Nos vemos, {name}! Progress saved.");
        break;
    }
    else
    {
        Console.WriteLine("Type 1, 2, 3, 4 or 5.\n");
    }
}