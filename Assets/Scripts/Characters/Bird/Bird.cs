using System;
using UnityEngine;

[RequireComponent(typeof(InputReader), typeof(BirdMover), typeof(BirdCollisionHandler))]
[RequireComponent(typeof(Health), typeof(Shooter))]
public class Bird : MonoBehaviour
{
    private InputReader _input;
    private BirdMover _mover;
    private BirdCollisionHandler _handler;
    private Health _health;
    private Shooter _shooter;

    public event Action GameOver;

    private void Awake()
    {
        _input = GetComponent<InputReader>();
        _mover = GetComponent<BirdMover>();
        _handler = GetComponent<BirdCollisionHandler>();
        _health = GetComponent<Health>();
        _shooter = GetComponent<Shooter>();;
    }

    private void OnEnable()
    {
        _health.Depleted += OnDepleted;
        _handler.CollisionDetected += OnDepleted;
    }

    private void FixedUpdate()
    {
        if (_input.GetIsFly())
            _mover.Fly();

        if (_input.GetIsAttack())
            _shooter.Shoot(transform.right);
    }

    private void OnDisable()
    {
        _health.Depleted -= OnDepleted;
        _handler.CollisionDetected -= OnDepleted;
    }

    public void Reset()
    {
        _mover.Reset();
    }
    
    public void Init(BulletPool bulletPool)
    {
        _shooter.Init(bulletPool);
    }

    private void OnDepleted()
    {
        GameOver?.Invoke();
    }
}