using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class TeleportControl : MonoBehaviour
{
    /*public GameObject baseController;
    public GameObject teleportationObject;*/
    public InputActionReference teleportActivation;
    public UnityEvent onTeleportActivate;
    public UnityEvent onTeleportCancel;

    void Start() {
        teleportActivation.action.performed += TeleportModeActivate;
        teleportActivation.action.canceled += TeleportModeCancel;
    }

    void TeleportModeActivate(InputAction.CallbackContext obj){
        onTeleportActivate.Invoke();
    }
    void TeleportModeCancel(InputAction.CallbackContext obj){
        Invoke("DeactivateTeleporter", 0.1f);
    }

    void DeactivateTeleporter(){
        onTeleportCancel.Invoke();
    }
}
