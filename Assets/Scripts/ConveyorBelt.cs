using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : Activatable
{
    public Vector3 speed;

    public void invert() {
        speed *= -1;
    }

    public void OnCollisionStay(Collision other) {
        if (active) {
            other.gameObject.GetComponent<Rigidbody>().AddForce(speed);
        }
    }
}
