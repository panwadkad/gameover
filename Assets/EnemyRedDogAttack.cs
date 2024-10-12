using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRedDogAttack : EnemyAttack
{
        PlayerMoveControl playerMoveControl;
    
    public float forceX;
    public float forceY;
    public float duration;

    public override void SpacialAttack()
    {
        base.SpacialAttack();
        playerMoveControl = playerStats.GetComponentInParent<PlayerMoveControl>();
        StartCoroutine(playerMoveControl.KnockBack(forceX, forceY, duration, transform));
    }

    private void StartCoroutine(IEnumerable enumerable)
    {
        throw new NotImplementedException();
    }
}
