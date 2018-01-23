using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pontuacao : MonoBehaviour
{

    private int _pontos;
    private Text _textoPontuacao;
    void Awake()
    {
        this._textoPontuacao = this.GetComponent<Text>();
        this.reiniciar();
    }

    public void reiniciar()
    {
        this._pontos = 0;
        this._atualizaTexto();
    }

    public void adicionarPontos(int quantidade)
    {
        this._pontos += quantidade;
        this._atualizaTexto();
    }

    private void _atualizaTexto()
    {
        this._textoPontuacao.text = this._pontos.ToString();
    }
}
