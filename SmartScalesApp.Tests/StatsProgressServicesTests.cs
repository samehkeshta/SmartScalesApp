using System.Collections.Generic;
using Moq;
using FluentAssertions;
using Xunit;
using SmartScalesApp.Business.Models;
using SmartScalesApp.Business.Services.Stats;
using SmartScalesApp.Data;

namespace SmartScalesApp.Tests
{
    public class StatsProgressServicesTests
    {
        [Fact]
        public void GetProgressResults_ForAUserProfileWithWeightRecords_ReturnsValidProgressResult()
        {
            //Arrange
            var userProfile = new UserProfile() {HeightInCMs = 180};
            var weightRecords = new List<WeightRecord>();

            var weightRecord = new WeightRecord(userProfile.UserID, 310,1);
            weightRecords.Add(weightRecord);
            
            weightRecord = new WeightRecord(userProfile.UserID, 210,2);
            weightRecords.Add(weightRecord);

            weightRecord = new WeightRecord(userProfile.UserID, 110,3);
            weightRecords.Add(weightRecord);

            var mockUserProfileRep = new Mock<IUserProfileRepository>();
            var mockWeightRecordRep = new Mock<IWeightRecordRepository>();

            mockUserProfileRep.Setup(userProfileRep => userProfileRep.GetUserProfileByID(userProfile.UserID))
                .Returns(userProfile);

            mockWeightRecordRep.Setup(weightRecordRep => weightRecordRep.GetWeightRecordsByUserID(userProfile.UserID))
                .Returns(weightRecords);

            var sut = new StatsProgressServices(mockUserProfileRep.Object, mockWeightRecordRep.Object);

            //Act            
            var progressResults = sut.GetProgressResults(userProfile.UserID);

            //Assert
            progressResults.Count.Should().Be(3);
            progressResults[0].Sequence.Should().Be(weightRecords[0].Sequence);
            progressResults[1].Sequence.Should().Be(weightRecords[1].Sequence);
            progressResults[2].Sequence.Should().Be(weightRecords[2].Sequence);
        }
    }
}