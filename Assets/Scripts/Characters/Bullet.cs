using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 5f;
    [SerializeField] private LayerMask _target;

    private int _damage = 1;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _rigidbody.gravityScale = 0f;
    }

    public void Init(Vector2 direction, float speed)
    {
        _rigidbody.linearVelocity = direction.normalized * speed;

        Destroy(gameObject, _lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & _target.value) == 0)
            return;

        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
            damageable.TakeDamage(_damage);

        Destroy(gameObject);
    }
}