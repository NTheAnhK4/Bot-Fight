using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimHandler : ChildBehavior
{
    protected override void Start()
    {
        base.Start();
        transform.rotation = Quaternion.Euler(new Vector3(transform.localScale.x, transform.parent.tag.Equals("Player") ? 0 : 180, 0));
    }
}
