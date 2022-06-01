using NUnit.Framework;
using FluentAssertions;

public class LCSTests
{
    [Test]
    public void LCS1()
    {
        LCS.Find("stone", "longest").Should().BeEquivalentTo("one");
    }

    [Test]
    public void LCS2()
    {
        LCS.Find("longest", "stone").Should().BeEquivalentTo("one");
    }

    [Test]
    public void LCS3()
    {
        LCS.Find("properties", "prosperity").Should().BeEquivalentTo("properi");
    }
    
    [Test]
    public void LCS4()
    {
        LCS.Find("prosperity", "properties").Should().BeEquivalentTo("propert");
    }
}