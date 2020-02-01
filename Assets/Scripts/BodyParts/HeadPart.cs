using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadPart : RobotPart
{
    public GameObject shootHole;
    public GameObject lineObject;

    public float timeToDestroyLaser;
    // Start is called before the first frame update
    void Start()
    {
    }

    public override void AttachedAction(float firstInput, float secondInput)
    {
        ShootLaser();
    }

    public override void DetachedAction(float firstInput, float secondInput)
    {
        ShootLaser();
    }
    
    public void ShootLaser()
    {
        if (lineObject == null)
        {
            RaycastHit hit;
            var shotStartPosition = shootHole.transform.position;
            Vector3 endPosition = shotStartPosition + transform.forward * 100f;
            if (Physics.Raycast(shotStartPosition, transform.forward, out hit, 100f))
            {
                if (hit.transform.gameObject.GetComponent<Switch>())
                {
                    //Da fare
                }
                endPosition = hit.point;
            }
            CreateLaser(shotStartPosition, endPosition);
        }
    }

    public void CreateLaser(Vector3 from, Vector3 to)
    {
        lineObject = new GameObject("lineRenderer");
        var lineR = lineObject.AddComponent<LineRenderer>();
        lineR.SetPosition(0, from);
        lineR.SetPosition(1, to);
        StartCoroutine(DestroyLaser());
        
    }

    public IEnumerator DestroyLaser()
    {
        yield return new WaitForSeconds(timeToDestroyLaser);
        Destroy(lineObject, timeToDestroyLaser);
        lineObject = null;
    }
}
