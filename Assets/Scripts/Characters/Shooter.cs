using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _bulletSpeed = 5;

    public void Shoot(Vector2 direction)
    {
        Bullet bullet = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);
        bullet.Init(direction, _bulletSpeed, gameObject);
    }
}