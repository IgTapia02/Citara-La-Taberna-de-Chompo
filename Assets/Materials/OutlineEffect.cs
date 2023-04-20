using UnityEngine;
using System.Collections.Generic;

public class OutlineEffect : MonoBehaviour
{

    public Material outlineMaterial;
    public float outlineWidth = 0.1f;

    private Renderer[] renderers;
    private Dictionary<Renderer, Material[]> cachedMaterials = new Dictionary<Renderer, Material[]>();

    void Awake()
    {
        renderers = GetComponentsInChildren<Renderer>();
    }

    void OnEnable()
    {
        foreach (var renderer in renderers)
        {
            var materials = renderer.materials;
            cachedMaterials[renderer] = materials;
            var newMaterials = new Material[materials.Length + 1];
            for (int i = 0; i < materials.Length; i++)
            {
                newMaterials[i] = materials[i];
            }
            newMaterials[materials.Length] = outlineMaterial;
            renderer.materials = newMaterials;
        }
    }

    void OnDisable()
    {
        foreach (var renderer in renderers)
        {
            renderer.materials = cachedMaterials[renderer];
        }
    }

    void Update()
    {
        foreach (var renderer in renderers)
        {
            var materials = renderer.materials;
            var outlineMaterialIndex = materials.Length - 1;
            materials[outlineMaterialIndex].SetFloat("_OutlineWidth", outlineWidth);
        }
    }
}
