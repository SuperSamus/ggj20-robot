using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dsakdsk : MonoBehaviour
{
    public float force;

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        rb.AddForce((z * transform.forward + x * transform.right).normalized * force);
    }
}
