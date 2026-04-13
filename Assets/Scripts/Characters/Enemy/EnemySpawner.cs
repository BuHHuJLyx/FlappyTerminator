using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private BulletPool _bulletPool;

    private WaitForSeconds _wait;
    
    public event Action<Enemy> EnemySpawned;

    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);
    }

    private void Start()
    {
        StartCoroutine(GenerateEnemies());
    }

    private IEnumerator GenerateEnemies()
    {
        while (enabled)
        {
            Spawn();
            yield return _wait;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = UnityEngine.Random.Range(_lowerBound, _upperBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        Enemy enemy = _enemyPool.Get();
        enemy.transform.position = spawnPoint;
        enemy.Init(_bulletPool);
        
        EnemySpawned?.Invoke(enemy);
    }
}