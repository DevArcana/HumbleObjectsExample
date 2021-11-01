using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
  public int ammo = 3;
  public float fireRate = 1.0f;
  
  public float projectileSpeed = 10.0f;
  public Projectile projectilePrefab;
  public Transform gun;
  private Camera _camera;
  
  private Gun _gun;

  private void Start()
  {
    _gun = new Gun(ammo, fireRate);
    _camera = Camera.main;
  }

  private void Update()
  {
    if (Input.GetMouseButtonDown(1) && _gun.Shoot())
    {
      var position = gun.position;
      var projectile = Instantiate(projectilePrefab, position, Quaternion.identity);
      projectile.velocity = (Input.mousePosition - _camera.WorldToScreenPoint(position)).normalized * projectileSpeed;
    }
    
    _gun.Update(Time.deltaTime);
  }
}
