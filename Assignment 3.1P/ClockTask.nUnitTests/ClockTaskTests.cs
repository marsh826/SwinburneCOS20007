namespace ClockTask.nUnitTests;

public class ClockTaskTests
{
    private Counter counterOBJ { get; set; } = null!;
    private Clock clockOBJ { get; set; } = null!;

/*    i represents the number of seconds in real life to test that
    digits are incrementing correctly */
    int i; 

    [SetUp]
    public void Setup()
    {
        const string test = "counterTEST";
        counterOBJ = new Counter(test);

        Counter hourDigit1 = new Counter("hourD1");
        Counter minuteDigit1 = new Counter("minuteD1");
        Counter secondDigit1 = new Counter("secondD1");
        Counter[] digit1 = new Counter[] { hourDigit1, minuteDigit1, secondDigit1 };

        Counter hourDigit2 = new Counter("hourD1");
        Counter minuteDigit2 = new Counter("minuteD1");
        Counter secondDigit2 = new Counter("secondD1");
        Counter[] digit2 = new Counter[] { hourDigit2, minuteDigit2, secondDigit2 };

        clockOBJ = new Clock(digit1, digit2);
    }

    //-------------------Counter Class Test-------------------//
    [Test]
    public void TestCounter_StartsAt0()
    {
        var sut = counterOBJ.Ticks;
        Assert.That(sut, Is.EqualTo(0));
    }

    [Test]
    public void TestCounter_Increment()
    {
        counterOBJ.Increment();
        var sut = counterOBJ.Ticks;
        Assert.That(sut, Is.EqualTo(1));
    }

    [Test]
    public void TestCounter_MultipleIncrement()
    {
        int i = 0;
        while (i < 5)
        {
            counterOBJ.Increment();
            i++;
        }
        var sut = counterOBJ.Ticks;
        Assert.That(sut, Is.EqualTo(i));
    }

    [Test]
    public void TestCounter_Reset()
    {
        counterOBJ.Reset();
        var sut = counterOBJ.Ticks;
        Assert.That(sut, Is.EqualTo(0));
    }

    //-------------------Clock Class Test-------------------//
    [Test]
    public void TestClock_Initiate()
    {
        var initialisedTime = clockOBJ.Time;
        Assert.That(initialisedTime, Is.EqualTo("00:00:00"));
        Console.WriteLine("Expected Result:00:00:00");
        Console.WriteLine($"Given Result:{clockOBJ.Time}");
    }

    [Test] 
    public void TestClock_Tick()
    {
        clockOBJ.ClockStart();
        var clockTicked = clockOBJ.Time;
        Assert.That(clockTicked, Is.EqualTo("00:00:01"));
        Console.WriteLine("Expected Result:00:00:01");
        Console.WriteLine($"Given Result:{clockOBJ.Time}");
    }

    [Test]
    public void TestClock_10secsIncrement()
    {
        for (i = 0; i < 10; i++)
        {
            clockOBJ.ClockStart();
        }
        var expected = clockOBJ.Time;
        Assert.That(expected, Is.EqualTo("00:00:10"));
        Console.WriteLine("Expected Result:00:00:10");
        Console.WriteLine($"Given Result:{clockOBJ.Time}");
    }

    [Test]
    public void TestClock_1minIncrement()
    {
        for (i = 0; i < 60; i++)
        {
            clockOBJ.ClockStart();
        }
        var expected = clockOBJ.Time;
        Assert.That(expected, Is.EqualTo("00:01:00"));
        Console.WriteLine("Expected Result:00:01:00");
        Console.WriteLine($"Given Result:{clockOBJ.Time}");
    }

    [Test]
    public void TestClock_10minsIncrement()
    {
        for (i = 0; i < 600; i++)
        {
            clockOBJ.ClockStart();
        }
        var expected = clockOBJ.Time;
        Assert.That(expected, Is.EqualTo("00:10:00"));
        Console.WriteLine("Expected Result:00:10:00");
        Console.WriteLine($"Given Result:{clockOBJ.Time}");
    }

    [Test]
    public void TestClock_1hrIncrement()
    {
        for (i = 0; i < 3600; i++)
        {
            clockOBJ.ClockStart();
        }
        var expected = clockOBJ.Time;
        Assert.That(expected, Is.EqualTo("01:00:00"));
        Console.WriteLine("Expected Result:01:00:00");
        Console.WriteLine($"Given Result:{clockOBJ.Time}");
    }

    [Test]
    public void TestClock_10hrsIncrement()
    {
        for (i = 0; i < 36000; i++)
        {
            clockOBJ.ClockStart();
        }
        var expected = clockOBJ.Time;
        Assert.That(expected, Is.EqualTo("10:00:00"));
        Console.WriteLine("Expected Result:10:00:00");
        Console.WriteLine($"Given Result:{clockOBJ.Time}");
    }

    [Test]
    public void TestClock_ResetOn24hrs()
    {
        for (i = 0; i < 86400; i++)
        {
            clockOBJ.ClockStart();
            if(i == 86400)
            {
                clockOBJ.ClockReset();
            }
        }
        var expected = clockOBJ.Time;
        Assert.That(expected, Is.EqualTo("00:00:00"));
        Console.WriteLine("Expected Result:00:00:00");
        Console.WriteLine($"Given Result:{clockOBJ.Time}");
    }

    [Test]
    public void TestClock_MannualClockReset()
    {
        for (i = 0; i < 500; i++)
        {
            clockOBJ.ClockStart();
        }
        Console.WriteLine($"Before Reset:{clockOBJ.Time}");
        clockOBJ.ClockReset();
        var expected = clockOBJ.Time;
        Assert.That(expected, Is.EqualTo("00:00:00"));
        Console.WriteLine($"After Reset:{clockOBJ.Time}");
    }

}
