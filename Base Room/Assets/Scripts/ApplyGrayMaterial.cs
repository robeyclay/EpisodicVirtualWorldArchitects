using UnityEngine;

public class ApplyGrayMaterial : MonoBehaviour
{
    public Material grayMaterial; // Assign your gray material in the Inspector

    void Start()
    {
        // Find all renderers in the scene
        Renderer[] renderers = FindObjectsOfType<Renderer>();

        // Apply gray material to each renderer
        foreach (Renderer renderer in renderers)
        {
            renderer.material = grayMaterial;
        }
    }
}