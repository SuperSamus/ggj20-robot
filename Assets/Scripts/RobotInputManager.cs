using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotInputManager : MonoBehaviour
{
    public GameManager gameManager;
    public KeyCode dropDownKey, getCloseParts;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInputs(gameManager.selectedPart);
    }

    public void CheckInputs(RobotPart part)
    {
        if(Input.GetKeyDown(dropDownKey))
        {
            gameManager.selectedPart.attachedToEntity.RemoveRobotPart(gameManager.selectedPart);
        }
        else if(Input.GetKeyDown(getCloseParts))
        {
            gameManager.selectedPart.attachedToEntity.CheckProximity(gameManager.selectedPart);
        }

        if (part.isAttached)
        {
            if (part.attachedInput.inputType == InputType.axis)
            {
                var x = Input.GetAxis("Horizontal");
                var z = Input.GetAxis("Vertical");
                if ((x != 0 || z != 0))
                {
                    part.AttachedAction(x, z);
                }
            }
            else
            {
                if (Input.GetKey(part.attachedInput.key))
                {
                    part.AttachedAction(1, 0);
                }
            }
        }
        else
        {
            if (part.detachedInput.inputType == InputType.axis)
            {
                var x = Input.GetAxis("Horizontal");
                var z = Input.GetAxis("Vertical");
                if ((x != 0 || z != 0))
                {
                    part.DetachedAction(x, z);
                }
            }
            else
            {
                if (Input.GetKey(part.detachedInput.key))
                {
                    part.DetachedAction(1, 0);
                }
            }
        }
    }
}

