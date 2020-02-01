using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activatable : MonoBehaviour
{
    public bool active;
    public List<Switch> switches = new List<Switch>();

    void allButtonsPushed() {
        foreach (var s in switches)
        {
            if (!s.isPressed()) {
                active = false;
                return;
            }
        }
        active = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (var s in switches)
        {
            s.switchChanged += allButtonsPushed;
        }
    }
}
