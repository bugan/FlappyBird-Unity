using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaoPiscando : MonoBehaviour
{
    private bool _clicou;
    private SpriteRenderer _imagem;

    void Awake()
    {
        this._imagem = this.GetComponent<SpriteRenderer>();
        this._imagem.enabled = true;
        this._clicou = false;
    }

    void Update()
    {
		
        if (GameOver.estaJogando)
        {
            this._verificaClique();
            if (this._clicou)
            {
               this._habilitarImagem(false);
            }
        }
        else
        {
            this._clicou = false;
			this._habilitarImagem(true);
        }
    }

    private void _verificaClique()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            this._clicou = true;
        }
    }

    private void _habilitarImagem(bool ativa)
    {
        this._imagem.enabled = ativa;
    }
}
