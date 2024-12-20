using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera firstPersonCamera; // Asigna la cámara de primera persona
    public Camera thirdPersonCamera; // Asigna la cámara de tercera persona
    public KeyCode switchKey = KeyCode.C; // Tecla para cambiar de cámara

    private bool isFirstPerson = true;

    void Start()
    {
        // Asegúrate de que la cámara inicial esté activa
        firstPersonCamera.enabled = true;
        thirdPersonCamera.enabled = false;
    }

    void Update()
    {
        // Detecta cuando se presiona la tecla de cambio
        if (Input.GetKeyDown(switchKey))
        {
            isFirstPerson = !isFirstPerson; // Alterna entre primera y tercera persona
            firstPersonCamera.enabled = isFirstPerson;
            thirdPersonCamera.enabled = !isFirstPerson;
        }
    }
}