using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScreen : MonoBehaviour
{
    public GameObject Winning;
    public GameObject Lossing;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LossingScreen()
    {
        Lossing.SetActive(true);
        Winning.SetActive(false);
    }

    public void WinningScreen()
    {
        Winning.SetActive(true);
        Lossing.SetActive(false);
    }

}
