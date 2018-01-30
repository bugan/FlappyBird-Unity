using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diretor : MonoBehaviour
{
    private InterfaceGameOver controleInterface;
    private Pontuacao pontuacao;
    private Aviao jogador;
    private ControleDeDificuldade controleDeDificuldade;
    private MaoPiscando maoPiscando;

    private void Start()
    {
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();
        this.controleInterface = this.GetComponent<InterfaceGameOver>();
        this.jogador = GameObject.FindObjectOfType<Aviao>();
        this.controleDeDificuldade = GameObject.FindObjectOfType<ControleDeDificuldade>();
        this.maoPiscando = GameObject.FindObjectOfType<MaoPiscando>();
    }

    public void FinalizarJogo()
    {
        Time.timeScale = 0;
        this.controleInterface.AtualizarInterface();
        this.controleInterface.MostrarInterface();
        this.pontuacao.SalvarRecorde();
    }

    public void ReiniciarJogo()
    {
        Time.timeScale = 1;
        this.controleInterface.EsconderInterface();
        this.jogador.Reiniciar();
        this.controleDeDificuldade.Reiniciar();
        this.pontuacao.Reiniciar();
        this.maoPiscando.Reiniciar();
        this.DestruirObstaculos();
    }

    private void DestruirObstaculos()
    {
        Obstaculo[] obstaculos = GameObject.FindObjectsOfType<Obstaculo>();
        foreach (Obstaculo obstaculo  in obstaculos)
        {
            obstaculo.Destruir();
        }
    }
}
