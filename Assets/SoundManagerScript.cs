using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public AudioClip GunSound;
    public AudioClip LaserSound;
    public AudioClip Explosion;
    AudioSource audiosrc;
    // Start is called before the first frame update
    void Start()
    {
        audiosrc = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("AudioSlide"))
        {
            audiosrc.volume = PlayerPrefs.GetFloat("AudioSlide")/100;
        }
        else
        {
            audiosrc.volume = 100f/100f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound(string sound)
    {
       switch (sound) {
            case "GunShot":
                audiosrc.PlayOneShot(GunSound);
                break;
            case "LaserShot":
                audiosrc.PlayOneShot(LaserSound);
                break;
            case "Explosion":
                audiosrc.PlayOneShot(Explosion);
                break;
           default :
               
               break;
       }
    }
}
