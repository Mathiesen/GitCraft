using Gitcraft.DataAccess.Repository.Interfaces;
using Gitcraft.Entities;
using Gitcraft.Services;
using Gitcraft.Services.Interfaces;
using Gitcraft.Util;
using Moq;
using Moq.AutoMock;

namespace GitCraftTest1;

public class Tests
{
    private IAuthService service;
    private string salt;
    
    [SetUp]
    public void Setup()
    {
        var hashNSalt = new HashUtil().GenerateHash("test");
        salt = hashNSalt.salt;
        
        var mocker = new AutoMocker();

        var repo = new Mock<IUserRepository>();
        mocker.Use(repo);
        repo.Setup(x => 
            x.GetUser("test")).Returns(new User
        {
            Username = "test",
            Salt = salt,
            Id = Guid.NewGuid(),
            Hash = hashNSalt.hash
        });
        service = new AuthService(repo.Object);
    }

    [Test]
    public void Test1()
    {
        //Arrange 
        
        var username = "test";
        var password = "test";
        
        //Act
        var u = service.VerifyLogin(username, password);

        //Assert
        Assert.True(u);
    }
}