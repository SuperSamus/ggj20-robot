using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public RobotPart selectedPart;
    public List<RobotPart> allParts;

    public KeyCode switchUp, switchDown;

    public void Start()
    {
        allParts = FindObjectsOfType<RobotPart>().ToList();
    }

    public void Update()
    {
        if (Input.GetKeyDown(switchUp)) GoNext();
        else if (Input.GetKeyDown(switchDown)) GoPrevious();
    }

    public void GoNext()
    {
        List<RobotPart> next = new List<RobotPart>();
        for (int i = 0; i < allParts.Count; i++)
        {
            if(allParts[i].partNumber > selectedPart.partNumber)
            {
                next.Add(allParts[i]);
            }
        }

        next = next.OrderBy(x => x.partNumber).ToList();

        if(next.Count == 0)
        {
            selectedPart = allParts.OrderBy(x=> x.partNumber).ToList().First();
        }
        else
        {
            selectedPart = next[0];
        }
    }

    public void GoPrevious()
    {
        List<RobotPart> next = new List<RobotPart>();
        for (int i = 0; i < allParts.Count; i++)
        {
            if (allParts[i].partNumber < selectedPart.partNumber)
            {
                next.Add(allParts[i]);
            }
        }


        next = next.OrderByDescending(x => x.partNumber).ToList();

        if (next.Count == 0)
        {
            selectedPart = allParts.OrderBy(x => x.partNumber).ToList().Last();
        }
        else
        {
            selectedPart = next[0];
        }
    }
}
