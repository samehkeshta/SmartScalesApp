using FluentAssertions;
using Xunit;
using SmartScalesApp.Business.Algorithms.WeightConvertor;

namespace SmartScalesApp.Tests;

public class KilogramsWeightConvertorTests
{
    [Theory]
    [InlineData(1, 0.453592)]
    [InlineData(2.5, 1.13398)]
    [InlineData(3.8, 1.7236496)]
    public void ConvertFromPounds_InputIsInPounds_ReturnInKilograms(decimal WeightInPounds, decimal expectedWeightInKilograms)
    {
        var sut = new KilogramsWeightConvertor();

        var calculatedWeightInKilograms = sut.ConvertFromPounds(WeightInPounds);

        calculatedWeightInKilograms.Should().Be(expectedWeightInKilograms);
    }

    [InlineData(0.453592, 1)]
    [InlineData(1.13398, 2.5)]
    [InlineData(1.7236496, 3.8)]
    public void ConvertToPounds_InputIsInKilograms_ReturnInPounds(decimal WeightInKilograms, decimal expectedWeightInPounds)
    {
        var sut = new KilogramsWeightConvertor();

        var calculatedWeightInPounds = sut.ConvertToPounds(WeightInKilograms);

        calculatedWeightInPounds.Should().Be(expectedWeightInPounds);
    }
}