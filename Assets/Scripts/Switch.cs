using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    bool pressed;
    public Func<bool> switchChanged;

    public bool isPressed() {
        return pressed;
    }
    public void setSwitch(bool state) {
        pressed = state;
        switchChanged.Invoke();
    }
    public void OnTriggerEnter(Collider other) {
        setSwitch(true);
    }

    public void OnTriggerExit(Collider other) {
        setSwitch(false);
    }
}
