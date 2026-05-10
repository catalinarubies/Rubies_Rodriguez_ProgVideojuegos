using UnityEngine;

public class Lugar : MonoBehaviour
{
    public BarrasEstado barrasEstado;

    public float efectoEnergia = 0f;
    public float efectoDinero = 0f;
    public float efectoEstres = 0f;

    private bool jugadorAdentro = false;

    void Update()
    {
        if (jugadorAdentro)
        {
            barrasEstado.energia += efectoEnergia * Time.deltaTime;
            barrasEstado.dinero += efectoDinero * Time.deltaTime;
            barrasEstado.estres += efectoEstres * Time.deltaTime;
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
            jugadorAdentro = false;
    }
}