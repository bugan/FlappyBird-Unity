using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorObstaculos : MonoBehaviour
{
    public float tempoParaGerar;
    public GameObject obstaculoPrefab;
    private float _cronometro;
    private bool _iniciarGeracao;

    void Awake()
    {
        this._cronometro = this.tempoParaGerar;
        this._iniciarGeracao = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            this._iniciarGeracao = true;
        }

        if (GameOver.estaJogando && this._iniciarGeracao)
        {
            this._cronometro -= Time.deltaTime;
            if (this._cronometro < 0)
            {
                this._gerar();
                this._cronometro = this.tempoParaGerar;
            }
        }
    }

    private void _gerar()
    {
        GameObject obstaculo = GameObject.Instantiate(this.obstaculoPrefab, this.transform, false);
        obstaculo.GetComponent<Obstaculo>().inicializa();
    }
}
