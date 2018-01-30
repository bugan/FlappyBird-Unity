using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaoPiscando : MonoBehaviour
{
    private SpriteRenderer imagem;

    private void Awake()
    {
        this.imagem = this.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("botaoDireitoMouse"))
        {
            this.MostrarMao(false);
        }
    }

    public void Reiniciar()
    {
        this.MostrarMao(true);
    }

    private void MostrarMao(bool ativa)
    {
        this.imagem.enabled = ativa;
    }
}
