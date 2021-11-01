public class Gun
{
    private readonly float _fireRate;
    
    private int _ammo;
    private float _cooldown;

    public int Ammo => _ammo;
    public float Cooldown => _cooldown;

    public Gun(int ammo, float fireRate)
    {
        _ammo = ammo;
        _fireRate = fireRate;
    }

    public bool Shoot()
    {
        if (_ammo == 0 || _cooldown > 0.0f)
        {
            return false;
        }
        
        _ammo--;
        _cooldown = _fireRate;
        
        return true;
    }

    public void Update(float deltaTime)
    {
        if (_cooldown > 0.0f)
        {
            _cooldown -= deltaTime;

            if (_cooldown < 0.0f)
            {
                _cooldown = 0.0f;
            }
        }
    }
}