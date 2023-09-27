namespace UnitTests;

[TestClass]
public class CommunityTests
{
    [TestMethod]
    public async Task Create_ValidCommunity_ReturnsTrue()
    {
        //Arrange
        var mockCommunityInfrastructure = new Mock<ICommunityInfrastructure>();
        var communityDomain = new CommunityDomain(mockCommunityInfrastructure.Object);

        var communityData = new Community()
        {
            IsActive = true
        };

        mockCommunityInfrastructure.Setup(x => x.Create(communityData))
            .ReturnsAsync(true);
        
        //Act
        var result = await communityDomain.Create(communityData);
        
        //Assert
        Assert.IsTrue(result);
    }
}