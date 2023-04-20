using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
     public Transform target;
    public float cam_speed = 0.1f;
    Camera mycam;

    void Start()
    {
        mycam = GetComponent<Camera>();    
    }


    void Update()
    {
        mycam.orthographicSize = (Screen.height / 100f) / 1.2f;
        Vector3 newPos = new Vector3 (target.position.x , target.position.y, -10);
        if(target){
            transform.position = Vector3.Lerp(transform.position, newPos, cam_speed);
        }        
    }
}

