using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionScript : MonoBehaviour
{
    PlayerControls playerControls;
    
    [SerializeField] ParticleSystem explosionParticles;
    [SerializeField] float timeDelay = 2f;
    void Start()
    {
        playerControls = GetComponent<PlayerControls>();
      
        
    }
    
    void OnCollisionEnter(Collision other) 
    {
        

        switch (other.gameObject.tag)
        {
            case "Terrain":
                Debug.Log("Friendly");
                break;
            case "Projectiles":
                playerControls.isCrashed = true;
                Explosion();
                
                Invoke(nameof(ResetScene), timeDelay);
                break;
            case "Enemies":
                playerControls.isCrashed = true;
                Explosion();
                
                Invoke(nameof(ResetScene), timeDelay);
                break;
            
        }
    }

    void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);        
    }

    void Explosion()
    {
        explosionParticles.Play();
    }
    
}
