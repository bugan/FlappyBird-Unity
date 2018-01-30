using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDeDificuldade : MonoBehaviour
{
    [SerializeField]
    private float tempoParaDificuldadeMaxima;
    private float dificuldade;
    private float tempoPassado;

    public float Dificuldade
    {
        get
        {
            return dificuldade;
        }
    }

    private void Update()
    {
        this.tempoPassado += Time.deltaTime;
        float dificuldadeNormalizada = this.tempoPassado / this.tempoParaDificuldadeMaxima;
        dificuldadeNormalizada = Mathf.Min(dificuldadeNormalizada, 1);

        this.dificuldade = dificuldadeNormalizada;
    }

    public void Reiniciar()
    {
        this.tempoPassado = 0;
    }
}
