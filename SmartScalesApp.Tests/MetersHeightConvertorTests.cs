using FluentAssertions;
using Xunit;
using SmartScalesApp.Business.Algorithms.HeightConvertor;

namespace SmartScalesApp.Tests;

public class MetersHeightConvertorTests
{
    [Theory]
    [InlineData(98.3, 0.983)]
    [InlineData(198.5, 1.985)]
    [InlineData(222, 2.22)]
    public void ConvertFromCM_InputIsInCm_ReturnInMeters(decimal heightInCms, decimal expectedheightInMeters)
    {
        var sut = new MetersHeightConvertor();

        var calculatedheightInMeters = sut.ConvertFromCM(heightInCms);

        calculatedheightInMeters.Should().Be(expectedheightInMeters);
    }

    [Theory]
    [InlineData(0.983, 98.3)]
    [InlineData(1.985, 198.5)]
    [InlineData(2.22, 222)]
    public void ConvertToCM_InputIsInMeters_ReturnInCMs(decimal heightInMeters, decimal expectedheightInCms)
    {
        var sut = new MetersHeightConvertor();

        var calculatedheightInCMs = sut.ConvertToCM(heightInMeters);

        calculatedheightInCMs.Should().Be(expectedheightInCms);
    }
}