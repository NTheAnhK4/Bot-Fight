using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class ActorCtrl : ParentBehavior
{
    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector3 direction;
    [SerializeField] private float speed;
    [SerializeField] private float weight;
    [SerializeField] private float damage;
    private IBehavior curBehavior;

    public Rigidbody2D Rb => rb;

    public Vector3 Direction => direction;

    public float Speed => speed;

    public float Weight => weight;

    public float Damage => damage;
    public void Init(Vector3 direct, float moveSpeed, float weightActor, float actorDamage)
    {
        this.direction = direct;
        this.speed = moveSpeed;
        this.weight = weightActor;
        this.damage = actorDamage;
        LoadRigid();
        curBehavior = new MoveHandler();
        curBehavior.Enter(this);
    }
    protected void LoadRigid()
    {
        if (rb != null) return;
        rb  = transform.GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.gravityScale = 0;
        rb.mass = weight;
    }
    
    private void Update()
    {
        if(transform.position.x > 12 || transform.position.x < -12) ChangeBehavior(new AttackHandler()); 
        curBehavior?.Execute(this);
    }

    public void ChangeBehavior(IBehavior newBehavior)
    {
        curBehavior?.Exit(this);
        curBehavior = newBehavior;
        curBehavior?.Enter(this);
    }
}
