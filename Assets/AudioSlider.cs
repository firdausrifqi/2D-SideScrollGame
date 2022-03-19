using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    Slider slide;
    // Start is called before the first frame update
    void Start()
    {
        slide = GetComponent<Slider>();
        if (PlayerPrefs.HasKey("AudioSlide"))
        {
            slide.value = PlayerPrefs.GetFloat("AudioSlide");
        }
        else
        {
            slide.value = 100;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(slide.value);
        PlayerPrefs.SetFloat("AudioSlide", slide.value);
        PlayerPrefs.Save();
    }
}
