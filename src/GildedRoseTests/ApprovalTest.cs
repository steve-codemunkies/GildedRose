using System.Text;
using GildedRoseKata;

namespace GildedRoseTests;

public class ApprovalTest
{
    [Fact]
    public Task NoParameters()
    {
        var fakeOutput = new StringBuilder();
        Console.SetOut(new StringWriter(fakeOutput));
        Console.SetIn(new StringReader("a\n"));

        Program.Main([]);
        var output = fakeOutput.ToString();

        return Verifier.Verify(output);
    }

    [Fact]
    public Task NotANumber()
    {
        var fakeOutput = new StringBuilder();
        Console.SetOut(new StringWriter(fakeOutput));
        Console.SetIn(new StringReader("a\n"));

        Program.Main(["This is not a number"]);
        var output = fakeOutput.ToString();

        return Verifier.Verify(output);
    }

    [Fact]
    public Task NegativeNumber()
    {
        var fakeOutput = new StringBuilder();
        Console.SetOut(new StringWriter(fakeOutput));
        Console.SetIn(new StringReader("a\n"));

        Program.Main(["-2000"]);
        var output = fakeOutput.ToString();

        return Verifier.Verify(output);
    }

    [Fact]
    public Task TenDays()
    {
        var fakeOutput = new StringBuilder();
        Console.SetOut(new StringWriter(fakeOutput));
        Console.SetIn(new StringReader("a\n"));

        Program.Main(["10"]);
        var output = fakeOutput.ToString();

        return Verifier.Verify(output);
    }

    [Fact]
    public Task ThirtyDays()
    {
        var fakeOutput = new StringBuilder();
        Console.SetOut(new StringWriter(fakeOutput));
        Console.SetIn(new StringReader("a\n"));

        Program.Main(["30"]);
        var output = fakeOutput.ToString();

        return Verifier.Verify(output);
    }
}
