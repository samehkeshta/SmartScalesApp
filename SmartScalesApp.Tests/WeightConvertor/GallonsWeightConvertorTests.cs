using FluentAssertions;
using Xunit;
using SmartScalesApp.Business.Algorithms.WeightConvertor;

namespace SmartScalesApp.Tests.WeightConvertor;

public class GallonsWeightConvertorTests
{
    [Fact]
    public void ConvertFromPounds_Input8Point345Pounds_ReturnOneGallon()
    {
        var sut = new GallonsWeightConvertor();

        var calculatedWeightInGallons = sut.ConvertFromPounds(8.345m);

        calculatedWeightInGallons.Should().Be(1m);
    }
}