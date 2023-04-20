using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    public float cam_speed = 0.1f;
    Camera mycam;
    //componente camera en y no menor a -1
    private Transform camara_pos;
    void Start()
    {
        mycam = GetComponent<Camera>(); 
        camara_pos = GetComponent<Transform>();   
    }


    void Update()
    {
        
        
        mycam.orthographicSize = (Screen.height / 100f) / 1.2f;
        Vector3 newPos = new Vector3 (target.position.x , target.position.y, -10);
        if(target){
            transform.position = Vector3.Lerp(new Vector3(transform.position.x, 0.0f,transform.position.z), newPos, cam_speed);
        }        
    }
}

