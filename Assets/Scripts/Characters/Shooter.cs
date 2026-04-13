using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _bulletSpeed = 5;
    
    private BulletPool _pool;
    
    public void Init(BulletPool pool)
    {
        _pool = pool;
    }

    public void Shoot(Vector2 direction)
    {
        if (_pool == null)
            return;
        
        Bullet bullet = _pool.Get();

        bullet.transform.position = _firePoint.position;
        bullet.transform.rotation = Quaternion.identity;
        
        bullet.Init(direction, _bulletSpeed);
    }
}