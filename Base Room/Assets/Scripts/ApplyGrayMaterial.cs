using UnityEngine;

public class ApplyGrayMaterial : MonoBehaviour
{
    public Material grayMaterial; // Assign your gray material in the Inspector
    public GameObject[] targetParents; // Assign parent objects in the Inspector

    void Start()
    {
        foreach (GameObject parent in targetParents)
        {
            // Find all Renderer components in the children of the parent object
            Renderer[] childRenderers = parent.GetComponentsInChildren<Renderer>();

            // Apply gray material to each renderer
            foreach (Renderer renderer in childRenderers)
            {
                renderer.material = grayMaterial;
            }
        }
    }
}