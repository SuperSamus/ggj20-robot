using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legs : RobotPart
{
    private Rigidbody rb;
    public float movementForce = 1;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void AttachedAction(float firstInput, float secondInput)
    {
        //Move sull'entity
    }

    public override void DetachedAction(float firstInput, float secondInput)
    {
        Move(firstInput, secondInput);
    }

    public void Move(float z, float x)
    {
        if (x != 0)
        {
            //attachedToEntity.rb.AddForce(transform.right * x * movementForce);
            attachedToEntity.rb.AddForce(Vector3.right * -x * movementForce);
            attachedToEntity.transform.LookAt(attachedToEntity.transform.position + Vector3.right * -x);
        }
        else if (z != 0)
        {
            // attachedToEntity.rb.AddForce(transform.forward * z * movementForce);
            attachedToEntity.rb.AddForce(Vector3.forward * z * movementForce);
            attachedToEntity.transform.LookAt(attachedToEntity.transform.position + Vector3.forward * z);
        }

        animator.Play("Walk");
    }
}
