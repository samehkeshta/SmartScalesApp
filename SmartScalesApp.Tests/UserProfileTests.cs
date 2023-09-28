using FluentAssertions;
using Xunit;
using SmartScalesApp.Business.Models;

namespace SmartScalesApp.Tests
{
    public class UserProfileTests
    {
        [Fact]
        public void ValidProfile_InputIsValidProfile_ReturnTrue(){
            
            var sut = new UserProfile();
            sut.UserName = "Test";
            sut.HeightInCMs = 300;
            sut.StartingWeightInPounds = 150;

            var validProfile = sut.ValidProfile();

            validProfile.Should().BeTrue();
        }

        [Fact]
        public void ValidProfile_InputIsProfileMissingUserName_ReturnFalse(){
            
            var sut = new UserProfile();
            sut.HeightInCMs = 300;
            sut.StartingWeightInPounds = 150;

            var validProfile = sut.ValidProfile();

            validProfile.Should().BeFalse();
        }

        [Fact]
        public void ValidProfile_InputIsProfileMissingHeight_ReturnFalse(){
            
            var sut = new UserProfile();
            sut.UserName = "Test";
            sut.StartingWeightInPounds = 150;

            var validProfile = sut.ValidProfile();

            validProfile.Should().BeFalse();
        }

        [Fact]
        public void ValidProfile_InputIsProfileMissingWeight_ReturnFalse(){
            
            var sut = new UserProfile();
            sut.UserName = "Test";
            sut.HeightInCMs = 300;

            var validProfile = sut.ValidProfile();

            validProfile.Should().BeFalse();
        }
    }
}