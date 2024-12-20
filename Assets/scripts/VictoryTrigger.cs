using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryTrigger : MonoBehaviour
{
    public Animator playerAnimator; // Asigna el Animator del personaje

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Aseg�rate de que tu personaje tenga la etiqueta "Player"
        {
            playerAnimator.SetTrigger("Victory"); // Activa la animaci�n de victoria
        }
    }
}