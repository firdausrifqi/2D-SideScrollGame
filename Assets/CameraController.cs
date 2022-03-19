using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject BossCamera;
    public GameObject MainRoom;
    public GameObject BossRoom;
    public GameObject canvas;
    bool CameraBoss;
    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if(Collision.name == "Player")
        {
            if(MainCamera.activeSelf)
            {
                canvas.GetComponent<Canvas>().worldCamera = BossCamera.GetComponent<Camera>();
                BossCamera.SetActive(true);
                MainCamera.SetActive(false);
                BossRoom.SetActive(false);
                MainRoom.SetActive(true);
            }
            else
            {
                canvas.GetComponent<Canvas>().worldCamera = MainCamera.GetComponent<Camera>();
                MainCamera.SetActive(true);
                BossCamera.SetActive(false);
                BossRoom.SetActive(true);
                MainRoom.SetActive(false);
            }
        }
    }
}
