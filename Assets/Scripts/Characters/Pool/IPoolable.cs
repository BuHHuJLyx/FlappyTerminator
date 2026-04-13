using System;

public interface IPoolable<T>
{
    event Action<T> Disabled;
}