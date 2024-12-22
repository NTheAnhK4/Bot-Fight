using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : IBehavior
{
    public void Enter(ActorCtrl ctrl)
    {
        
    }

    public void Execute(ActorCtrl ctrl)
    {
        if(ctrl.transform.tag.Equals("Player")) Observer.Notity(EventId.AttackEnemy,ctrl.Damage);
        else Observer.Notity(EventId.AttackPlayer,ctrl.Damage);
        ctrl.ChangeBehavior(new DespawnHandler());
    }

    public void Exit(ActorCtrl ctrl)
    {
        
    }
}
