using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class MoveHandler : ChildBehavior
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector3 direction;
    [SerializeField] private float speed;
    [SerializeField] private float weight;

    public void Init(Vector3 direct, float moveSpeed, float weightActor)
    {
        this.direction = direct;
        this.speed = moveSpeed;
        this.weight = weightActor;
        LoadRigid();
    }
    

    protected void LoadRigid()
    {
        if (rb != null) return;
        rb  = transform.GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.gravityScale = 0;
        rb.mass = weight;
    }

    private void Update(){
        rb.AddForce(speed * direction,ForceMode2D.Force);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, speed);
    }

   

   
}
