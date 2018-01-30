using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    [SerializeField]
    private VariavelCompartilhadaFloat velocidade;
    [SerializeField]
    private float variacaoDaPosicao;
    private Pontuacao pontuacao;
    private bool pontuou;
    private float posicaoJogador;
    
    private void Start()
    {
        this.posicaoJogador = GameObject.FindObjectOfType<Aviao>().transform.position.x;
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();
    }

    private void Update()
    {
        this.transform.Translate(Vector3.left * this.velocidade.valor * Time.deltaTime);

        if (!this.pontuou && this.transform.position.x < this.posicaoJogador)
        {
            this.pontuacao.Pontuar();
            this.pontuou = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D outro)
    {
        this.Destruir();
    }

    public void Inicializar()
    {
        float variacao = Random.Range(-this.variacaoDaPosicao, this.variacaoDaPosicao);
        this.transform.position = this.transform.position + new Vector3(0, variacao, 0);
    }

    public void Destruir()
    {
        GameObject.Destroy(this.gameObject);
    }
}
