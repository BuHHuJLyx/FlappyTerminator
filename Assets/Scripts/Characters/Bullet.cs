using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 5f;

    private int _damage = 1;
    
    private Rigidbody2D _rigidbody;
    private GameObject _owner;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _rigidbody.gravityScale = 0f;
    }

    public void Init(Vector2 direction, float speed, GameObject owner)
    {
        _owner = owner;

        _rigidbody.linearVelocity = direction.normalized * speed;

        Destroy(gameObject, _lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == _owner)
            return;

        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(_damage);
        }

        Destroy(gameObject);
    }
}
