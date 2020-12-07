using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 30;
    private float turnSpeed = 70;

    private float forwardInput;
    private float horizontalInput;

    // Start is called before the first frame update.
    void Start()
    {

    }

    // Update is called once per frame.
    void Update()
    {
        // Get input.
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // Move the vehicle forward.
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        // Rotate the vehicle.
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
