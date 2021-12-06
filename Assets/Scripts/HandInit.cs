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
    private bool found = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hand init starts");
        instance = Instantiate(handPrefab, transform);
        animator = instance.GetComponent<Animator>();
    }

    void UpdateHandState(InputDevice device){
        if(device.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue)){
            animator.SetFloat("Trigger", triggerValue);
        } else {
            animator.SetFloat("Trigger", 0);
        }

        if(device.TryGetFeatureValue(CommonUsages.grip, out float gripValue)){
            animator.SetFloat("Grip", gripValue);
        } else {
            animator.SetFloat("Grip", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(characteristics, devices);
        
        if(devices.Count > 0){
            UpdateHandState(devices[0]);
        }
        
    }
}
