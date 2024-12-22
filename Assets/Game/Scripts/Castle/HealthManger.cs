using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class HealthManger
{
    [SerializeField] private CastleCtrl castleCtrl;
    [SerializeField] private float curHp;
    public bool IsDead => curHp <= 0;

    public HealthManger(CastleCtrl ctrl, float hp)
    {
        this.castleCtrl = ctrl;
        this.curHp = hp;
    }

    public void TakeDamage(float damage)
    {
        curHp -= damage;
        if(curHp <= 0) castleCtrl.OnDead();
    }
}
