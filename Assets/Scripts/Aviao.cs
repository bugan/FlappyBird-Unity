using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aviao : MonoBehaviour
{
    [SerializeField]
    private float forca;
    private Rigidbody2D corpoRigido;
    private Diretor diretor;
    private Animator animacao;
    private PolygonCollider2D colisor;
    private bool deveImpulsionar;
    private Vector3 posicaoInicial;
    private AudioSource somColisao;

    private void Awake()
    {
        this.corpoRigido = this.GetComponent<Rigidbody2D>();
        this.animacao = this.GetComponent<Animator>();
        this.somColisao = this.GetComponent<AudioSource>();
        this.colisor = this.GetComponent<PolygonCollider2D>();

        this.corpoRigido.simulated = false;
        this.posicaoInicial = this.transform.position;
    }

    private void Start()
    {
        this.diretor = GameObject.FindObjectOfType<Diretor>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("botaoDireitoMouse"))
        {
            this.corpoRigido.simulated = true;
            this.deveImpulsionar = true;
        }
    }

    private void FixedUpdate()
    {
        if (this.deveImpulsionar)
        {
            this.Impulsionar();
        }

        this.animacao.SetFloat("VelocidadeY", this.corpoRigido.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.tag != "Teto")
        {
            this.somColisao.Play();
            this.diretor.FinalizarJogo();
            this.colisor.enabled = false;
            this.corpoRigido.simulated = false;
        }
    }

    public void Reiniciar()
    {
        this.transform.position = this.posicaoInicial;
        this.colisor.enabled = true;
        this.corpoRigido.velocity = Vector2.zero;
        this.corpoRigido.simulated = true;
    }

    private void Impulsionar()
    {
        this.corpoRigido.velocity = Vector2.zero;
        this.corpoRigido.AddForce(Vector2.up * this.forca, ForceMode2D.Impulse);
        this.deveImpulsionar = false;
    }
}
