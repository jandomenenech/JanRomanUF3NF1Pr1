using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarMonedas : MonoBehaviour
{
    [SerializeField]private GameObject moneda;
    private float tiempo;

    void Start()
    {
        tiempo = Time.time;
    }

    void Update()
    {
        if (tiempo + 6 < Time.time)
        {
            generarMonedas();
            tiempo = Time.time;
        }
    }

    public void generarMonedas()
    {
        Quaternion rotacion = Quaternion.Euler(90f, 90f, 0f);
        GameObject nuevaMoneda = Instantiate(moneda, transform.position, rotacion);
    }
}
