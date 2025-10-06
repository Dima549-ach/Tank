using UnityEngine;

[RequireComponent(typeof(Rigidbody))]


public class kontroier : MonoBehaviour
{
    [SerializeField] private float shift = 1;
    private Rigidbody rb;
    [SerializeField] private float Speed;
    [SerializeField] private float maxSpeed = 20f;
    private Vector3 LeftTrack;
    private Vector3 rightTrack;

    [SerializeField] private Transform body;

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(LeftTrack, Vector3.one * 0.1f);
        Gizmos.DrawCube(rightTrack, Vector3.one * 0.1f);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rightTrack = body.position + (transform.right.normalized * shift);
        LeftTrack = body.position - (transform.right.normalized * shift);

        if (Input.GetKey(KeyCode.W))
        {
           rb.AddForceAtPosition(-transform.forward * Speed, LeftTrack);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForceAtPosition(transform.right * Speed, LeftTrack);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForceAtPosition(-transform.right * Speed, LeftTrack);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForceAtPosition(transform.forward * Speed, LeftTrack);
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
    void ApplyForce()
    {
        Vector3 direction = rb.transform.position - transform.position;
        rb.AddForceAtPosition(direction.normalized,transform.position);

    }
    
    
}
