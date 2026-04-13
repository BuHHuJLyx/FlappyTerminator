using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour,  IPoolable<T>
{
    [SerializeField] private Transform _container;
    [SerializeField] private T _prefab;

    private Queue<T> _pool;

    public IEnumerable<T> Items => _pool;

    private void Awake()
    {
        _pool = new Queue<T>();
    }

    public T Get()
    {
        if (_pool.Count == 0)
        {
            T item = Instantiate(_prefab);
            item.transform.parent = _container;

            item.Disabled += Put;

            return item;
        }

        T reusedItem = _pool.Dequeue();
        reusedItem.gameObject.SetActive(true);

        return reusedItem;
    }

    public void Put(T item)
    {
        _pool.Enqueue(item);
        item.gameObject.SetActive(false);
    }

    public void Reset()
    {
        _pool.Clear();
    }
}