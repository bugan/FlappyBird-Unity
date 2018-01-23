using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static bool estaJogando;
    private GameObject _interfaceGrafica;
    void Start()
    {
        GameOver.estaJogando = true;
        this._interfaceGrafica = this.GetComponentsInChildren<RectTransform>(true)[1].gameObject;
        this._interfaceGrafica.SetActive(false);
    }
    void Update()
    {
        if (!GameOver.estaJogando && Input.GetButton("Fire1"))
        {
            this.reiniciar();
        }
    }
    public void finalizarJogo()
    {
        GameOver.estaJogando = false;
        this._interfaceGrafica.SetActive(true);
    }

    public void reiniciar()
    {
        this._interfaceGrafica.SetActive(false);
        GameObject.FindObjectOfType<Aviao>().reiniciar();
        GameObject.FindObjectOfType<Pontuacao>().reiniciar();
        this._destruirObstaculos();

        GameOver.estaJogando = true;
    }

    private void _destruirObstaculos()
    {
        Obstaculo[] obstaculos = GameObject.FindObjectsOfType<Obstaculo>();
        for (int i = 0; i < obstaculos.Length; i++)
        {
            obstaculos[i].destruir();
        }
    }
}
