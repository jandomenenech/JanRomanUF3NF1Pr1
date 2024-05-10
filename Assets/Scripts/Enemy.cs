using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform player;
    public float velocidad = 5f; 

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 direccion = (player.position - transform.position).normalized;
        Quaternion rotacion = Quaternion.LookRotation(direccion);
        rb.velocity = direccion * velocidad;
    }

    
    void Update()
    {
        if(rb != null )
        {
            Vector3 direccion = (player.position - transform.position).normalized;
            Quaternion rotacion = Quaternion.LookRotation(direccion);
            rb.velocity = direccion * velocidad;
        }
       
    }

 
}
