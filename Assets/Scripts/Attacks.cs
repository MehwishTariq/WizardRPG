using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Attacks : MonoBehaviour
{
    #region SerializableFields
    [SerializeField]
    public Utility.AttackTypes type;
    
    public Utility.MagicTypes magicType;
    public Utility.WeaponTypes weaponType;
    #endregion

    #region variables

    public float damageVal;
    public float healingVal;

    public bool hasParticleFx;
    public bool canHeal;

    #endregion


    private void OnEnable()
    {
        if (type == Utility.AttackTypes.Magic)
        {
            GetComponent<SphereCollider>().radius = 0.1f;
            StartCoroutine(ExpandEffect());
        }
       else
            Debug.Log(type.ToString() + weaponType.ToString());
    }

    void SwordDamage(GameObject hitObject, Vector3 hitPos)
    {
        if (hitObject.CompareTag("Enemy"))
        {
            if(hasParticleFx)
                ParticleFxs.instance.PlayFx(Utility.ParticleFx.Blood, hitPos, Vector3.zero,  Vector3.one);

            hitObject.GetComponent<Health>().health -= damageVal;
            
        }

        if (hitObject.CompareTag("Player"))
        {
            if (hasParticleFx)
                ParticleFxs.instance.PlayFx(Utility.ParticleFx.Blood, hitPos, Vector3.zero, Vector3.one);

            hitObject.GetComponent<Health>().health -= damageVal;
            
        }

        if (hitObject.CompareTag("Weapon"))
        {
            if (hasParticleFx)
                ParticleFxs.instance.PlayFx(Utility.ParticleFx.SwordHit, hitPos, Vector3.zero, Vector3.one);
        }

    }

    void MagicAttack(GameObject hitObject)
    {
        if (hitObject.CompareTag("Enemy"))
        {
            if (hasParticleFx)
                ParticleFxs.instance.PlayFx(Utility.ParticleFx.MagicCircle, transform.position, transform.eulerAngles, transform.lossyScale);

            ParticleFxs.instance.PlayFx(Utility.ParticleFx.Blood, hitObject.transform.position, Vector3.zero, Vector3.one);
            hitObject.GetComponent<Health>().health -= damageVal;
        }

        if (hitObject.CompareTag("Player"))
        {
            if (hasParticleFx)
                ParticleFxs.instance.PlayFx(Utility.ParticleFx.MagicCircle, transform.position, transform.eulerAngles, transform.lossyScale);

            hitObject.GetComponent<Health>().health -= damageVal;
            
        }

        if (hitObject.CompareTag("Weapon"))
        {
           
        }
    }

    IEnumerator ExpandEffect()
    {
        while (GetComponent<SphereCollider>().radius <= 3.9f)
        {
            GetComponent<SphereCollider>().radius += 0.3f;
            yield return new WaitForEndOfFrame();
        }
        GetComponent<SphereCollider>().radius = 0.1f;
        gameObject.SetActive(false);
    }
   

    private void OnTriggerEnter(Collider other)
    {
        if(type == Utility.AttackTypes.Weapon)
            SwordDamage(other.gameObject, GetComponent<CapsuleCollider>().ClosestPoint(other.transform.localPosition));

        if (type == Utility.AttackTypes.Magic)
            MagicAttack(other.gameObject);
    }
}
