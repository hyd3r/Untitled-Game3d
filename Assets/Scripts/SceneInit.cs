using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInit : MonoBehaviour
{
    public ReflectionProbe ReflectionProbe;
    public Light Sun;

    void Start()
    {
        if (ReflectionProbe != null) ReflectionProbe.RenderProbe();
    }

    void Update()
    {
        
    }
}
