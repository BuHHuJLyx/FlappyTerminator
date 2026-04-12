using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Enemy _prefab;

    private Queue<Enemy> _pool;

    public IEnumerable<Enemy> Enemies => _pool;

    private void Awake()
    {
        _pool = new Queue<Enemy>();
    }

    public Enemy Get()
    {
        if (_pool.Count == 0)
        {
            Enemy enemy = Instantiate(_prefab);
            enemy.transform.parent = _container;
            
            enemy.Init(this);

            return enemy;
        }

        return _pool.Dequeue();
    }

    public void Put(Enemy enemy)
    {
        _pool.Enqueue(enemy);
        enemy.gameObject.SetActive(false);
    }

    public void Reset()
    {
        _pool.Clear();
    }
}