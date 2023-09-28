using FluentAssertions;
using System;
using System.Collections.Generic;
using Moq;
using Xunit;
using SmartScalesApp.Business.Models;
using SmartScalesApp.Business.Services.Stats;
using SmartScalesApp.Data;

namespace SmartScalesApp.Tests
{
    public class StatsBMIServicesTests
    {
        [Fact]
        public void GetBMIResult_ForAUserProfileWithWeightRecord_ReturnValidBMIResult(){
            
            //Arrange
            var userProfile = new UserProfile() {HeightInCMs = 180};
            var weightRecord = new WeightRecord(userProfile.UserID, 210, 1);
            var weightRecords = new List<WeightRecord>(){weightRecord};
            
            var mockUserProfileRep = new Mock<IUserProfileRepository>();
            var mockWeightRecordRep = new Mock<IWeightRecordRepository>();

            mockUserProfileRep.Setup(userProfileRep => userProfileRep.GetUserProfileByID(userProfile.UserID))
                .Returns(userProfile);

            mockWeightRecordRep.Setup(weightRecordRep => weightRecordRep.GetWeightRecordsByUserID(userProfile.UserID))
                .Returns(weightRecords);
            
            var sut = new StatsBMIServices(mockUserProfileRep.Object, mockWeightRecordRep.Object);

            //Act
            var bmiResult = sut.GetBMIResult(userProfile.UserID);

            //Assert
            Math.Round(bmiResult.BMI, 2).Should().Be(29.4m);
            bmiResult.BMIRange.Should().Be("Between 25 and 30");
            bmiResult.Classification.Should().Be(BMIClassification.Overweight);
        }

        [Fact]
        public void GetBMIResult_ForAUserProfileWithMultipleWeightRecords_ReturnValidBMIResult(){
            
            //Arrange
            var userProfile = new UserProfile() {HeightInCMs = 180, StartingWeightInPounds = 350};
            var weightRecord = new WeightRecord(userProfile.UserID, 100, 3);
            var weightRecords = new List<WeightRecord>(){weightRecord};
            
            weightRecord = new WeightRecord(userProfile.UserID, 210, 2);
            weightRecords.Add(weightRecord);

            weightRecord = new WeightRecord(userProfile.UserID, 310, 1);
            weightRecords.Add(weightRecord);

            var mockUserProfileRep = new Mock<IUserProfileRepository>();
            var mockWeightRecordRep = new Mock<IWeightRecordRepository>();

            mockUserProfileRep.Setup(userProfileRep => userProfileRep.GetUserProfileByID(userProfile.UserID))
                .Returns(userProfile);

            mockWeightRecordRep.Setup(weightRecordRep => weightRecordRep.GetWeightRecordsByUserID(userProfile.UserID))
                .Returns(weightRecords);
            
            var sut = new StatsBMIServices(mockUserProfileRep.Object, mockWeightRecordRep.Object);

            //Act
            var bmiResult = sut.GetBMIResult(userProfile.UserID);

            //Assert
            Math.Round(bmiResult.BMI, 2).Should().Be(14);
            bmiResult.BMIRange.Should().Be("Less than 18.5");
            bmiResult.Classification.Should().Be(BMIClassification.Underweight);
        }

        [Fact]
        public void GetBMIResult_ForAUserProfileWithNoWeightRecord_ReturnValidBMIResult(){
            
            //Arrange
            var userProfile = new UserProfile() {HeightInCMs = 180, StartingWeightInPounds = 210};
            var weightRecords = new List<WeightRecord>();
            
            var mockUserProfileRep = new Mock<IUserProfileRepository>();
            var mockWeightRecordRep = new Mock<IWeightRecordRepository>();

            mockUserProfileRep.Setup(userProfileRep => userProfileRep.GetUserProfileByID(userProfile.UserID))
                .Returns(userProfile);

            mockWeightRecordRep.Setup(weightRecordRep => weightRecordRep.GetWeightRecordsByUserID(userProfile.UserID))
                .Returns(weightRecords);
                        
            var sut = new StatsBMIServices(mockUserProfileRep.Object, mockWeightRecordRep.Object);

            //Act
            var bmiResult = sut.GetBMIResult(userProfile.UserID);

            //Assert
            Math.Round(bmiResult.BMI, 2).Should().Be(29.4m);
            bmiResult.BMIRange.Should().Be("Between 25 and 30");
            bmiResult.Classification.Should().Be(BMIClassification.Overweight);
        }
    }
}