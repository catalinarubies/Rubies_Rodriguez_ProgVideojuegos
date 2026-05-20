using UnityEngine;

public class Lugar : MonoBehaviour
{
    public BarrasEstado barrasEstado;

    // efectos normales para todos los lugares
    public float efectoEnergia = 0f;
    public float efectoDinero = 0f;
    public float efectoEstres = 0f;

    // solo se usa si esCasa es true
    public bool esCasa = false;
    public float efectoEstresProcrastinacion = 0.06f;

    private bool jugadorAdentro = false;
    private float tiempoAdentro = 0f;

    void Update()
    {
        if (jugadorAdentro)
        {
            if (esCasa)
            {
                // acumulamos el tiempo que lleva adentro
                tiempoAdentro += Time.deltaTime;

                if (tiempoAdentro < 30f)
                {
                    // fase 1: recupera energia y alivia estres
                    barrasEstado.energia += efectoEnergia * Time.deltaTime;
                    barrasEstado.dinero += efectoDinero * Time.deltaTime;
                    barrasEstado.estres += efectoEstres * Time.deltaTime;
                }
                else
                {
                    // fase 2: procrastinacion, solo sube el estres
                    barrasEstado.estres += efectoEstresProcrastinacion * Time.deltaTime;
                }
            }
            else
            {
                // cualquier otro lugar aplica sus efectos normales
                barrasEstado.energia += efectoEnergia * Time.deltaTime;
                barrasEstado.dinero += efectoDinero * Time.deltaTime;
                barrasEstado.estres += efectoEstres * Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            jugadorAdentro = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorAdentro = false;
            // reseteamos el timer para la proxima vez que entre
            tiempoAdentro = 0f;
        }
    }
}