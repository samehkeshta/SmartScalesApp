using FluentAssertions;
using Xunit;
using SmartScalesApp.Business.Algorithms.WeightConvertor;

namespace SmartScalesApp.Tests;

public class PoundsWeightConvertorTests
{
    [Theory]
    [InlineData(2.5, 2.5)]
    [InlineData(6, 6)]
    [InlineData(222, 222)]
    public void ConvertFromPounds_InputIsInPounds_ReturnInPounds(decimal WeightInPounds, decimal expectedWeightInPounds)
    {
        var sut = new PoundsWeightConvertor();

        var calculatedWeightInPounds = sut.ConvertFromPounds(WeightInPounds);

        calculatedWeightInPounds.Should().Be(expectedWeightInPounds);
    }

    [Theory]
    [InlineData(2.5, 2.5)]
    [InlineData(6, 6)]
    [InlineData(222, 222)]
    public void ConvertToPounds_InputIsInPounds_ReturnInPounds(decimal WeightInPounds, decimal expectedWeightInPounds)
    {
        var sut = new PoundsWeightConvertor();

        var calculatedWeightInPounds = sut.ConvertToPounds(WeightInPounds);

        calculatedWeightInPounds.Should().Be(expectedWeightInPounds);
    }
}