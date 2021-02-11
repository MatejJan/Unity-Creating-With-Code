using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float horsePower = 20000;
    [SerializeField]
    private float turnSpeed = 70;

    private float forwardInput;
    private float horizontalInput;

    private Rigidbody rigidbody;
    [SerializeField]
    private GameObject centerOfMass;
    [SerializeField]
    private TextMeshProUGUI speedText;

    // Start is called before the first frame update.
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.centerOfMass = centerOfMass.transform.localPosition;
    }

    // Update is called once per frame.
    void FixedUpdate()
    {
        // Get input.
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // Move the vehicle forward.
        rigidbody.AddRelativeForce(Vector3.forward * horsePower * forwardInput);

        // Rotate the vehicle.
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        float speedKph = rigidbody.velocity.magnitude * 3.6f;
        speedText.text = $"Speed: {speedKph:0.} km/h";
    }
}
