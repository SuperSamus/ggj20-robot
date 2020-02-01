using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    bool pressed;
    public string activatedByTag;
    public Action switchChanged;

    public bool isPressed() {
        return pressed;
    }
    public void setSwitch(bool state) {
        pressed = state;
        switchChanged.Invoke();
    }
}
