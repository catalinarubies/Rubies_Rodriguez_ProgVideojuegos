using UnityEngine;

public class Lugar : MonoBehaviour
{
    public BarrasEstado barrasEstado;

    public float efectoEnergia = 0f;
    public float efectoDinero = 0f;
    public float efectoEstres = 0f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            barrasEstado.energia += efectoEnergia;
            barrasEstado.dinero += efectoDinero;
            barrasEstado.estres += efectoEstres;
        }
    }
}