using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeParameters : MonoBehaviour {
    public float healthPoints = 100f;

    public float NormalAttackProtection = 0;
    public float FireAttackProtection = 0;
    public float IceAttackProtection = 0;
    
    public bool isLife()
    {
        return healthPoints > 0;
    }

    public void SetDamage(Damage damage)
    {
        float calculateDamage = 0;
        if (damage != null)
        {
            switch (damage.typeAttack)
            {
                case TypeAttack.NormalType:
                    {
                        calculateDamage = damage.damageSize - damage.damageSize * NormalAttackProtection;
                        break;
                    }
                case TypeAttack.FireType:
                    {
                        calculateDamage = damage.damageSize - damage.damageSize * FireAttackProtection;
                        break;
                    }
                case TypeAttack.IceType:
                    {
                        calculateDamage = damage.damageSize - damage.damageSize * IceAttackProtection;
                        break;
                    }
            }
        }
        healthPoints -= calculateDamage;
    }
}
