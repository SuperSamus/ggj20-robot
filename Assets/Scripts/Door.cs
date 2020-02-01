using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Activatable
{
    void Update()
    {
        if (active) {
            gameObject.SetActive(false);
        }
    }
}
