using Domain;
using Infrastructure.Interfaces;
using Infrastructure.Model;

namespace UpDate.Domain.Test;
using Moq;

public class UnitTest1
{
    [Fact]
    public async void Create_ValidActivity_ReturnSuccess()
    {
        //Arrange
        var activity = new Activity()
        {
            IsActive = true
        };
        var mockInfrastructure = new Mock<IActivityInfrastructure>();
            mockInfrastructure.Setup(t => t.Create(activity))
            .ReturnsAsync(true);
        var activityDomain = new ActivityDomain(mockInfrastructure.Object);
        
        //Act
        var result = await activityDomain.Create(activity);
        
        //Assert
        Assert.True(result);
    }
    
    [Fact]
    public async void Create_InvalidActivity_ReturnError()
    {
        //Arrange
        var activity = new Activity()
        {
            ActivityTitle = "test1"
        };
        var mockTutorialInfrastructure = new Mock<IActivityInfrastructure>();
        mockTutorialInfrastructure.Setup(t =>
                t.Create(activity))
            .ReturnsAsync(false);
        var activityDomain = new ActivityDomain(mockTutorialInfrastructure.Object);

        //Act
        var result = await activityDomain.Create(activity);
        
        //Assert
        Assert.False(result);
    }
   
    [Fact]
    public async void Update_ValidActivity_ReturnSuccess()
    {
        var activity = new Activity()
        {
            ActivityTitle = "test1"
        };
        var mockTutorialInfrastructure = new Mock<IActivityInfrastructure>();
        mockTutorialInfrastructure.Setup(t =>
                t.Update(5,activity))
            .ReturnsAsync(true);
        var activityDomain = new ActivityDomain(mockTutorialInfrastructure.Object);

        var result = await activityDomain.Update(5,activity);
        
        Assert.True(result);
    }
    
    [Fact]
    public async void Update_InvalidActivity_ReturnError()
    {
        var activity = new Activity()
        {
            ActivityTitle = "test1"
        };
        var mockTutorialInfrastructure = new Mock<IActivityInfrastructure>();
        mockTutorialInfrastructure.Setup(t =>
                t.Update(5,activity))
            .ReturnsAsync(false);
        var activityDomain = new ActivityDomain(mockTutorialInfrastructure.Object);

        var result = await activityDomain.Update(5,activity);
        
        Assert.False(result);
    } 
    [Fact]
    public async void Delete_ValidActivity_ReturnSuccess()
    {
        var mockTutorialInfrastructure = new Mock<IActivityInfrastructure>();
        mockTutorialInfrastructure.Setup(t =>
                t.Delete(5))
            .ReturnsAsync(true);
        var activityDomain = new ActivityDomain(mockTutorialInfrastructure.Object);

        var result = await activityDomain.Delete(5);
        
        Assert.True(result);
    }
    
    [Fact]
    public async void Delete_InvalidActivity_ReturnError()
    {
        var activityData = new Activity()
        {
            ActivityTitle = "test1"
        };
        var mockTutorialInfrastructure = new Mock<IActivityInfrastructure>();
        mockTutorialInfrastructure.Setup(t =>
                t.Delete(5))
            .ReturnsAsync(false);
        var activityDomain = new ActivityDomain(mockTutorialInfrastructure.Object);

        var result = await activityDomain.Delete(5);
        
        Assert.False(result);
    } 
    /*[Fact]
    public void Create_InvalidActivity_ReturnException()
    {
        ActivityData activityData = new ActivityData()
        {
            Title = "test1"
        };
        var mockTutorialInfraestructure = new Mock<IActivityInfrastructure>();
        mockTutorialInfraestructure.Setup(t =>
                t.Create(activityData))
            .Returns(false);
        ActivityDomain activityDomain = new ActivityDomain(mockTutorialInfraestructure.Object);

        var ex = Assert.Throws<Exception>(() => activityDomain.Create(activityData));
        
        Assert.Equal("Error", ex.Message);
    }*/
}