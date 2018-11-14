using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitData : MonoBehaviour {
    public float healthPoints = 100f;
    public IModification modification;

    public void UpdateAll()
    {
        UpdateModification();
    }
    public void UpdateModification()
    {
        modification.UpdateMode();
    }
}
