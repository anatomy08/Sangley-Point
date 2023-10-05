using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructInstantiate : MonoBehaviour
{
    [SerializeField] float DelayDestroy = 3f; 
    void Start()
    {   
        Destroy(gameObject, DelayDestroy);
    }

    

}
// dont forget to put this on Instantiate Objects.