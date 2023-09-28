using FluentAssertions;
using Xunit;
using SmartScalesApp.Business.Algorithms.HeightConvertor;

namespace SmartScalesApp.Tests;

public class InchesHeightConvertorTests
{
    [Theory]
    [InlineData(509.27, 200.5)]
    [InlineData(2.54, 1)]
    [InlineData(877.062, 345.3)]
    public void ConvertFromCM_InputIsInCm_ReturnInInches(decimal heightInCms, decimal expectedheightInInches)
    {
        var sut = new InchesHeightConvertor();

        var calculatedheightInInches = sut.ConvertFromCM(heightInCms);

        calculatedheightInInches.Should().Be(expectedheightInInches);
    }

    [Theory]
    [InlineData(200.5, 509.27)]
    [InlineData(1, 2.54)]
    [InlineData(345.3, 877.062)]
    public void ConvertToCM_InputIsInInches_ReturnInCMs(decimal heightInInches, decimal expectedheightInCms)
    {
        var sut = new InchesHeightConvertor();

        var calculatedheightInCMs = sut.ConvertToCM(heightInInches);

        calculatedheightInCMs.Should().Be(expectedheightInCms);
    }
}