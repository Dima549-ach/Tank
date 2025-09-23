    using UnityEngine;
    [RequireComponent(typeof(Rigidbody))]
    public class kontroier : MonoBehaviour
{     
    public class TankSpeedController : MonoBehaviour
        
     private Rigidbody rb ;
    [SerializeField] private float Speed ;
        [SerializeField] private float maxSpeed = 20f;
        private Rigidbody rf;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
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
    }
    void LimitSpeed()
        {
            LimitSpeed();
        }
           private void LimitSpeed()
        {
            float currentSpeed=rb.velocity.magnitude;
            if (currentSpeed > maxSpeed) 
            {
                rb.velocity = rb.velocity * maxSpeed;
                print(rb.velocity.magnitude);
        }









    }
}
