using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public const float POSICAO_X_FORA_DA_CAMERA = -18;
    public float velocidade;
    public float variacaoDaPosicao;
    private Transform _transform;
    private Transform _obstaculoBaixo;
    private Transform _obstaculoCima;
    private Pontuacao _pontuacao;
    private bool _pontuou;
    private float _posicaoJogador;
    private AudioSource _somPontuacao;
    void Awake()
    {
        this._transform = this.GetComponent<Transform>();
        this._somPontuacao = this.GetComponent<AudioSource>();
        this._pontuou = false;
        this._posicaoJogador = GameObject.FindObjectOfType<Aviao>().transform.position.x;
    }

    void Start()
    {
        this._pontuacao = GameObject.FindObjectOfType<Pontuacao>();
    }

    void Update()
    {
        if (GameOver.estaJogando)
        {
            //outra opção seria fazer: Vector3.left * this.velocidade * Time.deltaTime
            this._transform.Translate(-1.0f * this.velocidade * Time.deltaTime, 0.0f, 0.0f);

            if (!this._pontuou && this._transform.position.x < this._posicaoJogador)
            {
                this._pontuacao.adicionarPontos(1);
                this._pontuou = true;
                this._somPontuacao.Play();
            }

            if (this._transform.position.x < POSICAO_X_FORA_DA_CAMERA)
            {
                GameObject.Destroy(this.gameObject);
            }
        }
    }

    public void inicializa()
    {
        float variacao = Random.Range(-this.variacaoDaPosicao, this.variacaoDaPosicao);
        this._transform.position = this._transform.position + new Vector3(0, variacao, 0);
    }

    public void destruir()
    {
        GameObject.Destroy(this.gameObject);
    }
}
