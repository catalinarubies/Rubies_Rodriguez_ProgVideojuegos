using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform jugador;
    public float smoothSpeed = 3f;
    
    // Límites del mapa (ajustar en Inspector)
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    void Update()
    {
        Vector3 destino = new Vector3(jugador.position.x, jugador.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, destino, smoothSpeed * Time.deltaTime);
        
        // Clamp limita la posición de la cámara dentro de los bordes
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, xMin, xMax),
            Mathf.Clamp(transform.position.y, yMin, yMax),
            transform.position.z
        );
    }
}