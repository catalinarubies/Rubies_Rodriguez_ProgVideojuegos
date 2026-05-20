using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // referencia al panel que se muestra al perder
    public GameObject panelGameOver;
    // referencia al texto que muestra el tiempo sobrevivido
    public TMP_Text textTiempo;

    // contador de tiempo sobrevivido
    private float tiempoSobrevivido = 0f;

    void Start()
    {
        // nos aseguramos que el juego corra normal al iniciar
        Time.timeScale = 1f;
    }

    void Update()
    {
        // acumulamos el tiempo mientras el juego corre
        tiempoSobrevivido += Time.deltaTime;
    }

    public void GameOver()
    {
        // mostramos el panel de game over
        panelGameOver.SetActive(true);
        // formateamos el tiempo en minutos y segundos
        int minutos = (int)(tiempoSobrevivido / 60f);
        int segundos = (int)(tiempoSobrevivido % 60f);
        textTiempo.text = "Tiempo: " + minutos + ":" + segundos.ToString("00");
        // pausamos el juego
        Time.timeScale = 0f;
    }

    public void Reiniciar()
    {
        // restauramos el tiempo y recargamos la escena
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}