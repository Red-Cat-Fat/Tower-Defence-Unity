using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour {
    private GameObject _prefab;
    private Transform _container;
    private List<PoolObject> _objects = new List<PoolObject>();

    public int Size
    {
        get
        {
            return _objects.Count;
        }
    }

    public Pool(GameObject prefab, Transform container)
    {
        _prefab = prefab;
        _container = container;
    }

    internal PoolObject Add()
    {
        var go = GameObject.Instantiate(_prefab, _container, true);
        var poolObject = go.GetComponent<PoolObject>();
        poolObject.Pool = this;
        go.SetActive(false);
        _objects.Add(poolObject);
        return poolObject;
    }

    internal PoolObject Get()
    {
        PoolObject obj;
        for (int i = 0; i < _objects.Count; ++i)
        {
            obj = _objects[i];
            if (!obj.gameObject.activeSelf)
            {
                return obj;
            }
        }
        obj = Add();
        return obj;
    }

    internal PoolObject Get(int index)
    {
        if (index < Size)
        {
            return _objects[index];
        }
        else
        {
            return null;
        }
    }

    internal void Despawn(PoolObject poolObject)
    {
        poolObject.gameObject.SetActive(false);
    }
}
