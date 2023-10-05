using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
  //  [SerializeField] float DelayReset = 2f;
    float hp = 100f;
    void OnParticleCollision(GameObject other) 
    {
        hp -= 10;
        Debug.Log("HP left: " + hp);

        if(hp <= 0)
        {
           Destroy(gameObject);     
        }
        
    }
}    
/*
    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Player")
        {
            Invoke(nameof(ResetScene), DelayReset);
        }
    }

    void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
*/