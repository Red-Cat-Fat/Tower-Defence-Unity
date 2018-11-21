using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitData : MonoBehaviour {
    public int team = 0;
    public IModification modification;
    private LifeParameters lifeParameters;

    public void Start()
    {
        lifeParameters = GetComponent<LifeParameters>();
        if(lifeParameters == null)
        {
            Debug.LogError("LifeParameters (in "+ gameObject.name +") is null");
        }
    }

    public void UpdateAll()
    {
        UpdateModification();
        UpdateLifeParameters();
    }

    public void UpdateModification()
    {
        if (modification != null)
        {
            modification.UpdateMode();
        }
    }

    public void UpdateLifeParameters()
    {
        if (lifeParameters!=null && !lifeParameters.isLife())
        {
            GameManager.Instance.poolManager.Despawn(gameObject);
        }
        if(gameObject.GetComponent<PoolObject>() == null)
        {
            //Destroy(this);
        }
    }


}
