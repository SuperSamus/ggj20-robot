using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadPart : RobotPart
{
    public GameObject shootHole;
    public GameObject lineObject;

    public float timeToDestroyLaser;
    private GameObject instantiatedLaser;
    public Material mat1, mat2;
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
        if (instantiatedLaser == null)
        {
            RaycastHit hit;
            var shotStartPosition = shootHole.transform.position;
            Vector3 endPosition = shotStartPosition + transform.forward * 100f;
            if (Physics.Raycast(shotStartPosition, transform.forward, out hit, 100f))
            {
                if (hit.transform.gameObject.GetComponent<Switch>())
                {
                    hit.transform.gameObject.GetComponent<Switch>().setSwitch(true);
                }
                endPosition = hit.point;
            }
            CreateLaser(shotStartPosition, endPosition);
        }
    }

    public void CreateLaser(Vector3 from, Vector3 to)
    {
        instantiatedLaser = Instantiate(lineObject);
        var lineR = instantiatedLaser.GetComponent<LineRenderer>();
        var lineR2 = instantiatedLaser.transform.GetChild(0).GetComponent<LineRenderer>();
        lineR.SetPosition(0, from);
        lineR.SetPosition(1, to);
        lineR2.SetPosition(0, from);
        lineR2.SetPosition(1, to);
        StartCoroutine(DestroyLaser());
        
    }


    public IEnumerator DestroyLaser()
    {
        yield return new WaitForSeconds(timeToDestroyLaser);
        Destroy(instantiatedLaser);
        instantiatedLaser = null;
    }
}
