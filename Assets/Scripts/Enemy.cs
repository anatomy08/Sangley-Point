using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour 
{
    [SerializeField] GameObject enemyExplosion; // episode 93 3D

    [SerializeField] Transform parents;
    float hp = 100f;
    void OnParticleCollision(GameObject other) 
    {
        hp -= 10;
        

        if(hp <= 0)
        {
          GameObject Explosion = Instantiate(enemyExplosion, transform.position, Quaternion.identity);
          Explosion.transform.parent = parents; // i i want to set up to a parent (optional)
           Destroy(gameObject);
        }
        
    }
}    // if i want the player get destroyed and the enemy script is in enemy so i can reset the scene.
/*
    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Player")
        {
            Invoke(nameof(ResetScene), 2f);
        }
    }

    void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
*/