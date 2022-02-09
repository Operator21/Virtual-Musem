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
    void OnEnable() {
        rayActivation.action.performed += RayModeActivate;             
    }

    void RayModeActivate(InputAction.CallbackContext obj) {
        onRayActivate.Invoke();
        rayActivation.action.performed -= RayModeActivate; 
        rayActivation.action.performed += RayModeCancel;
    }
    void RayModeCancel(InputAction.CallbackContext obj) {
        onRayCancel.Invoke();
        rayActivation.action.performed -= RayModeCancel;
        rayActivation.action.performed += RayModeActivate; 
    }

}
