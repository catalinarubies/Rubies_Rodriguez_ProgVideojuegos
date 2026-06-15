using UnityEngine;

public class JugadorMovimiento : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private int lastDireccion = 3; // empieza mirando adelante

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 direccion = new Vector2(horizontal, vertical);
        rb.linearVelocity = direccion * speed;

        // Determinamos la dirección y guardamos la última para el idle
        if (horizontal > 0.1f)
        {
            animator.SetInteger("Direccion", 1); // caminar derecha
            lastDireccion = 1;
        }
        else if (horizontal < -0.1f)
        {
            animator.SetInteger("Direccion", 2); // caminar izquierda
            lastDireccion = 2;
        }
        else if (vertical < -0.1f)
        {
            animator.SetInteger("Direccion", 3); // caminar adelante
            lastDireccion = 3;
        }
        else if (vertical > 0.1f)
        {
            animator.SetInteger("Direccion", 4); // caminar atras
            lastDireccion = 4;
        }
        else
        {
            // Quieto: idle según última dirección
            if (lastDireccion == 1) animator.SetInteger("Direccion", 5);      // idle derecha
            else if (lastDireccion == 2) animator.SetInteger("Direccion", 6); // idle izquierda
            else if (lastDireccion == 3) animator.SetInteger("Direccion", 7); // idle adelante
            else if (lastDireccion == 4) animator.SetInteger("Direccion", 8); // idle atras
        }
    }
}