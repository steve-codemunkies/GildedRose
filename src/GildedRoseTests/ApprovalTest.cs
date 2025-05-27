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
