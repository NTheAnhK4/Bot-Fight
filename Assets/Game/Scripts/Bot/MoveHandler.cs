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
    protected override void LoadComponent()
    {
        base.LoadComponent();
        speed = 1;
        weight = 2;
        direction = Vector3.right;
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
    }

   

   
}
