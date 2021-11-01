using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
  public float fireRate = 1.0f;
  public float projectileSpeed = 10.0f;
  public Projectile projectilePrefab;
  public Transform gun;
  
  public int ammo = 3;
  public float cooldown = 0.0f;
  private Camera _camera;

  private void Start()
  {
    _camera = Camera.main;
  }

  private void Update()
  {
    if (Input.GetMouseButtonDown(1) && cooldown == 0.0f && ammo > 0)
    {
      ammo--;
      cooldown = fireRate;

      var position = gun.position;
      var projectile = Instantiate(projectilePrefab, position, Quaternion.identity);
      projectile.velocity = (Input.mousePosition - _camera.WorldToScreenPoint(position)).normalized * projectileSpeed;
    }

    if (cooldown > 0.0f)
    {
      cooldown -= Time.deltaTime;

      if (cooldown < 0.0f)
      {
        cooldown = 0.0f;
      }
    }
  }
}
