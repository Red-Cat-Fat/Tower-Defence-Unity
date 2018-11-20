using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public GameObject bullet;
    public bool fire = true;
    public float timeReload = 1f;
    private GameObject target;
    private PoolManager poolManager;
    private float lastFire = 0;
    public void Start()
    {
        poolManager = GameManager.Instance.poolManager;
    }

    private void Update()
    {
        lastFire += Time.deltaTime;
        if (target != null && lastFire > timeReload)
        {
            GameObject newBullet = poolManager.Spawn(bullet, transform.position, transform.rotation);//Instantiate(bullet, this.transform);

            MoveToPoint moveToPointBullet = newBullet.GetComponent<MoveToPoint>();
            if (moveToPointBullet != null)
            {
                moveToPointBullet.MoveTo(this.transform.position, target.transform.position);
            }
            DealingDamage dealingDamageBullet = newBullet.GetComponent<DealingDamage>();
            if (dealingDamageBullet != null)
            {
                UnitData unitData = gameObject.GetComponent<UnitData>();
                if (unitData != null)
                {
                    dealingDamageBullet.SetTeam(unitData.team);
                }
            }
            lastFire = 0;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        GameObject collisionGameObject = other.gameObject;
        if (collisionGameObject != null)
        {
            UnitData collisionUnitData = collisionGameObject.GetComponent<UnitData>();
            UnitData thisUnitData = gameObject.GetComponent<UnitData>();
            if (collisionUnitData != null && thisUnitData != null)
            {
                if (collisionUnitData.team != thisUnitData.team)
                {
                    target = collisionUnitData.gameObject;

                    MoveToPointByNavMesh moveToPointByNavMesh = this.gameObject.GetComponent<MoveToPointByNavMesh>();
                    if (moveToPointByNavMesh != null)
                    {
                        moveToPointByNavMesh.StopMove();
                    }
                }
            }
        }
    }
}
