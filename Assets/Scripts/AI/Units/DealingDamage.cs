using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealingDamage : MonoBehaviour {
    public float damagSize = 0;
    public TypeAttack typeAttack = TypeAttack.NormalType;
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
            lifeParameters.SetDamage(damage);
        }
    }
}
