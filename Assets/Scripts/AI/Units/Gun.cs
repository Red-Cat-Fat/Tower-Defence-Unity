using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public GameObject bullet;
    public bool fire = true;
    public float timeReload = 1f;
    public GameObject pointGeneratorBullet;
    public GameObject turret;
    private List<GameObject> targets = new List<GameObject>();
    private PoolManager poolManager;
    private float lastFire = 0;

    public void Start()
    {
        poolManager = GameManager.Instance.poolManager;
        if (pointGeneratorBullet == null)
        {
            pointGeneratorBullet = gameObject;
        }
    }

    private void Update()
    {
        lastFire += Time.deltaTime;
        try
        {
            GameObject target = FindTarget();
            if (target!=null && lastFire > timeReload)
            {
                if (turret != null)
                {
                    //Quaternion quaternion = Quaternion.AngleAxis(1, Vec)
                    //float yRotate = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                    //turret.transform.localRotation = new Vector3(turret.transform.localRotation.x, , turret.transform.localRotation.z);
                    turret.transform.LookAt(target.transform.position, Vector3.up);
                }

                GameObject newBullet = poolManager.Spawn(bullet, pointGeneratorBullet.transform.position, pointGeneratorBullet.transform.rotation);//Instantiate(bullet, this.transform);

                Debug.Log(gameObject.name + " create bullet");
                MoveToPoint moveToPointBullet = newBullet.GetComponent<MoveToPoint>();
                if (moveToPointBullet != null)
                {
                    moveToPointBullet.MoveTo(pointGeneratorBullet.transform.position, target);
                }

                DealingDamage dealingDamageBullet = newBullet.GetComponent<DealingDamage>();
                if (dealingDamageBullet != null)
                {
                    UnitData unitData = gameObject.GetComponent<UnitData>();
                    if (unitData != null)
                    {
                        dealingDamageBullet.SetTeam(unitData.team);
                    }
                    else
                    {
                        Debug.LogWarning("Try get UnitData is faled (" + gameObject.name + ")");
                    }
                }
                else
                {
                    Debug.LogWarning("Try get DealingDamage is faled (" + gameObject.name + ")");
                }
                lastFire = 0;
            }
        }
        catch
        {
            Debug.LogError("Error in target " + targets[0].name);
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
                    targets.Add(collisionUnitData.gameObject);

                    MoveToPointByNavMesh moveToPointByNavMesh = this.gameObject.GetComponent<MoveToPointByNavMesh>();
                    if (moveToPointByNavMesh != null)
                    {
                        moveToPointByNavMesh.StopMove();
                    }
                }
            }
            else
            {
                if(thisUnitData == null)
                {
                    Debug.LogWarning("Try get UnitData is faled (" + gameObject.name + ")");
                }
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i] == other.gameObject)
            {
                targets.RemoveAt(i);
            }
        }
    }

    private GameObject FindTarget()
    {
        for (int i = 0; i < targets.Count; i++)
        {
            if (!targets[i].gameObject.activeSelf)
            {
                targets.RemoveAt(i);
            }
            else
            {
                return targets[i];
            }
        }
        return null;
    }
}
