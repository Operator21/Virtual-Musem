using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    AudioSource audioSource;
    Button button; 
    public AudioClip audioClip;
    //public bool loop = false;
    void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        button = transform.Find("Button/Button").GetComponent<Button>();

        button.onClick.AddListener(() => {
            Debug.Log("Clicked sound");
            audioSource.Play();
        });
    }
}
