using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera firstPersonCamera; // Asigna la c�mara de primera persona
    public Camera thirdPersonCamera; // Asigna la c�mara de tercera persona
    public KeyCode switchKey = KeyCode.C; // Tecla para cambiar de c�mara

    private bool isFirstPerson = true;

    void Start()
    {
        // Aseg�rate de que la c�mara inicial est� activa
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