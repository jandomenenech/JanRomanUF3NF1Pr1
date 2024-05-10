using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movimiento : MonoBehaviour
{
    private Rigidbody rb;
    public float velocitat;
    private Collider collider;
    [SerializeField] Marcador marcador;
    [SerializeField] private GameOver derrota;
    [SerializeField] private TextMeshProUGUI puntuacion;

    [Header("Extra")]
    public GameObject jugador;
    public GameObject nuevoMesh;
    private MeshRenderer jugadorMeshRenderer;
    private MeshFilter jugadorMeshFilter;
    private Mesh originalMesh;
    private bool invulnerable = false;
    [SerializeField] private Enemy enemy;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        velocitat = 1000f;
        collider = GetComponent<Collider>();
        originalMesh = GetComponent<Mesh>();
        jugadorMeshFilter = GetComponent<MeshFilter>();
        jugadorMeshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;
        rb.velocity = moveDirection * velocitat * Time.deltaTime;
        if ((marcador.contadorM - marcador.contadorE) < 0)
        {
            derrota.derrota();
            Time.timeScale = 0;
            gameObject.SetActive(false);
           
        }

        puntuacion.text = "Puntacion: " + marcador.contadorM;
        


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Enemy"))
        {
            marcador.sumarEnemigoTocado();
            marcador.escudoJugador();
            StartCoroutine(ActivarInvulnerabilidad(2f));

        }
    }

    IEnumerator ActivarInvulnerabilidad(float duracion)
    {
        invulnerable = true;
        for (float t = 0; t < duracion; t += Time.deltaTime)
        {
            jugadorMeshRenderer.enabled = !jugadorMeshRenderer.enabled;
            yield return new WaitForSeconds(0.5f);
        }
        invulnerable = false;
        jugadorMeshRenderer.enabled = true;

    }
}
