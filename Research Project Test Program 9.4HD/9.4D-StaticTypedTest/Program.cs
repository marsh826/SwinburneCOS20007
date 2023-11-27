// See https://aka.ms/new-console-template for more information
var watch = new System.Diagnostics.Stopwatch();
watch.Start();

static void example1()
{
    ///Example 1: Adding strings
    string message2 = " to the cowboys";
    string message = "Friendly hello hi";
    string output = message + message2;
    Console.WriteLine(output);
}

static void example2()
{
    ///Example 2: Adding ints
    int x = 10;

    ///Case 1: adding string to int and output as int
    //string y = "Guava";

    ///Case 2: adding int to int and output as int
    int y = 20;

    int sum = x + y;
    Console.WriteLine(sum);
}

example1();
example2();

watch.Stop();
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

