using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class MovimientoMoneda : MonoBehaviour
{
    [SerializeField] private float velocitat;
    private Collider collider;
    private Vector3 direccionActual;
    private float tiempoParaCambio = 2f;
    private float tiempoTranscurrido = 0f;
    [SerializeField] private Marcador marcador;

    void Start()
    {
        velocitat = 6f;
        collider = GetComponent<Collider>();
        direccionActual = movimientoMoneda();
        direccionActual.y = 0f;
    }

    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;

        if (tiempoTranscurrido >= tiempoParaCambio)
        {
            direccionActual = movimientoMoneda();
            tiempoTranscurrido = 0f;
        }

        transform.Translate(direccionActual * velocitat * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {

            marcador.sumarMonedas();
            marcador.escudoJugador();
            Destroy(gameObject);
           
        }
        else
        {
            Destroy(gameObject, 6f);
        }
    }

    public Vector3 movimientoMoneda()
    {
        float angulo = Random.Range(0f, Mathf.PI * 2f);
        float x = Mathf.Cos(angulo);
        float y = Mathf.Sin(angulo);
        return new Vector3(x, y, 0f).normalized;
    }
}
