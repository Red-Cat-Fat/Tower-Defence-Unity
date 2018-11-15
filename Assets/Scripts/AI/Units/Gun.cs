using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public GameObject bullet;
    public bool fire = true;
    public float timeReload = 1f;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject != null)
        {
            UnitData collisionUnitData = collisionGameObject.GetComponent<UnitData>();
            UnitData thisUnitData = gameObject.GetComponent<UnitData>();
            if (collisionUnitData != null && thisUnitData != null)
            {
                if (collisionUnitData.team != thisUnitData.team)
                {
                    GameObject newBullet = Instantiate(bullet, this.transform);
                    MoveToPoint moveToPointBullet = newBullet.GetComponent<MoveToPoint>();
                    if (moveToPointBullet != null)
                    {
                        moveToPointBullet.MoveTo(thisUnitData.gameObject.transform.position);
                    }
                }
            }
        }
    }
}
