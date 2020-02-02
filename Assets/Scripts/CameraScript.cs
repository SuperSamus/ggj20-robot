using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Vector3 distanceFromPlayer;

    void Update()
    {

        var activePart = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().selectedPart;
        transform.position = activePart.transform.position + distanceFromPlayer;
    }
}
