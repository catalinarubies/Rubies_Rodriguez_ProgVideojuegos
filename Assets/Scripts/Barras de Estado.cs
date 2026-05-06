using UnityEngine;

public class BarrasEstado : MonoBehaviour
{
    public float energia = 50f;
    public float dinero = 50f;
    public float estres = 0f;

    public float tasaEnergia = 0.8f;
    public float tasaDinero = 0.3f;
    public float tasaEstres = 0.5f;

    void Update()
    {
        energia -= tasaEnergia * Time.deltaTime;
        dinero -= tasaDinero * Time.deltaTime;
        estres += tasaEstres * Time.deltaTime;

        energia = Mathf.Clamp(energia, 0f, 100f);
        dinero = Mathf.Clamp(dinero, 0f, 100f);
        estres = Mathf.Clamp(estres, 0f, 100f);
    }
}