using UnityEngine;

public class BarrasEstado : MonoBehaviour
{
    public float energia = 50f;
    public float dinero = 50f;
    public float estres = 0f;
    public GameManager gameManager;

    public float tasaEnergia = 0.8f;
    public float tasaDinero = 0.3f;
    public float tasaEstres = 0.5f;

    private bool juegoTerminado = false; // evita llamar GameOver más de una vez

    void Update()
    {
        if (juegoTerminado) return; // si ya terminó, no hace nada

        energia -= tasaEnergia * Time.deltaTime;
        dinero -= tasaDinero * Time.deltaTime;
        estres += tasaEstres * Time.deltaTime;

        energia = Mathf.Clamp(energia, 0f, 100f);
        dinero = Mathf.Clamp(dinero, 0f, 100f);
        estres = Mathf.Clamp(estres, 0f, 100f);

        if (energia <= 0 || dinero <= 0 || estres >= 100)
        {
            juegoTerminado = true;
            gameManager.GameOver();
        }
    }
}