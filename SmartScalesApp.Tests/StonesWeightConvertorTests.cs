using FluentAssertions;
using Xunit;
using SmartScalesApp.Business.Algorithms.WeightConvertor;

namespace SmartScalesApp.Tests;

public class StonesWeightConvertorTests
{
    [Theory]
    [InlineData(210, 15)]
    [InlineData(16.8, 1.2)]
    [InlineData(49, 3.5)]
    public void ConvertFromPounds_InputIsInPounds_ReturnInStones(decimal WeightInPounds, decimal expectedWeightInStones)
    {
        var sut = new StonesWeightConvertor();

        var calculatedWeightInStones = sut.ConvertFromPounds(WeightInPounds);

        calculatedWeightInStones.Should().Be(expectedWeightInStones);
    }

    [Theory]
    [InlineData(15, 210)]
    [InlineData(1.2, 16.8)]
    [InlineData(3.5, 49)]
    public void ConvertToPounds_InputIsInStones_ReturnInPounds(decimal WeightInStones, decimal expectedWeightInPounds)
    {
        var sut = new StonesWeightConvertor();

        var calculatedWeightInPounds = sut.ConvertToPounds(WeightInStones);

        calculatedWeightInPounds.Should().Be(expectedWeightInPounds);
    }
}