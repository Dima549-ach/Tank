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
    [SerializeField] private float maxAngularSpeed = 5f;
    private void OnDrawGizmos();
    
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
            rb.AddForceAtPosition(transform.forward * Speed, rightTrack);
            rb.AddForceAtPosition(transform.forward * Speed, LeftTrack);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForceAtPosition(-transform.forward * Speed, rightTrack);
            rb.AddForceAtPosition(transform.forward * Speed, LeftTrack);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForceAtPosition(-transform.forward * Speed, LeftTrack);
            rb.AddForceAtPosition(transform.forward * Speed, rightTrack);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForceAtPosition(-transform.forward * Speed, rightTrack);
            rb.AddForceAtPosition(-transform.forward * Speed, LeftTrack);
        }
        LimitSpeed();
        print(rb.linearVelocity.magnitude + " Скорость танка");
        maxAngularSpeed1();
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
        rb.AddForceAtPosition(direction.normalized, transform.position);

    }
     void maxAngularSpeed1();
    {
        Vector3 currentAngularVelociti = rb.angularVelocity;
    currentAngularVelociti.x = Mathf.Clamp(currentAngularVelociti.x, -maxAngularSpeed, maxAngularSpeed);
    currentAngularVelociti.y = Mathf.Clamp(currentAngularVelociti.y, -maxAngularSpeed, maxAngularSpeed);
    currentAngularVelociti.z = Mathf.Clamp(currentAngularVelociti.z, -maxAngularSpeed, maxAngularSpeed);
    rb.angularVelocity = currentAngularVelociti;
   }
     
}
    

