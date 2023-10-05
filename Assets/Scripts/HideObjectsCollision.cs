using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObjectsCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectiles") || collision.gameObject.CompareTag("Enemies"))
        {
            // Disable MeshRenderer components in all child objects
            DisableChildMeshRenderers(transform);
        }
    }

    private void DisableChildMeshRenderers(Transform parent)
    {
        foreach (Transform child in parent)
        {
            MeshRenderer meshRenderer = child.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.enabled = false;
            }

            // Recursively disable MeshRenderers in all children
            DisableChildMeshRenderers(child);
        }
    }
}


