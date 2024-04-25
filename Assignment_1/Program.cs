using Assignment_1;

List<Member> members = MemberService.generateMembers();

while (true)
{
    // Display GUI
    displayGUI();
    // Choose option
    sbyte choice = chooseOption();
    // Perform
    performChoice(choice);
}

void displayGUI()
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

sbyte chooseOption()
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
            sbyte choice = SByte.Parse(input);
            if (choice < 0 || choice > 7)
            {
                Console.WriteLine("Choice must between 0 and 7");
            }
            return choice;
        }
        catch (Exception)
        {
            Console.WriteLine("Input must be a number");
        }
    }
}

void performChoice(sbyte choice)
{
    switch (choice)
    {
        case 0:
            // Add new member into list
            MemberService.addMember(members);
            break;
        case 1:
            // Find males on list
            MemberService.findMales(members);
            break;
        case 2:
            // Find the oldest one
            MemberService.findOldest(members);
            break;
        case 3:
            // List full name
            MemberService.listFullNameOnly(members);
            break;
        case 4:
            MemberService.listMemSurroundingYear(members, 2000);
            break;
        case 5:
            MemberService.findFirstBornInHaNoi(members);
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
