using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Marcador : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI contadorMonedas;
    [SerializeField] private TextMeshProUGUI contadorEnemigos;
    [SerializeField] private TextMeshProUGUI escudo;
    private int contadorM;
    private int contadorE;


    void Start()
    {
        contadorM = 0;
        contadorE = 0;
        contadorMonedas.text = "Contador Monedas: " + contadorM;
        contadorEnemigos.text = "Contador Enemigos: " + contadorE;
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    public void sumarMonedas()
    {
        contadorM+= 1;
        contadorMonedas.text = "Contador Monedas:" + contadorM;
    }

    public void escudoJugador()
    {
        escudo.text = "Escudo jugador: " + (contadorM - contadorE);
    }

    public void sumarEnemigoTocado()
    {
        contadorE += 1;
        contadorEnemigos.text = "Enemigos tocados:" + contadorE;
    }
}
