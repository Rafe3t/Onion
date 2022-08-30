using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public CinemachineVirtualCamera Camera;
    public bool IsFollow = false;
    // Update is called once per frame
    void Update()
    {
        if(IsFollow == false)
        {
            camerafollow();
        }
        if(IsFollow == true)
        {
            cameranotfollow();
        }
        
    }
    void camerafollow()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Transform follow = player.transform;
            Camera.Follow = follow;
        }
    }
    void cameranotfollow()
    {
        Camera.Follow = null;
    }
}
