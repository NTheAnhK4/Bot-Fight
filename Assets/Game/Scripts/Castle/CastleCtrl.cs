using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleCtrl : ParentBehavior
{
    [SerializeField] private HealthManger healthManger;
    [SerializeField] private float maxHp = 100;
    protected override void OnEnable()
    {
        base.OnEnable();
        if (transform.tag.Equals("Player"))
            Observer.Attack(EventId.AttackPlayer, param=>
            {
                if (param is not float)
                {
                    Debug.LogWarning("Wrong param to castle controller");
                    return;
                }
                healthManger.TakeDamage((float)param);
            });
        else 
            Observer.Attack(EventId.AttackEnemy, param =>
            {
                if (param is not float)
                {
                    Debug.LogWarning("Wrong param to castle controller");
                    return;
                }
                healthManger.TakeDamage((float)param);
            });
        healthManger = new HealthManger(this, maxHp);
    }

    public void OnDead()
    {
        if (transform.tag.Equals("Player")) Debug.Log("Lose");
        else Debug.Log("Win");
    }
}
