using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public Vector3 speed;

    public void OnCollisionStay(Collision other) {
        var otherRb = other.gameObject.GetComponent<Rigidbody>();
        otherRb.velocity = speed;
    }

    public void OnCollisionExit(Collision other) {
        var otherRb = other.gameObject.GetComponent<Rigidbody>();
        otherRb.velocity = Vector3.zero;
    }
}
