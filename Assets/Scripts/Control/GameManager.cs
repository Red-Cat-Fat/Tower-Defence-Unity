using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public PoolManager poolManager;
    public int Score = 0;
	
	// Update is called once per frame
	void Update () {
        poolManager.UpdateAllPool();
	}
}
