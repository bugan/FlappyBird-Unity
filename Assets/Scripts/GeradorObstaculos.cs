using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorObstaculos : MonoBehaviour
{
    [SerializeField]
    private float tempoParaGerarFacil;
    [SerializeField]
    private float tempoParaGerarDificil;
    [SerializeField]
    private GameObject obstaculoPrefab;
    private float cronometro;
    private bool iniciarGeracao;
    private ControleDeDificuldade controleDeDificuldade;

    private void Awake()
    {
        this.cronometro = this.tempoParaGerarFacil;
    }
    private void Start()
    {
        this.controleDeDificuldade = GameObject.FindObjectOfType<ControleDeDificuldade>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("botaoDireitoMouse"))
        {
            this.iniciarGeracao = true;
        }

        if (this.iniciarGeracao)
        {
            this.cronometro -= Time.deltaTime;
            if (this.cronometro < 0)
            {
                this.Gerar();
                this.cronometro = Mathf.Lerp(
                    this.tempoParaGerarFacil,
                    this.tempoParaGerarDificil,
                    this.controleDeDificuldade.Dificuldade
                    );
            }
        }
    }

    private void Gerar()
    {
        GameObject obstaculo = GameObject.Instantiate(this.obstaculoPrefab, this.transform, false);
        obstaculo.GetComponent<Obstaculo>().Inicializar();
    }
}
