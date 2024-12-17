using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    private Rigidbody rb;
    public float speed = 10.0f;
    public float rotationForce = 10.0f;
    Vector3 rotation;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        HandleProjectile();
    }
    void FixedUpdate()
    {
        HandleMovement();
    }


    void HandleMovement()
    {
        rotation = new Vector3(0, Input.GetAxis("Horizontal"), 0);
        rb.AddTorque(rotation * rotationForce);
        rb.AddRelativeForce(transform.forward*Input.GetAxis("Vertical") * speed, ForceMode.VelocityChange);
    }

    void HandleProjectile()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(projectile, transform.position + transform.forward + transform.up, transform.rotation);
        }
    }

}
