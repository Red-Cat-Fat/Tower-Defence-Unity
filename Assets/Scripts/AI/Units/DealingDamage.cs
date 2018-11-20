using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealingDamage : MonoBehaviour {
    public float damagSize = 0;
    public TypeAttack typeAttack = TypeAttack.NormalType;
    private int _team = 0;
    private Damage damage;
	// Use this for initialization
	void Start () {
        damage = new Damage(damagSize, typeAttack);
	}

    public void OnCollisionEnter(Collision collision)
    {
        LifeParameters lifeParameters = collision.gameObject.GetComponent<LifeParameters>();
        if (lifeParameters != null)
        {
            UnitData targetUnitData = collision.gameObject.GetComponent<UnitData>();
            if (targetUnitData != null)
            {
                if (targetUnitData.team != _team)
                {
                    lifeParameters.SetDamage(damage);
                    GameManager.Instance.poolManager.Despawn(this.gameObject);
                }
            }
        }
    }

    public void SetTeam(int team)
    {
        _team = team;
    }
}
