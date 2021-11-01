using NUnit.Framework;

namespace Tests.EditMode
{
  public class GunTests
  {
    [Test]
    public void HasLimitedAmmo()
    {
      // arrange
      var ammo = 3;
      var sut = new Gun(ammo, 1.0f);

      var shots = 0;
      
      // act
      for (var i = 0; i < 5; i++)
      {
        if (sut.Shoot())
        {
          shots++;
        }
        sut.Update(1.0f);
      }
      
      // assert
      Assert.That(shots, Is.EqualTo(ammo));
    }
    
    [Test]
    public void HasLimitedFireRate()
    {
      // arrange
      var ammo = 3;
      var sut = new Gun(ammo, 1.0f);
      
      // act
      sut.Shoot();
      sut.Update(0.5f);
      
      // assert
      Assert.That(sut.Shoot(), Is.False);
    }
  }
}