using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchResetter : MonoBehaviour
{

    public List<Switch> switches = new List<Switch>();

    // Start is called before the first frame update
    void resetSwitch() {
        foreach (var s in switches)
        {
            s.setSwitch(false);
        }
    }
    
}
