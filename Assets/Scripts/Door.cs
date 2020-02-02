using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Activatable
{
    private GameObject[] children = new GameObject[2];
    private BoxCollider c;
    void Start() {
        children[0] = transform.GetChild(0).gameObject;
        children[1] = transform.GetChild(1).gameObject;
        c = GetComponent<BoxCollider>();
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
        foreach (var child in children)
        {
            child.SetActive(false);
        }
        c.enabled = false;
    }

    void close() {
        foreach (var child in children)
        {
            child.SetActive(true);
        }
        c.enabled = true;
    }
}
