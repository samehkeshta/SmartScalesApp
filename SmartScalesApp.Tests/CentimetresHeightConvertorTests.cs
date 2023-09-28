using FluentAssertions;
using Xunit;
using SmartScalesApp.Business.Algorithms.HeightConvertor;

namespace SmartScalesApp.Tests;

public class CentimetresHeightConvertorTests
{
    [Theory]
    [InlineData(200.5, 200.5)]
    [InlineData(1, 1)]
    [InlineData(877.062, 877.062)]
    public void ConvertFromCM_InputIsInCm_ReturnInCentimetres(decimal heightInCms, decimal expectedheightInCentimetres)
    {
        var sut = new CentimetresHeightConvertor();

        var calculatedheightInCentimetres = sut.ConvertFromCM(heightInCms);

        calculatedheightInCentimetres.Should().Be(expectedheightInCentimetres);
    }

    [Theory]
    [InlineData(200.5, 200.5)]
    [InlineData(1, 1)]
    [InlineData(877.062, 877.062)]
    public void ConvertToCM_InputIsInCentimetres_ReturnInCMs(decimal heightInCentimetres, decimal expectedheightInCms)
    {
        var sut = new CentimetresHeightConvertor();

        var calculatedheightInCMs = sut.ConvertToCM(heightInCentimetres);

        calculatedheightInCMs.Should().Be(expectedheightInCms);
    }
}