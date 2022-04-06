using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CameraFadeOut : MonoBehaviour
{
    bool collision = false;
    GameObject fader;
    public Material faderMaterial;
    int delay = 5;
    int step = 5;
    void Start() {
        fader = transform.Find("Fader").gameObject;
    }

    private void OnCollisionEnter(Collision other) {
        if(!collision && other.gameObject.GetComponent<XRGrabInteractable>() == null) {
            collision = true;   
            Fadein();        
        }
    }

    private void OnCollisionExit(Collision other) {
        if(other.contactCount < 1) {
            collision = false;
            Fadeout();
        }
    }

    async void Fadein() {
        faderMaterial.color = new Color(0, 0, 0, 0);
        fader.SetActive(true);
        for(int x = 1; x < 100; x += step) {
            faderMaterial.color = new Color(0, 0, 0, x/100f);
            await Task.Delay(delay);
        }
        await Task.Delay(delay);
        faderMaterial.color = new Color(0, 0, 0, 1);
    }
    async void Fadeout() {
        faderMaterial.color = new Color(0, 0, 0, 1);
        for(int x = 100; x > 0; x -= step) {
            faderMaterial.color = new Color(0, 0, 0, x/100f);
            await Task.Delay(delay);
        }
        await Task.Delay(delay);
        faderMaterial.color = new Color(0, 0, 0, 0);
        fader.SetActive(false);
    }
}
