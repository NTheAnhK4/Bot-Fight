using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnHandler : IBehavior
{
    

    public void Enter(ActorCtrl ctrl)
    {
        Exit(ctrl);
    }

    public void Execute(ActorCtrl ctrl)
    {
        
    }

    public void Exit(ActorCtrl ctrl)
    {
        PoolingManager.Despawn(ctrl.transform.gameObject);
    }
}
