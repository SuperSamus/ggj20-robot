using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotInputManager : MonoBehaviour
{ 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckInputs(List<RobotPart> parts)
    {
        foreach(var part in parts)
        {

            if(part.isAttached)
            {
                if(part.attachedInput.inputType == InputType.axis)
                {
                    var x = Input.GetAxis("Horizontal");
                    var z = Input.GetAxis("Vertical");
                    if((x != 0 || z != 0))
                    {
                        part.AttachedAction(x, z);
                    }
                }
                else
                {
                    if(Input.GetKey(part.attachedInput.key))
                    {
                        part.AttachedAction(1, 0);
                    }
                }
            }
            else
            {

            }
        }
    }
}
