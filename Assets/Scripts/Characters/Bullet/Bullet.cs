using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour,  IPoolable<Bullet>
{
    [SerializeField] private LayerMask _target;

    private int _damage = 1;

    private Rigidbody2D _rigidbody;
    
    public event Action<Bullet> Disabled;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _rigidbody.gravityScale = 0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & _target.value) == 0)
            return;

        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
            damageable.TakeDamage(_damage);

        Disable();
    }
    
    public void Init(Vector2 direction, float speed)
    {
        _rigidbody.linearVelocity = direction.normalized * speed;
    }
    
    public void Disable()
    {
        Disabled?.Invoke(this);
    }
}