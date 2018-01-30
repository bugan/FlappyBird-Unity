using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceGameOver : MonoBehaviour
{
    [SerializeField]
    private Text textoRecorde;
    [SerializeField]
    private Text valorRecorde;
    [SerializeField]
    private Image imagemMedalha;
    [SerializeField]
    private Sprite medalhaOuro;
    [SerializeField]
    private Sprite medalhaPrata;
    [SerializeField]
    private Sprite medalhaBronze;
    [SerializeField]
    private GameObject interfaceGrafica;
    private Pontuacao pontuacao;

    private void Start()
    {
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();
    }

    public void MostrarInterface()
    {
        this.interfaceGrafica.SetActive(true);
    }

    public void EsconderInterface()
    {
        this.interfaceGrafica.SetActive(false);
    }

    public void AtualizarInterface()
    {
        int recordeAtual = PlayerPrefs.GetInt("recorde");
        int pontuacaoAtual = this.pontuacao.PontuacaoAtual();

        recordeAtual = this.VerificarNovoRecorde(recordeAtual, pontuacaoAtual);
        this.VerificarCorMedalha(recordeAtual, pontuacaoAtual);
        this.AtualizarInterfaceRecorde(recordeAtual);
    }

    private void AtualizarInterfaceRecorde(int recordeAtual)
    {
        this.valorRecorde.text = recordeAtual.ToString();
    }

    private int VerificarNovoRecorde(int recordeAtual, int pontuacaoAtual)
    {
        if (recordeAtual < pontuacaoAtual)
        {
            this.textoRecorde.text = "Novo Recorde!!";
            return pontuacaoAtual;
        }
        else
        {
            this.textoRecorde.text = "Melhor Pontuação";
            return recordeAtual;
        }
    }
    
    private void VerificarCorMedalha(int recordeAtual, int pontuacaoAtual)
    {
        if (pontuacaoAtual >= recordeAtual - 2)
        {
            this.imagemMedalha.sprite = this.medalhaOuro;
        }
        else if (pontuacaoAtual >= recordeAtual / 2)
        {
            this.imagemMedalha.sprite = this.medalhaPrata;
        }
        else
        {
            this.imagemMedalha.sprite = this.medalhaBronze;
        }
    }
}
