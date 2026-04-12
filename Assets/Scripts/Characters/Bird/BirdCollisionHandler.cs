using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BirdCollisionHandler : MonoBehaviour
{
    public event Action CollisionDetected;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<Ground>(out _) || other.gameObject.TryGetComponent<Enemy>(out _))
            CollisionDetected?.Invoke();
    }
}