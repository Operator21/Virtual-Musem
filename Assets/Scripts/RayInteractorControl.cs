using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class RayInteractorControl : MonoBehaviour
{
    public InputActionReference rayActivation;
    public UnityEvent onRayActivate;
    public UnityEvent onRayCancel;
    void start() {
        rayActivation.action.performed += RayModeActivate;       
        rayActivation.action.canceled += RayModeCancel;       
    }

    void RayModeActivate(InputAction.CallbackContext obj) {
        Debug.Log("Activate Ray");
        onRayActivate.Invoke();
        //rayActivation.action.performed += RayModeCancel;
    }
    void RayModeCancel(InputAction.CallbackContext obj) {
        Debug.Log("Deactivate Ray");
        //onRayCancel.Invoke();
        //rayActivation.action.performed += RayModeActivate;
    }

}
