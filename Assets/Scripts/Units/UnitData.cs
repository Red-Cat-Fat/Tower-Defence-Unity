using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitData : MonoBehaviour {
    public IModification modification;
    private LifeParameters lifeParameters;
    //private LifeParameters lifeParameters;

    public void Start()
    {
        lifeParameters = GetComponent<LifeParameters>();
    }

    public void UpdateAll()
    {
        UpdateModification();
    }
    public void UpdateModification()
    {
        modification.UpdateMode();
    }
    public void UpdateLifeParameters()
    {
        lifeParameters.isLife();
    }
}
