using UnityEngine;

public class Lugar : MonoBehaviour
{
    public BarrasEstado barrasEstado;

    public float efectoEnergia = 0f;
    public float efectoDinero = 0f;
    public float efectoEstres = 0f;

    public bool esCasa = false;
    public float efectoEstresProcrastinacion = 0.06f;
    public bool JugadorAdentro => jugadorAdentro;

    private bool jugadorAdentro = false;
    private float tiempoAdentro = 0f;

    void Update()
    {
        if (jugadorAdentro)
        {
            if (esCasa)
            {
                tiempoAdentro += Time.deltaTime;

                if (tiempoAdentro < 30f)
                {
                    barrasEstado.energia += efectoEnergia * Time.deltaTime;
                    barrasEstado.dinero += efectoDinero * Time.deltaTime;
                    barrasEstado.estres += efectoEstres * Time.deltaTime;
                }
                else
                {
                    barrasEstado.estres += efectoEstresProcrastinacion * Time.deltaTime;
                }
            }
            else
            {
                barrasEstado.energia += efectoEnergia * Time.deltaTime;
                barrasEstado.dinero += efectoDinero * Time.deltaTime;
                barrasEstado.estres += efectoEstres * Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entró: " + other.name + " tag: " + other.tag);
        if (other.CompareTag("Player"))
            jugadorAdentro = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Salió: " + other.name);
        if (other.CompareTag("Player"))
        {
            jugadorAdentro = false;
            tiempoAdentro = 0f;
        }
    }
}