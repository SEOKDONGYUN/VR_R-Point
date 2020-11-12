using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTargetReached : MonoBehaviour
{
    public float thresholud = 0.02f;
    public Transform target;
    public UnityEvent OnReached;
    private bool wasReached = false;

    public void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if(distance < thresholud && !wasReached)
        {
            //Reached the target
            OnReached.Invoke();
            wasReached = true;
        }
        else if(distance >= thresholud)
        {
            wasReached = false;
        }
    }
}
