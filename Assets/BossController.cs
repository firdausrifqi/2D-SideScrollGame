using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    int count = 0;
    public GameObject boss;
    public Text Enemy;
    public Text orb;
    int Orb = 0;
    public GameObject MainCamera;

    // Update is called once per frame
    void Update()
    {
        Enemy.text = "Killed Enemy: " + count + " / 15";
        orb.text = "Orb Collected: " + Orb + " / 7";
        
        if(count >= 15 && Orb >= 7)
        {
            if(boss != null)
            {
                boss.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            if(MainCamera.activeSelf)
            {
                boss.gameObject.GetComponent<Boss_Health>().SetOn(true);
            }
            else
            {
                boss.gameObject.GetComponent<Boss_Health>().SetOn(false);
            }
        }
    }

    public void tambah()
    {
        count++;
    }
    public void addOrb()
    {
        Orb++;
    }
}
