using System;
using FluentAssertions;
using Xunit;
using SmartScalesApp.Business.Algorithms.HeightConvertor;
using SmartScalesApp.Business.Models;

namespace SmartScalesApp.Tests
{
    public class HeightConvertorFactoryTests
    {
        [Theory]
        [InlineData(HeightMeasure.Centimetres, typeof(CentimetresHeightConvertor))]
        [InlineData(HeightMeasure.Inches, typeof(InchesHeightConvertor))]
        [InlineData(HeightMeasure.Meters, typeof(MetersHeightConvertor))]
        [InlineData(HeightMeasure.Feet, typeof(FeetHeightConvertor))]
        public void ConvertFromCM_InputIsInCm_ReturnInFeet(HeightMeasure heightMeasure, Type expectedType)
        {
            IHeightConvertor convertor;

            convertor = HeightConvertorFactory.GetHeightConvertor(heightMeasure);

            convertor.GetType().Should().Be(expectedType);
        }
    }
}