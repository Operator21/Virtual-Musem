using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;

public class HandInit : MonoBehaviour
{
    public InputDeviceCharacteristics characteristics;
    public GameObject handPrefab;
    private GameObject instance;
    private Animator animator;
    private List<InputDevice> devices;
    void Start() {
        Debug.Log("Hand init starts");
        instance = Instantiate(handPrefab, transform);
        animator = instance.GetComponent<Animator>();
        devices = new List<InputDevice>();
    }

    void UpdateHandState(InputDevice device){
        if(device.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue)){
            animator.SetFloat("Trigger", triggerValue);
        } else {
            animator.SetFloat("Trigger", 0);
        }

        if(device.TryGetFeatureValue(CommonUsages.grip, out float gripValue)){
            animator.SetFloat("Grip", gripValue);
            //******************
            //Temporary solution to hide text when object grabbed
            //******************
            /*
            if(gripValue > 0.1)
                foreach(GameObject gameObject in GameObject.FindGameObjectsWithTag("Info"))
                    gameObject.GetComponent<Canvas>().enabled = false;
            else
                foreach(GameObject gameObject in GameObject.FindGameObjectsWithTag("Info"))
                    gameObject.GetComponent<Canvas>().enabled = true;
            */
            //******************
        } else {
            animator.SetFloat("Grip", 0);           
        }
    }

    void Update() {      
        InputDevices.GetDevicesWithCharacteristics(characteristics, devices);
        
        if(devices.Count > 0){
            UpdateHandState(devices[0]);
        }
        
    }
}
