using FluentAssertions;
using Xunit;
using SmartScalesApp.Business.Models;

namespace SmartScalesApp.Tests
{
    public class WeightRecordTestsTests
    {
        [Fact]
        public void ValidWeightRecord_InputIsValid_ReturnTrue(){
            
            var userID = System.Guid.NewGuid();;
            var weightRecord = new WeightRecord(userID, 234, 1);

            var validweightRecord = weightRecord.ValidWeightRecord();

            validweightRecord.Should().BeTrue();
        }

        [Fact]
        public void ValidWeightRecord_InputHasInvalidWeight_ReturnFalse(){
            
            var userID = System.Guid.NewGuid();;
            var sut = new WeightRecord(userID, 0, 1);

            var validweightRecord = sut.ValidWeightRecord();

            validweightRecord.Should().BeFalse();
        }
    }    
}