using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveHandler : IBehavior
{
    public void Enter(ActorCtrl ctrl)
    {
        
    }

    public void Execute(ActorCtrl ctrl)
    {
        ctrl.Rb.AddForce(ctrl.Speed*ctrl.Direction,ForceMode2D.Force);
        ctrl.Rb.velocity = Vector2.ClampMagnitude(ctrl.Rb.velocity, ctrl.Speed);
    }

    public void Exit(ActorCtrl ctrl)
    {
        
    }
}
