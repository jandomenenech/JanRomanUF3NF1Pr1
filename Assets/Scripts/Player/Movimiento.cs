using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private Rigidbody rb;
    public float velocitat; 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        velocitat = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;
        rb.velocity = moveDirection * velocitat * Time.deltaTime;
    }
}
