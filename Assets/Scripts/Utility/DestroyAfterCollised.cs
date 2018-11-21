using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterCollised : MonoBehaviour {
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<UnitData>() == null)
        {
            GameManager.Instance.poolManager.Despawn(gameObject);
        }
    }
}
