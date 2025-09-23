using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]


public class kontroier : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float Speed;
    [SerializeField] private float maxSpeed = 20f;
    private Rigidbody rf;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(-transform.forward * Speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * Speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-transform.right * Speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(transform.forward * Speed);
        }
        LimitSpeed();
        print(rb.linearVelocity.magnitude + " Скорость танка");
    }
    private void LimitSpeed()
    {
        float currentSpeed = rb.linearVelocity.magnitude;
        if (currentSpeed > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity * maxSpeed;
            print(rb.linearVelocity.magnitude);
        }
    }
}
