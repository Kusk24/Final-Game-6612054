using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // public float speed = 20f;
    // public float turnSpeed = 45f;
    // public float horizontalInput;
    // public float forwardInput;

    private float speed = 20f;
    private float turnSpeed = 60f;
    private float horizontalInput;
    private float forwardInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        //Move the vehicle based on input per one second;
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        //rotate the vehicle based on input per one second;
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        // transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
    }
}
