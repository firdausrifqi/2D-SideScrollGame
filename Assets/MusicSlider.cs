using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{
    Slider slide;
    // Start is called before the first frame update
    void Start()
    {
        slide = GetComponent<Slider>();
        if (PlayerPrefs.HasKey("MusicSlider"))
        {
            slide.value = PlayerPrefs.GetFloat("MusicSlider");
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
        PlayerPrefs.SetFloat("MusicSlider", slide.value);
        PlayerPrefs.Save();
    }
}
