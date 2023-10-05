using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
    [Header("Instantiate Tab")] // these are all Prefabs. to instantiate.
    [SerializeField] GameObject enemyExplosion; // episode 93 3D
    [SerializeField] GameObject enemyExplosionSounds;
    [SerializeField] GameObject enemyHit;

    [Header("Enemy HitPoints Tab")]
    [SerializeField]  float hp = 60;

    [Header("Transform to Parents Tab")]
    [SerializeField] Transform parents;

    [Header("Scoresystem Tab")]
    [SerializeField] int scoreIncrease = 10; // score increase every hp = 0 or gameobject destroy

    ScoreHandler scoreHandler;


    

    void Start()
    {
        scoreHandler = FindObjectOfType<ScoreHandler>();
        AddRigidbody();
    }

    void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other) 
    {
        hp -= 10;
         Debug.Log($"Enemy hp left: {hp}");

        if(hp <= 0)
        {
           
          scoreHandler.ScoreSystem(scoreIncrease);

          GameObject hitEffect = Instantiate(enemyHit, transform.position, Quaternion.identity);
          hitEffect.transform.parent = parents;
          
          GameObject SoundSFX = Instantiate(enemyExplosionSounds, transform.position, Quaternion.identity);
          SoundSFX.transform.parent = parents;
          
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