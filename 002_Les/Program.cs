char a;

// Task 1

string text = "Some text";
int n = 5;
char nthChar = text[n];
Console.WriteLine($"{n}th char of text: {nthChar}");
Console.WriteLine($"Length of text: {text}");

// Task 2

string text1 = "My name is ";
string name = "Artur";
string text2 = text1 + name;
int i = 2, k = 5;
Console.WriteLine(text2.Substring(text1.Length));
Console.WriteLine(text2.Substring(0, 2));

// Task 3

string text3 = text1.Replace("My", "Your");
Console.Write("What is your name: ");
string? inputName = Console.ReadLine();
string text4 = text3 + inputName;
string cutOutName = text4[text1.Length..].Trim();
Console.WriteLine($"Upper name: {cutOutName.ToUpper()}");
Console.WriteLine($"Lower name: {cutOutName.ToLower()}");
