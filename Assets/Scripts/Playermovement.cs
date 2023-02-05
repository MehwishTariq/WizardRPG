using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Playermovement : MonoBehaviour
{

    Rigidbody player;
    Animator anim;
    public float speed = 3f;
    float x, z;
    Vector3 move;
    float currentAngle, currentAngleVelocity, rotationSmoothTime;
    public Camera followCam;
    public GameObject[] attacks, weapons, magic;

    void Start()
    {
        player = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        MovementMode();
        Controls();
    }

    #region Controls
    public void Controls()
    {

        if (Input.GetMouseButtonDown(0))
        {
            anim.StopPlayback();
            int attackType = Random.Range(0, 3);

            attacks[(int)Utility.AttackTypes.Weapon].SetActive(true);
            weapons[(int)Utility.WeaponTypes.Staffs].SetActive(true);
            attacks[(int)Utility.AttackTypes.Magic].SetActive(false);
            SetAttackAnimation(attackType);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.StopPlayback();
            attacks[(int)Utility.AttackTypes.Weapon].SetActive(false);
            attacks[(int)Utility.AttackTypes.Magic].SetActive(true);
            magic[(int)Utility.MagicTypes.PoisonMagic].SetActive(true);
            SetAttackAnimation(3);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            anim.StopPlayback();
            SetHealingAnimation(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            anim.StopPlayback();
            SetHealingAnimation(1);
        }
    }
    #endregion

    #region Movement
    public void MovementMode()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        
        move = new Vector3(x, 0, z).normalized;
        SetMoveAnimation(x, z);

        if (move == Vector3.zero)
            return;

        player.MovePosition(player.position + speed * Time.deltaTime * RotatePlayer(move));
    }

    
    public Vector3 RotatePlayer(Vector3 move)
    {
        Vector3 moveDir = Vector3.zero;

        if (move.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + followCam.transform.eulerAngles.y;
            currentAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref currentAngleVelocity, rotationSmoothTime);
            transform.rotation = Quaternion.Euler(0, currentAngle, 0);

            moveDir =  Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
        }
        return moveDir;
    }
    public void SetMoveAnimation(float x, float z)
    {
        anim.SetInteger(Utility.PLAYERSTATE, (int)Utility.AnimationStates.Move);

        if (x == 0 && z == 0)
        {
            anim.SetFloat(Utility.INPUTX, 0);
            anim.SetFloat(Utility.INPUTZ, 0);
        }

        if ((x > 0 || x < 0) || (z > 0 || z < 0))
        {
            anim.SetFloat(Utility.INPUTX, 1);
            anim.SetFloat(Utility.INPUTZ, 1);
        }
    }

    #endregion

    #region Attack
    public void SetAttackAnimation(int attack = 0)
    {
        anim.SetInteger(Utility.PLAYERSTATE, (int)Utility.AnimationStates.Attack);
        anim.SetFloat(Utility.ATTACKTYPE, (float)attack);
        
    }
    #endregion

    #region Heal
    public void SetHealingAnimation(int heal)
    {
        anim.SetInteger(Utility.PLAYERSTATE, (int)Utility.AnimationStates.Heal);
        anim.SetFloat(Utility.HEALINGTYPE, (float)heal);
    }
    #endregion

}
