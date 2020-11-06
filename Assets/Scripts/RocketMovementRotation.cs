using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovementRotation : MonoBehaviour
{

    bool activeRot = false;
    public Rigidbody rb;

    public int horiz = 50;
    public int liluzivert = 50;

    bool once = true;

    void Start()
    {

    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && once)
        {
            rb.AddForce(new Vector3(horiz, liluzivert, 0), ForceMode.Impulse);
            activeRot = true;
            once = false;
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
