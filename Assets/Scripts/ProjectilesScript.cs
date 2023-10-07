using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectilesScript : MonoBehaviour
{
    
    void  OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Terrain")
        {
            Debug.Log("Collided");
            Destroy(gameObject);
        }
    }

    
}
