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
    private IBehavior curBehavior;

    public Rigidbody2D Rb => rb;

    public Vector3 Direction => direction;

    public float Speed => speed;

    public float Weight => weight;
    public void Init(Vector3 direct, float moveSpeed, float weightActor)
    {
        this.direction = direct;
        this.speed = moveSpeed;
        this.weight = weightActor;
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
        curBehavior?.Execute(this);
    }
}