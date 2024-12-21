
using System;
using UnityEngine;

public class ParentBehavior : MonoBehaviour
{
    protected virtual void LoadComponent(){
       
    }
    
 

    protected virtual void ResetValue()
    {
        
    }

    protected virtual void Reset()
    {
        LoadComponent();
        ResetValue();
    }

    protected virtual void OnEnable()
    {
        LoadComponent();
        ResetValue();
    }
    protected GameObject AddChildTransform(string transformName)
    {
        GameObject childObject = new GameObject(transformName);
        childObject.transform.parent = this.transform;
        childObject.transform.localPosition = Vector3.zero;
        childObject.transform.localRotation = Quaternion.identity;
        return childObject;
    }
}
