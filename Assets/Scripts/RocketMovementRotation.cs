using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovementRotation : MonoBehaviour
{

    bool activeRot = false;
    public Rigidbody rb;

    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(10, 100, 0), ForceMode.Impulse);
            activeRot = true;
        }

        if (activeRot)
            transform.up = (rb.velocity.normalized);

        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y + 8.5f, transform.position.z - 10);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            rb.AddTorque(new Vector3(0, 0, Random.Range(-5, -15)), ForceMode.Impulse);
            activeRot = false;
        }
    }

}
