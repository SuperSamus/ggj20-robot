using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : Activatable
{
    public Vector3 speed;

    public void invert() {
        speed *= -1;
        var renderer = GetComponentsInChildren<Renderer>()[0];
        const string propertyName = "Vector1_ECD6E8FA";
        renderer.material.SetFloat(propertyName, renderer.material.GetFloat(propertyName) * -1);
    }

    public void OnCollisionStay(Collision other) {
        if (active) {
            other.gameObject.GetComponent<Rigidbody>().AddForce(speed);
        }
    }
}
