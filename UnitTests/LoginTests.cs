using Domain.Interfaces;

namespace UnitTests;

[TestClass]
public class LoginTests 
{
    [TestMethod]
    public async Task Login_ValidUser_ReturnsJwtToken()
    {
        // Arrange
        var mockUserInfrastructure = new Mock<IUserInfrastructure>();
        var mockEncryptDomain = new Mock<IEncryptDomain>();
        var mockTokenDomain = new Mock<ITokenDomain>();

        var userDomain = new UserDomain(
            mockUserInfrastructure.Object,
            mockEncryptDomain.Object,
            mockTokenDomain.Object
        );

        var user = new User
        {
            Username = "testuser",
            Password = "testpassword"
        };

        // Configure mocks
        mockUserInfrastructure.Setup(x => x.GetByUsername(user.Username))
            .ReturnsAsync(new User { Username = user.Username, Password = "encryptedpassword" });

        mockEncryptDomain.Setup(x => x.Ecnrypt(user.Password))
            .Returns("encryptedpassword");

        mockTokenDomain.Setup(x => x.GenerateJwt(user.Username))
            .Returns("jwttoken");

        // Act
        var result = await userDomain.Login(user);

        // Assert
        Assert.AreEqual("jwttoken", result);
    }

}