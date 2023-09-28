using FluentAssertions;
using Xunit;
using SmartScalesApp.Business.Algorithms.HeightConvertor;

namespace SmartScalesApp.Tests;

public class FeetHeightConvertorTests
{
    [Theory]
    [InlineData(155.7528, 5.11)]
    [InlineData(30.48, 1)]
    [InlineData(182.88, 6)]
    public void ConvertFromCM_InputIsInCm_ReturnInFeet(decimal heightInCms, decimal expectedheightInFeet)
    {
        var sut = new FeetHeightConvertor();

        var calculatedheightInFeet = sut.ConvertFromCM(heightInCms);

        calculatedheightInFeet.Should().Be(expectedheightInFeet);
    }

    [Theory]
    [InlineData(5.11,155.7528)]
    [InlineData(1, 30.48)]
    [InlineData(6, 182.88)]
    public void ConvertToCM_InputIsInFeet_ReturnInCMs(decimal heightInFeet, decimal expectedheightInCms)
    {
        var sut = new FeetHeightConvertor();

        var calculatedheightInCMs = sut.ConvertToCM(heightInFeet);

        calculatedheightInCMs.Should().Be(expectedheightInCms);
    }
}