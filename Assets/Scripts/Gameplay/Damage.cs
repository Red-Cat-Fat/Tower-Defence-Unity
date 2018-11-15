using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeAttack
{
    NormalType,
    FireType,
    IceType
}
[SerializeField]
public class Damage{
    public float damageSize = 0f;
    public TypeAttack typeAttack = TypeAttack.NormalType;
    public Damage()
    {
        this.damageSize = 0f;
        this.typeAttack = TypeAttack.NormalType;
    }
    public Damage(float _damageSize, TypeAttack _typeAttack)
    {
        this.damageSize = _damageSize;
        this.typeAttack = _typeAttack;
    }
}
