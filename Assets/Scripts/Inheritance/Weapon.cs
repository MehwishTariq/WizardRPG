using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Attack
{
    public Utility.WeaponTypes weaponTypes;
   
    public override void AttackProperty()
    {
        Debug.Log("HereWeapon");
       // throw new System.NotImplementedException();
    }
}
