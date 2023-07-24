using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyBaseClass : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform[] waypoints;
    public Animator anim;
    public virtual void Movement(Utility.CurrentState state)
    {
        //nav mesh agent
        
        agent.SetDestination(waypoints[0].position);
        //hsoid
        //patrolling or chasing ( vary player or ally)
    }
    #region Animation
        void SetMoveAnimation(float x, float z)
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

        void SetAttackAnimation(int attack = 0)
        {
            anim.SetInteger(Utility.PLAYERSTATE, (int)Utility.AnimationStates.Attack);
            anim.SetFloat(Utility.ATTACKTYPE, (float)attack);

        }
        void SetHealingAnimation(int heal)
        {
            anim.SetInteger(Utility.PLAYERSTATE, (int)Utility.AnimationStates.Heal);
            anim.SetFloat(Utility.HEALINGTYPE, (float)heal);
        }
    
    #endregion

    int currentPoint = 0;

    void Patrol()
    {
        agent.SetDestination(waypoints[currentPoint].position);
        if (Vector3.Distance(transform.position, agent.destination) < 0.1f)
            currentPoint++;
        if (currentPoint >= waypoints.Length)
            currentPoint = 0;
    }

    public abstract void Attack();

}
