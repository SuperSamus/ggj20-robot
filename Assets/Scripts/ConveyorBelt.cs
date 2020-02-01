using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public Vector3 speed;
    public float timeToInvert;

    public void invert() {
        speed *= -1;
    }

    public void OnCollisionStay(Collision other) {
        other.gameObject.GetComponent<Rigidbody>().AddForce(speed);
    }

}
