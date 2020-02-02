using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    public Vector3 distanceFromPlayer;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + distanceFromPlayer;
    }
}
