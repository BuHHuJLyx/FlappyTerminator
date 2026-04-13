using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health), typeof(Shooter))]
public class Enemy : MonoBehaviour, IPoolable<Enemy>
{
    [SerializeField] private float _shootDelay = 2f;
    
    private Health _health;
    private Shooter _shooter;
    private WaitForSeconds _delay;
    
    public event Action<Enemy> Died;
    public event Action<Enemy> Disabled;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _shooter = GetComponent<Shooter>();

        _delay = new WaitForSeconds(_shootDelay);
    }

    private void OnEnable()
    {
        _health.Depleted += OnDepleted;
    }

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private void OnDisable()
    {
        _health.Depleted -= OnDepleted;
    }
    
    public void Disable()
    {
        Disabled?.Invoke(this);
    }
    
    public void Init(BulletPool bulletPool)
    {
        _shooter.Init(bulletPool);
    }
    
    private IEnumerator Shoot()
    {
        while (enabled)
        {
            _shooter.Shoot(Vector2.left);
            yield return _delay;
        }
    }
    
    private void OnDepleted()
    {
        Died?.Invoke(this);
        Disabled?.Invoke(this);
    }
}