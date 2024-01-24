using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] GameObject Vol;
    [SerializeField] GameObject Mut;

    public static bool isMuted;


    public void Start() {
        if(isMuted == true) {
            Vol.SetActive(false);
            Mut.SetActive(true);
        } else {
            Vol.SetActive(true);
            Mut.SetActive(false);
        }
    }
   
    public void Mute() {
        Vol.SetActive(false);
        Mut.SetActive(true);
        AudioListener.volume = 0;
        isMuted = true;
        
    }

    public void Volume() {
        Vol.SetActive(true);
        Mut.SetActive(false);
        AudioListener.volume = 1;
        isMuted = false;
        
    }
}
