using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    #region SerializableFields
    [SerializeField]
    public Utility.AttackTypes type;
    #endregion

    #region variables
    public int enemyLimit;
    public float damageVal;
    public bool hasParticleFx;
    #endregion

    public abstract void AttackProperty();

    private void OnTriggerEnter(Collider other)
    {
        AttackProperty();
    }
}
