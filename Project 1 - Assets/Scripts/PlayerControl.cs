using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody point;
    [SerializeField] float speed = 6f;
    [SerializeField] float sprintSpeed = 20f;
    [SerializeField] float jump = 5f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    
    void Start()
    {
        point = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        float hValue = Input.GetAxis("Horizontal");
        float vValue = Input.GetAxis("Vertical");

        // character runs when pressing down left shift key and up arrow key.
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed;

       
        point.velocity = new Vector3(hValue * currentSpeed, point.velocity.y, vValue * currentSpeed);

        if (Input.GetButtonDown("Jump") && TenSet())
        {
            Jump();
        }
    }

    void Jump()
    {
        point.velocity = new Vector3(point.velocity.x, jump, point.velocity.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Value"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }

    bool TenSet()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
