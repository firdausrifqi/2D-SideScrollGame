using UnityEngine;

public class cameramovement : MonoBehaviour
{
    public Transform target;
    bool IsTarget = false;
    public Vector3 offset;
    [Range(1,10)]
    public float smoothFactor;
    
    private void FixedUpdate()
    {
        checktarget();
        if(IsTarget)
        {
            Follow();
        }
    }

    void Follow()
    {
        Vector3 targetPosition = target.position+offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition,smoothFactor*Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }

    void checktarget()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            IsTarget = true;
        }
        else
        {
            IsTarget = false;
        }
    }
}
