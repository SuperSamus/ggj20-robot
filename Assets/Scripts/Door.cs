using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public List<Switch> switches = new List<Switch>();

    bool allButtonsPushed() {
        foreach (var s in switches)
        {
            if (!s.pressed) {
                return false;
            }
        }
        gameObject.SetActive(false);
        return true;
    }


    // Start is called before the first frame update
    void Start()
    {
        foreach (var s in switches)
        {
            s.switchChanged += allButtonsPushed;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
