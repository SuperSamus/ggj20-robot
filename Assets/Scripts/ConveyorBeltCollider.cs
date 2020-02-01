using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltCollider : MonoBehaviour
{
    public List<ConveyorBelt> conveyorBelts = new List<ConveyorBelt>();

    void OnTriggerEnter(Collider other) {
        foreach (var conveyor in conveyorBelts)
        {
           conveyor.GetComponent<ConveyorBelt>().invert(); 
        }
    }
}
