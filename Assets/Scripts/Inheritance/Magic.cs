using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : Attack
{
    public Utility.MagicTypes magicType;
    public float healingVal;
    //public bool canHeal;

    public override void AttackProperty()
    {
        Debug.Log("HereMAgic");
        throw new System.NotImplementedException();
    }
}
