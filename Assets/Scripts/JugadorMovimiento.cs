using UnityEngine;

public class JugadorMovimiento : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private int lastDireccion = 3;
    private bool bloqueado = false; // controla si el jugador puede moverse

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Llamado desde Lugar.cs para bloquear o desbloquear el movimiento
    public void SetBloqueado(bool valor)
    {
        bloqueado = valor;
        if (bloqueado) rb.linearVelocity = Vector2.zero; // para el personaje al bloquearse
    }

    void Update()
    {
        if (bloqueado) return; // si está bloqueado no procesa input

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 direccion = new Vector2(horizontal, vertical);
        rb.linearVelocity = direccion * speed;

        if (horizontal > 0.1f) { animator.SetInteger("Direccion", 1); lastDireccion = 1; }
        else if (horizontal < -0.1f) { animator.SetInteger("Direccion", 2); lastDireccion = 2; }
        else if (vertical < -0.1f) { animator.SetInteger("Direccion", 3); lastDireccion = 3; }
        else if (vertical > 0.1f) { animator.SetInteger("Direccion", 4); lastDireccion = 4; }
        else
        {
            if (lastDireccion == 1) animator.SetInteger("Direccion", 5);
            else if (lastDireccion == 2) animator.SetInteger("Direccion", 6);
            else if (lastDireccion == 3) animator.SetInteger("Direccion", 7);
            else if (lastDireccion == 4) animator.SetInteger("Direccion", 8);
        }
    }
}