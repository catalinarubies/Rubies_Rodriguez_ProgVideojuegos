using UnityEngine;
using UnityEngine.UI;

public class UIBarras : MonoBehaviour
{
    public BarrasEstado barrasEstado;
    public Slider sliderEnergia;
    public Slider sliderDinero;
    public Slider sliderEstres;

    // Referencias al Fill de cada slider para cambiar color
    public Image fillEnergia;
    public Image fillDinero;
    public Image fillEstres;

    // Lista de todos los lugares de la escena
    public Lugar[] lugares;

    private Color colorPositivo = Color.green;
    private Color colorNegativo = Color.red;
    private Color colorNeutral = Color.white;

    void Update()
    {
        sliderEnergia.value = barrasEstado.energia;
        sliderDinero.value = barrasEstado.dinero;
        sliderEstres.value = barrasEstado.estres;

        // Buscamos el lugar donde está el jugador
        Lugar lugarActual = null;
        foreach (Lugar lugar in lugares)
        {
            if (lugar.JugadorAdentro)
            {
                lugarActual = lugar;
                break;
            }
        }

        if (lugarActual == null)
        {
            // Fuera de todo lugar: todo baja/sube pasivamente
            fillEnergia.color = colorNegativo;
            fillDinero.color = colorNegativo;
            fillEstres.color = colorNegativo;
        }
        else if (lugarActual.EsLugarCasa && lugarActual.TiempoAdentro >= 30f)
        {
            // Fase procrastinacion: estres sube, energia no se recupera
            fillEnergia.color = colorNegativo;
            fillDinero.color = colorNeutral;
            fillEstres.color = colorNegativo;
        }
        else
        {
            // Logica normal para todos los lugares
            float netoEnergia = lugarActual.efectoEnergia - barrasEstado.tasaEnergia;
            float netoDinero = lugarActual.efectoDinero - barrasEstado.tasaDinero;
            float netoEstres = lugarActual.efectoEstres + barrasEstado.tasaEstres;

            fillEnergia.color = netoEnergia > 0 ? colorPositivo : colorNegativo;
            fillDinero.color = netoDinero > 0 ? colorPositivo : colorNegativo;
            // Estres: positivo si el neto baja
            fillEstres.color = netoEstres <= 0 ? colorPositivo : colorNegativo;
        }
    }
}