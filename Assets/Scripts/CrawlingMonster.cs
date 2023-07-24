using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlingMonster : EnemyBaseClass
{
    public float speed;

    public override void Movement(Utility.CurrentState state)
    {
        agent.speed = speed;
        base.Movement(state);
    }

    public override void Attack()
    {
    }
}
