using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pontuacao : MonoBehaviour
{
    private int pontos;
    private Text textoPontuacao;
    private AudioSource somPontuacao;
    private void Awake()
    {
        this.somPontuacao = this.GetComponent<AudioSource>();
        this.textoPontuacao = this.GetComponent<Text>();

        this.textoPontuacao.text = "0";
    }

    public void Reiniciar()
    {
        this.pontos = 0;
        this.AtualizarTexto();
    }

    public void Pontuar()
    {
        this.AdicionarPontos();
        this.somPontuacao.Play();
    }

    private void AdicionarPontos()
    {
        this.pontos += 1;
        this.AtualizarTexto();
    }

    public void SalvarRecorde()
    {
        int recorde = PlayerPrefs.GetInt("recorde");
        
        if(this.pontos > recorde){
            PlayerPrefs.SetInt("recorde",this.pontos);
        }
    }

    public int PontuacaoAtual()
    {
        return this.pontos;
    }

    private void AtualizarTexto()
    {
        this.textoPontuacao.text = this.pontos.ToString();
    }
}
