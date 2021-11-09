using System;
using UnityEngine;

[Serializable]
public class Gun
{
  [SerializeField]
  private float fireRate;
  
  [SerializeField]
  private int ammo;

  [SerializeField]
  private float cooldown;
  
  public int Ammo => ammo;
  public float Cooldown => cooldown;

  public Gun(float fireRate, int ammo)
  {
    this.fireRate = fireRate;
    this.ammo = ammo;
  }

  public bool Shoot()
  {
    if (cooldown == 0.0f && ammo > 0)
    {
      ammo--;
      cooldown = fireRate;

      return true;
    }

    return false;
  }

  public void UpdateCooldown(float deltaTime)
  {
    if (cooldown > 0.0f)
    {
      cooldown -= deltaTime;

      if (cooldown < 0.0f)
      {
        cooldown = 0.0f;
      }
    }
  }
}

public class PlayerShoot : MonoBehaviour
{
  public float projectileSpeed = 10.0f;
  public Projectile projectilePrefab;
  public Transform gunTransform;
  
  public Gun gun;
  
  private Camera _camera;

  private void Start()
  {
    _camera = Camera.main;
  }

  private void Update()
  {
    if (Input.GetMouseButtonDown(1) && gun.Shoot())
    {
      var position = gunTransform.position;
      var projectile = Instantiate(projectilePrefab, position, Quaternion.identity);
      projectile.velocity = (Input.mousePosition - _camera.WorldToScreenPoint(position)).normalized * projectileSpeed;
    }

    gun.UpdateCooldown(Time.deltaTime);
  }
}
