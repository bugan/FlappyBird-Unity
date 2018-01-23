using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrossel : MonoBehaviour
{
    public float velocidade;
    private Transform _transform;
    private Vector3 _posicaoInicial;
    private float _tamanhoImagem;
    void Awake()
    {
        this._transform = this.GetComponent<Transform>();
        this._posicaoInicial = this._transform.localPosition;
        this._tamanhoImagem = this.GetComponent<SpriteRenderer>().size.x;
        this._tamanhoImagem = this._tamanhoImagem * this.transform.localScale.x;
    }

    void Update()
    {
        if (GameOver.estaJogando)
        {
            float variacaoDaPosicao = Mathf.Repeat(Time.time * this.velocidade, this._tamanhoImagem);
            this._transform.localPosition =  this._posicaoInicial + Vector3.left * variacaoDaPosicao;
        }
    }
}
