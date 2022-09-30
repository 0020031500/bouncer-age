Random random = new Random();
int queueLength = random.Next(5, 15);
int currentQueueLength = queueLength;

string[] possibleBribes = { "a bar of chocolate", "a drink", "a burger", "a pizza", "some food", ""};

List<string> output = new List<string>();

static string GenerateName()
{
    Random r = new Random();
    string[] maleNames = { "Brian", "Ted", "Tom", "Jake", "Jamie", "Ben", "Ned", "Kit", "Aaron", "Adam", "Simon", "David", "John", "Josh" };
    string[] femaleNames = { "Abby", "Kate", "Brooke", "Belle", "Eva", "Hannah", "Alexanda", "Louise", "Martha", "Veronica", "Heather" };

    string[] possible = { "male", "female" };

    return possible[r.Next(0, 2)] == "male"? maleNames[r.Next(0, maleNames.Length)] : femaleNames[r.Next(0, femaleNames.Length)];


}

while (currentQueueLength > 0)
{
    if (currentQueueLength != queueLength)
    {
        Console.WriteLine("The queue is now " + currentQueueLength + " people long.");
    }
    else
    {
        Console.WriteLine($"There are {currentQueueLength} people in the queue!");
    }

    string name = GenerateName();

    Console.WriteLine($"How old are you, {name}?");
    
    int age = int.Parse(Console.ReadLine());

    if (age >= 18)
    {
        Console.WriteLine($"Welcome to the club!");
        output.Add($"{name} is {age}, so I let them in!");
    }
    else if (age >= 16)
    {
        string bribe = possibleBribes[random.Next(0, possibleBribes.Length)];
        Console.WriteLine($"You aren't old enough, but you can bribe me {bribe}!");
        Console.WriteLine("Do you want to bribe me? (y/n)");
        string answer = Console.ReadLine();
        if (answer == "y" || answer == "Y")
        {
            Console.WriteLine("Welcome in my friend!");
            output.Add($"{name} is definitely 18 and not {age}, so I let them in!");
        }
        else
        {
            Console.WriteLine("Alright, you can't come in then!");
            output.Add($"{name} is {age}, so I did not let them in.");
        }
    }
    else
    {
        Console.WriteLine("You are not old enough to enter the queue!");
        output.Add($"{name} is {age}, so I did not let them in.");
    }
    currentQueueLength--;
    
    Thread.Sleep(1000);
  
    
    Console.Clear();
}

if (currentQueueLength == 0)
{
    Console.Clear();
    Console.WriteLine("The queue is now empty!");
    Console.WriteLine($"Here are the results: \n\n{string.Join("\n", output.ToArray())}");
    Console.ReadLine();
}
else
{
    Console.Clear();
    Console.WriteLine("A fatal error has occured!");
}
