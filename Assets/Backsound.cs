using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backsound : MonoBehaviour
{
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        if(PlayerPrefs.HasKey("MusicSlider"))
        {
            audio.volume = PlayerPrefs.GetFloat("MusicSlider")/100;
        }
        else
        {
            audio.volume = 100;
        }
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        audio.volume = PlayerPrefs.GetFloat("MusicSlider")/100;
    }
}
