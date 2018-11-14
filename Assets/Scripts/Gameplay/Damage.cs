using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeAttack
{
    NormalType,
    FireType,
    IceType
}

public class Damage{
    public float damageSize = 0f;
    public TypeAttack typeAttack = TypeAttack.NormalType;
}
