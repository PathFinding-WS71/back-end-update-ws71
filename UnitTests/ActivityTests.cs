namespace UnitTests
{
    [TestClass]
    public class ActivityTests
    {
        [TestMethod]
        public async Task Create_ValidActivity_ReturnsTrue()
        {
            // Arrange
            var mockActivityInfrastructure = new Mock<IActivityInfrastructure>();
            var activityDomain = new ActivityDomain(mockActivityInfrastructure.Object);

            var activityData = new Activity
            {
                // Configura los datos de la actividad que deseas crear
                // Por ejemplo, establece propiedades como Title, Description, etc.
            };

            // Configura el comportamiento del mock de IActivityInfrastructure
            mockActivityInfrastructure.Setup(x => x.Create(activityData))
                .ReturnsAsync(true); // Simula que la actividad se creó con éxito

            // Act
            var result = await activityDomain.Create(activityData);

            // Assert
            Assert.IsTrue(result); // Verifica que el método devuelva true si la creación fue exitosa
        }

        [TestMethod]
        public async Task Create_InvalidActivity_ReturnError()
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
            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task Update_ValidActivity_ReturnSuccess()
        {
            var activity = new Activity()
            {
                ActivityTitle = "test1"
            };
            var mockTutorialInfrastructure = new Mock<IActivityInfrastructure>();
            mockTutorialInfrastructure.Setup(t =>
                    t.Update(5, activity))
                .ReturnsAsync(true);
            var activityDomain = new ActivityDomain(mockTutorialInfrastructure.Object);

            var result = await activityDomain.Update(5, activity);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task Update_InvalidActivity_ReturnError()
        {
            var activity = new Activity()
            {
                ActivityTitle = "test1"
            };
            var mockTutorialInfrastructure = new Mock<IActivityInfrastructure>();
            mockTutorialInfrastructure.Setup(t =>
                    t.Update(5, activity))
                .ReturnsAsync(false);
            var activityDomain = new ActivityDomain(mockTutorialInfrastructure.Object);

            var result = await activityDomain.Update(5, activity);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task Delete_ValidActivity_ReturnSuccess()
        {
            var mockTutorialInfrastructure = new Mock<IActivityInfrastructure>();
            mockTutorialInfrastructure.Setup(t =>
                    t.Delete(5))
                .ReturnsAsync(true);
            var activityDomain = new ActivityDomain(mockTutorialInfrastructure.Object);

            var result = await activityDomain.Delete(5);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task Delete_InvalidActivity_ReturnError()
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

            Assert.IsFalse(result);
        }
    }
}