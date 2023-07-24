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

    public int enemyLimit;
    public float damageVal;
    public float healingVal;

    public bool hasParticleFx;
    public bool canHeal;

    #endregion

     
    private void OnEnable()
    {
        if (type == Utility.AttackTypes.Magic)
        {
            if (!canHeal)
            {
                GetComponent<SphereCollider>().radius = 0.1f;
                float valuetoTween = GetComponent<SphereCollider>().radius;

                if (hasParticleFx)
                    ParticleFxs.instance.PlayFx(Utility.ParticleFx.MagicCircle, transform.position, transform.eulerAngles, transform.lossyScale);

                DOTween.To(() => valuetoTween, x => valuetoTween = x, 2f, 3f).OnUpdate(() =>
                {
                    GetComponent<SphereCollider>().radius = valuetoTween;
                }).OnComplete(() =>
                {
                    GetComponent<SphereCollider>().radius = 0.1f;
                    hitObjects = 0;
                    if (gameObject.layer == LayerMask.NameToLayer("Player"))
                        EventManager.PlayerMagicDone();
                });
            }
            else
            {
                if (gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    if (hasParticleFx)
                        ParticleFxs.instance.PlayFx(Utility.ParticleFx.HealField, transform.position, transform.eulerAngles, new Vector3(transform.lossyScale.x, transform.lossyScale.x, transform.lossyScale.x));

                    float valuetoTween = gameObject.GetComponentInParent<Health>().health;

                    DOTween.To(() => valuetoTween, x => valuetoTween = x, healingVal, 2f).OnUpdate(() =>
                    {
                        gameObject.GetComponentInParent<Health>().health = valuetoTween;
                        
                    }).OnComplete(() =>
                    {
                        EventManager.PlayerMagicDone();
                    });
                }
            }
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

    int hitObjects; 

    void MagicAttack(GameObject hitObject)
    {
        if (hitObjects < enemyLimit)
        {
            if (hitObject.CompareTag("Enemy"))
            {
                hitObjects++;
                if (hasParticleFx)
                    ParticleFxs.instance.PlayFx(Utility.ParticleFx.MagicCircle, hitObject.transform.position, transform.eulerAngles, transform.lossyScale);

                ParticleFxs.instance.PlayFx(Utility.ParticleFx.Blood, hitObject.transform.position, Vector3.zero, Vector3.one);
                hitObject.GetComponent<Health>().health -= damageVal;
            }

            if (hitObject.CompareTag("Player"))
            {
                hitObjects++;
                if (hasParticleFx)
                    ParticleFxs.instance.PlayFx(Utility.ParticleFx.MagicCircle, hitObject.transform.position, transform.eulerAngles, transform.lossyScale);

                hitObject.GetComponent<Health>().health -= damageVal;

            }

            if (hitObject.CompareTag("Weapon"))
            {

            }
        }
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if(type == Utility.AttackTypes.Weapon)
            SwordDamage(other.gameObject, GetComponent<CapsuleCollider>().ClosestPoint(other.transform.localPosition));

        if (type == Utility.AttackTypes.Magic)
            MagicAttack(other.gameObject);
    }
}
