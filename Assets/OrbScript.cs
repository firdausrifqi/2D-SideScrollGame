using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbScript : MonoBehaviour
{
    public GameObject bossController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            bossController.GetComponent<BossController>().addOrb();
            Destroy(gameObject);
            //other.gameObject.GetComponent<PlayerScript>().giveHealth(10);
        }
    }
}
