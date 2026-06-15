using UnityEngine;
using TMPro;

public class Lugar : MonoBehaviour
{
    public BarrasEstado barrasEstado;
    public string nombreLugar = "Lugar";

    public float efectoEnergia = 0f;
    public float efectoDinero = 0f;
    public float efectoEstres = 0f;

    public bool esCasa = false;
    public float efectoEstresProcrastinacion = 0.06f;

    public JugadorMovimiento jugadorMovimiento;
    public SpriteRenderer jugadorSprite;
    public TextMeshProUGUI textoLugar;

    public bool JugadorAdentro => jugadorAdentro;
    public float TiempoAdentro => tiempoAdentro;
    public bool EsLugarCasa => esCasa;

    private bool jugadorAdentro = false;
    private bool jugadorEntrando = false;
    private bool dentroDelLugar = false;
    private float tiempoAdentro = 0f;

    void Update()
    {
        if (jugadorEntrando && !dentroDelLugar)
        {
            textoLugar.text = "Presioná Enter para entrar a " + nombreLugar;

            if (Input.GetKeyDown(KeyCode.Return))
                Entrar();
        }

        if (dentroDelLugar && Input.GetKeyDown(KeyCode.Escape))
            Salir();

        if (dentroDelLugar)
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

    void Entrar()
    {
        dentroDelLugar = true;
        jugadorAdentro = true;
        jugadorMovimiento.SetBloqueado(true);
        jugadorSprite.enabled = false;
        textoLugar.text = "Estás en " + nombreLugar + ". Presioná Escape para salir.";
    }

    void Salir()
    {
        dentroDelLugar = false;
        jugadorAdentro = false;
        tiempoAdentro = 0f;
        jugadorMovimiento.SetBloqueado(false);
        jugadorSprite.enabled = true;
        textoLugar.text = ""; // limpia el texto al salir
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            jugadorEntrando = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEntrando = false;
            if (dentroDelLugar) Salir();
            textoLugar.text = ""; // limpia el texto al salir del trigger
        }
    }
}