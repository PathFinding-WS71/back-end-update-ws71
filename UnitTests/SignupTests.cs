using Domain.Interfaces;

namespace UnitTests;

[TestClass]
public class SignupTests 
{
    [TestMethod]
    public async Task Signup_ValidUser_ReturnsUserId()
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
        mockEncryptDomain.Setup(x => x.Ecnrypt(user.Password))
            .Returns("encryptedpassword");

        mockUserInfrastructure.Setup(x => x.Signup(user))
            .ReturnsAsync(1); // Simula que se cre� el usuario y se devolvi� un ID

        // Act
        var result = await userDomain.Signup(user);

        // Assert
        Assert.AreEqual(1, result);
    }
}