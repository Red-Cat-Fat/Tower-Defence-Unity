using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitGenerator : MonoBehaviour {
    [Serializable]
    public class UnitGeneratorNode
    {
        public GameObject gameObject;
        public float timeNext = 0;
    }
    public UnitGeneratorNode[] unitGeneratorNodesArray;
    public Queue<UnitGeneratorNode> unitGeneratorNodes = new Queue<UnitGeneratorNode>();

    private PoolManager poolManager;
    private float time = 0;

    private void Start()
    {
        poolManager = GameManager.Instance.poolManager;
        time = 0;
        for (int i = 0; i < unitGeneratorNodesArray.Length; i++)
        {
            unitGeneratorNodes.Enqueue(unitGeneratorNodesArray[i]);
        }
    }

    private void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        if (unitGeneratorNodes.Count > 0)
        {
            float nextTime = unitGeneratorNodes.Peek().timeNext;
            if (time > nextTime)
            {
                time -= nextTime;

                UnitGeneratorNode unitGeneratorNode = unitGeneratorNodes.Dequeue();
                if (unitGeneratorNode != null)
                {
                    GameObject gameObject = unitGeneratorNode.gameObject;
                    poolManager.Spawn(gameObject, transform.position, transform.rotation);
                }
            }
        }
    }
}
