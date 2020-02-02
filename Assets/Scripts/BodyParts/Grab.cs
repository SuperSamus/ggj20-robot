using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : RobotPart
{
    private GameObject grabbedObject;
    public Animator animator;

    public bool isGrabbing;
    public float grabRadius = 1f, maxDistance = 2f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void DetachedAction(float firstInput, float secondInput)
    {
        if (!isGrabbing)
        {
            DoGrab();
        }
        else
        {
            ResetGrab();
        }
    }

    public override void AttachedAction(float firstInput, float secondInput)
    {
        if (!isGrabbing)
        {
            DoGrab();
        }
        else
        {
            Debug.Log("Ho resettato xd");
            ResetGrab();
        }
    }

    public void DoGrab()
    {
        var colliders = Physics.SphereCastAll(transform.position, grabRadius, transform.forward,maxDistance);
        foreach(var coll in colliders)
        {
            if(coll.collider.tag == "Grabbable")
            {
                isGrabbing = true;
                grabbedObject = coll.collider.gameObject;
                grabbedObject.transform.position = transform.position + transform.forward * 0.5f;
                grabbedObject.transform.parent = gameObject.transform;
                Debug.Log("Ho settato a parent");
                grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                grabbedObject.GetComponent<Collider>().isTrigger = true;
                animator.Play("Grab");
                return;
            }
        }
        
    }

    public void ResetGrab()
    {
        grabbedObject.transform.parent = null;
        grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
        grabbedObject.GetComponent<Collider>().isTrigger = false;
        isGrabbing = false;
        animator.Play("NoGrab");
    }
}
