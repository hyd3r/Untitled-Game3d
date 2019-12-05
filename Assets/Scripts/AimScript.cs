using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{
    public CinemachineCameraOffset cam;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    private bool isAiming = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            isAiming = true;
            
        }
        if(Input.GetButtonUp("Fire2"))
        {
            isAiming = false;
        }
        if (isAiming)
        {
            cam.m_Offset = Vector3.SmoothDamp(cam.m_Offset, new Vector3(0.34f, 0.37f, 4.03f), ref velocity, smoothTime);
        }
        else
        {
            cam.m_Offset = Vector3.SmoothDamp(cam.m_Offset, new Vector3(0f, 0f, 0f), ref velocity, smoothTime);
        }
    }
}
