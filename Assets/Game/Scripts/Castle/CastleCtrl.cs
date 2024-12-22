using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleCtrl : ParentBehavior
{
    protected override void OnEnable()
    {
        base.OnEnable();
        if (transform.tag.Equals("Player"))
            Observer.Attack(EventId.AttackPlayer, param =>
            {
                Debug.Log("Attack Player");
            });
        else 
            Observer.Attack(EventId.AttackEnemy, param =>
            {
                Debug.Log("Attack Enemy");
            });
    }
}
