namespace ClockTask.nUnitTests;

public class CounterTests
{
    private Counter counterOBJ { get; set; } = null!;

    [SetUp]
    public void Setup()
    {
        const string test = "counterTEST";
        counterOBJ = new Counter(test);
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
}
