﻿
using UnityEngine;

public class AnimationEventEffects : MonoBehaviour {
    //public GameObject EffectPrefab;
    //public Transform EffectStartPosition;
    //public float DestroyAfter = 10;
    //[Space]
    //public GameObject EffectPrefabWorldSpace;
    //public Transform EffectStartPositionWorld;
    //public float DestroyAfterWorld = 10;

    public EffectInfo[] Effects;

    [System.Serializable]

    public class EffectInfo
    {
        public GameObject Effect;
        public Transform StartPositionRotation;
        public float DestroyAfter = 10;
        public bool UseLocalPosition = true;
    }

  

    public void CustomTeleport()
    {
        GetComponent<CharacterController>().enabled=false;
        transform.position += transform.forward * 9;
        GetComponent<CharacterController>().enabled = true;
    }
  
            
    void InstantiateEffect(int EffectNumber)
    {
        if(Effects == null || Effects.Length <= EffectNumber)
        {
            Debug.LogError("Incorrect effect number or effect is null");
        }

        var instance = Instantiate(Effects[EffectNumber].Effect, Effects[EffectNumber].StartPositionRotation.position, Effects[EffectNumber].StartPositionRotation.rotation);

        if (Effects[EffectNumber].UseLocalPosition)
        {
            instance.transform.parent = Effects[EffectNumber].StartPositionRotation.transform;
            instance.transform.localPosition = Vector3.zero;
            instance.transform.localRotation = new Quaternion();
        }
        Destroy(instance, Effects[EffectNumber].DestroyAfter);
    }
}
