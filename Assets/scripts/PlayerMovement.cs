using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Animator animator; // Referencia al Animator
    private Vector3 velocity;
    private bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>(); // Obt�n el Animator
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Victory"))
        {
            return; // Detiene el movimiento si est� en la animaci�n de victoria
        }

        // Detecta si est�s tocando el suelo
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Resetea la velocidad al tocar el suelo
            animator.SetBool("IsJumping", false); // Desactiva animaci�n de salto
        }

        // Movimiento en el plano XZ
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Actualiza la animaci�n de caminar
        bool isWalking = move.magnitude > 0;
        animator.SetBool("IsWalking", isWalking);

        // Salto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity); // Calcula salto
            animator.SetBool("IsJumping", true); // Activa animaci�n de salto
        }

        // Aplicar gravedad
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}