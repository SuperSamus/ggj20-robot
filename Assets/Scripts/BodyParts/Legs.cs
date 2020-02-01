using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legs : RobotPart
{
    private Rigidbody rb;
    public float movementForce = 1;

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

    public void Move(float x, float z)
    {
        if (x != 0)
        {
            attachedToEntity.rb.AddForce(transform.right * x * movementForce);
        }
        else if(z != 0)
        {
            attachedToEntity.rb.AddForce(transform.forward * z * movementForce);
        }
    }
}
