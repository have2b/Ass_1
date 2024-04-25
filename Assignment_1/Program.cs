using Assignment_1;

List<Member> members = MemberService.GenerateMembers();

while (true)
{
    // Display GUI
    DisplayGUI();
    // Choose option
    sbyte choice = ChooseOption();
    // Perform
    PerformChoice(choice);
}

void DisplayGUI()
{
    Console.WriteLine("\n==== Member management =====");
    Console.WriteLine("0. Add new member");
    Console.WriteLine("1. Find males");
    Console.WriteLine("2. Find the oldest one");
    Console.WriteLine("3. List contains Fullname only");
    Console.WriteLine("4. Return list member surrounding 2000");
    Console.WriteLine("5. Find first person who was born in Ha Noi");
    Console.WriteLine("6. Clear console");
    Console.WriteLine("7. Exit");
}

sbyte ChooseOption()
{
    // Loop until input valid
    while (true)
    {
        Console.Write("Choose option: ");
        string input = Console.ReadLine().Trim();

        // Check null or empty
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Input can't be empty");
            continue;
        }

        try
        {
            sbyte.TryParse(input, out sbyte choice);
            if (choice < 0 || choice > 7)
            {
                Console.WriteLine("Choice must between 0 and 7");
                continue;
            }
            return choice;
        }
        catch (Exception)
        {
            Console.WriteLine("Input must be a number");
        }
    }
}

void PerformChoice(sbyte choice)
{
    switch (choice)
    {
        case 0:
            // Add new member into list
            MemberService.AddMember(members);
            break;
        case 1:
            // Find males on list
            MemberService.FindMales(members);
            break;
        case 2:
            // Find the oldest one
            MemberService.FindOldestMember(members);
            break;
        case 3:
            // List full name
            MemberService.ListFullNameOnly(members);
            break;
        case 4:
            MemberService.ListMemSurroundingYear(members, 2000);
            break;
        case 5:
            MemberService.FindFirstBornInHaNoi(members);
            break;
        case 6:
            // Clear console
            Console.Clear();
            break;
        case 7:
            // Exit system
            Environment.Exit(0);
            break;
    }
}
