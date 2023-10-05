using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionScript : MonoBehaviour
{
    PlayerControls playerControls;
    DisabledChildren disabledChildren;
    [SerializeField] GameObject playerExplosionSound;
    [SerializeField] ParticleSystem explosionParticles;
    [SerializeField] float timeDelay = 2f;

    MeshRenderer[] childRenderers;

    bool hasExplode = false;
    void Start()
    {
        playerControls = GetComponent<PlayerControls>();
        childRenderers = GetComponentsInChildren<MeshRenderer>();
        disabledChildren = GetComponent<DisabledChildren>();
        
    }
    
    void OnCollisionEnter(Collision other) 
    {
        if(hasExplode) {return;}

        switch (other.gameObject.tag)
        {
            case "Terrain":
                Debug.Log("Friendly");
                break;
            case "Projectiles":
                playerControls.isCrashed = true;
                Explosion();
                HideChildrenObjects();
                Invoke(nameof(ResetScene), timeDelay);
                break;
            case "Enemies":
                playerControls.isCrashed = true;
                Explosion();
                HideChildrenObjects();
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
        disabledChildren.DisableSpecificChildren();
        GetComponent<BoxCollider>().enabled = false;
        Instantiate(playerExplosionSound, transform.position, Quaternion.identity);
        hasExplode = true;
    }
    
    void HideChildrenObjects()
    {
         foreach (MeshRenderer renderer in childRenderers)
         {
            renderer.enabled = false;
         }
    }

    

    
}
