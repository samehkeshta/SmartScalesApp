using System;
using FluentAssertions;
using Xunit;
using SmartScalesApp.Business.Algorithms.WeightConvertor;
using SmartScalesApp.Business.Models;

namespace SmartScalesApp.Tests
{
    public class WeightConvertorFactoryTests
    {
        [Theory]
        [InlineData(WeightMeasure.Kilograms, typeof(KilogramsWeightConvertor))]
        [InlineData(WeightMeasure.Pounds, typeof(PoundsWeightConvertor))]
        [InlineData(WeightMeasure.Stones, typeof(StonesWeightConvertor))]
        public void GetWeightConvertor_InputIsWeightMeasure_ReturnSpecifiedConvertor(WeightMeasure WeightMeasure, Type expectedType)
        {
            IWeightConvertor convertor;

            convertor = WeightConvertorFactory.GetWeightConvertor(WeightMeasure);

            convertor.GetType().Should().Be(expectedType);
        }
    }
}