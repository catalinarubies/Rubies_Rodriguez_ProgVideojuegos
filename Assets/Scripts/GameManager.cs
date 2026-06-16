using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject panelGameOver;
    public TMP_Text textTiempo;
    public BarrasEstado barrasEstado;

    private float tiempoSobrevivido = 0f;
    private int minutosTranscurridos;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        tiempoSobrevivido += Time.deltaTime;
        if (tiempoSobrevivido >= minutosTranscurridos * 60f)
        {
            minutosTranscurridos += 1;
            barrasEstado.tasaEnergia *= 1.2f;
            barrasEstado.tasaDinero *= 1.2f;
            barrasEstado.tasaEstres *= 1.2f;
        }
    }

    public void GameOver()
    {
        panelGameOver.SetActive(true);
        int minutos = (int)(tiempoSobrevivido / 60f);
        int segundos = (int)(tiempoSobrevivido % 60f);
        textTiempo.text = "Tiempo: " + minutos + ":" + segundos.ToString("00");
        // sin pausar el juego
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}