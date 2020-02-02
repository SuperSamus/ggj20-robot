using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Activatable
{
    private MeshRenderer mr;
    private Collider c;
    void Start() {
        mr = GetComponent<MeshRenderer>();
        c = GetComponent<Collider>();
    }

    void Update()
    {
        if (active) {
            open();
        }
        else {
            close();
        }
    }

    void open() {
        mr.enabled = false;
        c.enabled = false;
    }

    void close() {
        mr.enabled = true;
        c.enabled = true;
    }
}
