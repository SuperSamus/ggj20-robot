using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        gameObject.GetComponentInParent<ConveyorBelt>().invert();
    }
}
