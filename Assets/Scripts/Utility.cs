using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour
{
    public static readonly string ENEMYSTATE = "State";
    public static readonly string INPUTX = "InputX";
    public static readonly string INPUTZ = "InputZ";
    public static readonly string PLAYERSTATE = "Mode";
    public static readonly string HITSTATE = "Hit";
    public static readonly string ATTACKTYPE = "AttackType";
    public static readonly string HEALINGTYPE = "HealingType";
    public static readonly string MAINTAINTYPE = "MaintainType";
    public static readonly string DEATH = "Death";

    public enum AnimationStates
    {
        Move,
        Attack,
        Heal
    }
    public enum CurrentState
    {
        Patrolling,
        Battle,
        Healing
    }

    public enum AttackTypes
    {
        Weapon,
        Magic
    }

    public enum MagicTypes
    {
        FireMagic,
        ThunderMagic,
        PoisonMagic,
        HealingMagic
    }

    public enum ParticleFx
    {
        HealField,
        SwordHit,
        MagicCircle,
        Blood,
    }

    public enum WeaponTypes
    {
        Swords,
        Staffs,
        Axes
    }
}

