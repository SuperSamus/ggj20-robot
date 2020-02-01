using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPart : MonoBehaviour
{
    public bool upperIsStackable, downIsStackable;
    public bool isAttached;
    public MyInput detachedInput, attachedInput;

    public virtual void AttachedAction(float firstInput, float secondInput)
    {
        
    }

    public virtual void DetachedAction(float firstInput, float secondInput)
    {

    }
}

[System.Serializable]
public class MyInput
{
    public InputType inputType;
    public KeyCode key;
}

public enum InputType { axis, keycode};
