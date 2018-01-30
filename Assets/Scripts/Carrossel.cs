using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrossel : MonoBehaviour
{
    [SerializeField]
    private VariavelCompartilhadaFloat velocidade;
    private Vector3 posicaoInicial;
    private float tamanhoRealDaImagem;

    private void Awake()
    {
        this.posicaoInicial = this.transform.localPosition;

        float tamanhoImagem = this.GetComponent<SpriteRenderer>().size.x;
        float escalaImagem = this.transform.localScale.x;
        this.tamanhoRealDaImagem = tamanhoImagem * escalaImagem;
    }

    private void Update()
    {
        float deslocamento = Mathf.Repeat(Time.time * this.velocidade.valor, this.tamanhoRealDaImagem);
        this.transform.localPosition = this.posicaoInicial + Vector3.left * deslocamento;
    }
}
