using UnityEngine;
using UnityEngine.UI;

public class UIBarras : MonoBehaviour
{
    public BarrasEstado barrasEstado;
    public Slider sliderEnergia;
    public Slider sliderDinero;
    public Slider sliderEstres;

    void Update()
    {
        sliderEnergia.value = barrasEstado.energia;
        sliderDinero.value = barrasEstado.dinero;
        sliderEstres.value = barrasEstado.estres;
    }
}