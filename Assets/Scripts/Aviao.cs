using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aviao : MonoBehaviour
{

    public float forca;
    private Rigidbody2D _corpoRigido;
    private GameOver _gameOver;
    private Animator _animacao;
    private Transform _transform;
    private bool _deveImpulsionar;
    private Vector3 _posicaoInicial;
    private AudioSource _somColisao;

    void Awake()
    {
        this._corpoRigido = this.GetComponent<Rigidbody2D>();
        this._animacao = this.GetComponent<Animator>();
        this._transform = this.GetComponent<Transform>();
        this._somColisao = this.GetComponent<AudioSource>();

        this._corpoRigido.simulated = false;
        this._posicaoInicial = this._transform.position;
    }

    void Start()
    {
        this._gameOver = GameObject.FindObjectOfType<GameOver>();
    }

    void Update()
    {
        if (GameOver.estaJogando)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                this._corpoRigido.simulated = true;
                this._deveImpulsionar = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (GameOver.estaJogando)
        {
            if (this._deveImpulsionar)
            {
                this._impulsionar();
            }
            
            this._animacao.SetFloat("VelocidadeY", this._corpoRigido.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D outro)
    {
        this._somColisao.Play();
        this._gameOver.finalizarJogo();
    }

    public void reiniciar()
    {
        this.transform.position = this._posicaoInicial;
    }

    private void _impulsionar()
    {
        this._corpoRigido.velocity = Vector2.zero;
        this._corpoRigido.AddForce(Vector2.up * this.forca, ForceMode2D.Impulse);
        this._deveImpulsionar = false;
    }

}
