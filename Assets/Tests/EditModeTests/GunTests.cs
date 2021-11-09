using NUnit.Framework;

namespace Tests.EditModeTests
{
  public class GunTests
  {
    [Test]
    public void HasLimitedAmmo()
    {
      // arrange
      var sut = new Gun(1.0f, 3);

      // act
      for (var i = 0; i < 3; i++)
      {
        sut.Shoot();
        sut.UpdateCooldown(1.0f);
      }
      
      // assert
      Assert.That(sut.Shoot(), Is.False);
    }
  }
}