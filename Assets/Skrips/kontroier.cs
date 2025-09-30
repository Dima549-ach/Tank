using UnityEngine;

[RequireComponent(typeof(Rigidbody))]


public class kontroier : MonoBehaviour
{
    [SerializeField] private float shift = 1;
    private Rigidbody rb;
    [SerializeField] private float Speed;
    [SerializeField] private float maxSpeed = 20f;
    private  Vector3 LeftTrack;
    private Vector3 rightTrack;
    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(LeftTrack, Vector3.one);
        Gizmos.DrawCube(rightTrack, Vector3.one);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rightTrack = transform.position + (transform.right * shift);
        LeftTrack = transform.position - (transform.right * shift);
        if (Input.GetKey(KeyCode.W))
        {
           rb.AddForceAtPosition(-transform.forward * Speed,);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForceAtPosition(transform.right * Speed,);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForceAtPosition(-transform.right * Speed,);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForceAtPosition(transform.forward * Speed,);
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
