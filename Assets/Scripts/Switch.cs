using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    bool pressed;
    public SwitchType type;
    public string activatedByTag;
    public Action switchChanged;

    public bool isPressed() {
        return pressed;
    }
    public void setSwitch(bool state) {
        pressed = state;
        switchChanged.Invoke();
    }

    public void OnTriggerEnter(Collider other) {
        if ((type == SwitchType.Press || type == SwitchType.Hold) && (activatedByTag == "" || other.CompareTag(activatedByTag))) {
            setSwitch(true);
        }
    }

    public void OnTriggerExit(Collider other) {
        if (type == SwitchType.Hold && (activatedByTag == "" || other.CompareTag(activatedByTag))) {
            setSwitch(false);
        }
    }
}

public enum SwitchType {Manual, Press, Hold};
