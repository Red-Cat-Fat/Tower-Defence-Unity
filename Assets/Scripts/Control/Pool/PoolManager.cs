using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour {
    private Dictionary<GameObject, Pool> _pools = new Dictionary<GameObject, Pool>();

    public GameObject Spawn(GameObject prefab)
    {
        return Spawn(prefab, Vector3.zero, Quaternion.identity);
    }

    public GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent = null)
    {
        Pool pool;

        if (_pools.TryGetValue(prefab, out pool))
        {
            var poolObject = pool.Get();
            poolObject.transform.position = position;
            poolObject.transform.rotation = rotation;
            if (parent != null)
            {
                //poolObject.transform.SetParent(parent, true);
            }
            poolObject.gameObject.SetActive(true);
            return poolObject.gameObject;
        }
        return GameObject.Instantiate(prefab, position, rotation);
    }

    public void Despawn(GameObject go)
    {
        var poolObject = go.GetComponent<PoolObject>();
        if (poolObject != null)
        {
            poolObject.Pool.Despawn(poolObject);
        }
        else
        {
            GameObject.Destroy(go);
        }
    }

    public void Prespawn(GameObject prefab, int count)
    {
        Pool pool;
        if (!_pools.TryGetValue(prefab, out pool))
        {
            pool = new Pool(prefab, transform);
            _pools.Add(prefab, pool);
        }
        for (int i = 0; i < count; ++i)
        {
            pool.Add();
        }
    }

    public void UpdateAllPool()
    {
        foreach (GameObject key in _pools.Keys)
        {
            Pool pool;
            if (_pools.TryGetValue(key, out pool))
            {
                for (int i = 0; i < pool.Size; i++)
                {
                    PoolObject poolObject = pool.Get(i);
                    if (poolObject != null)
                    {
                        if (poolObject.gameObject != null)
                        {
                            UnitData unitData = poolObject.gameObject.GetComponent<UnitData>();
                            if (unitData != null)
                            {
                                unitData.UpdateAll();

                                //дополнительные обновления
                                //...
                                //...
                                //...
                            }
                        }
                    }
                }
            }
        }
    }

    public void UpdatePool(GameObject prefab)
    {
        Pool pool;
        if (_pools.TryGetValue(prefab, out pool))
        {
            for (int i = 0; i < pool.Size; i++)
            {
                PoolObject poolObject = pool.Get(i);
                if (poolObject != null)
                {
                    if (poolObject.gameObject != null)
                    {
                        UnitData unitData = poolObject.gameObject.GetComponent<UnitData>();
                        if (unitData != null)
                        {
                            unitData.UpdateAll();

                            //дополнительные обновления
                            //...
                            //...
                            //...
                        }
                    }
                }
            }
        }
    }
}
