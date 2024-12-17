using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    private Rigidbody rb;
    public float speed = 0.0f;
    public float jumpForce = 10f;
    Vector3 direction;
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
        HandleJump();
    }

    void HandleJump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void HandleMovement()
    {
        direction = new Vector3 (Input.GetAxis("Vertical") * Camera.main.transform.forward.x, 0, Input.GetAxis("Vertical") * Camera.main.transform.forward.z) +  
                    new Vector3 (Camera.main.transform.right.x * Input.GetAxis("Horizontal"), 0, Camera.main.transform.right.z * Input.GetAxis("Horizontal"));
        if (Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") == 0.0f)
        {
            rb.velocity = new Vector3 ( 0, rb.velocity.y, 0);
        }
        else
        { 
            transform.LookAt(transform.position + direction);
        }
        rb.velocity = new Vector3(direction.x * speed, rb.velocity.y, direction.z * speed);

    }

    void HandleProjectile()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(projectile, transform.position + transform.forward + transform.up, transform.rotation);
        }
    }

}
