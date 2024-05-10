using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;
    [SerializeField] public List<GameObject> objetos;
    [SerializeField] private GameObject puntuacion;
    void Start()
    {
        puntuacion.SetActive(false);
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void derrota()
    {
        gameOver.SetActive(true);
        puntuacion.SetActive(true);
        foreach (GameObject a in objetos)
        {
            a.SetActive(false);
            
        }
    }
    public void añadirALaLista(GameObject a)
    {
        objetos.Add(a);
    }
}
