using UnityEngine;
using TMPro;

public class BuildingHighlight : MonoBehaviour
{
    public Material highlightMaterial;
    private Material[] originalMaterials;
    private Renderer rend;
    private bool isHighlighted = false;
    public GameObject text;

    void Start()
    {
        rend = GetComponent<Renderer>();
        if (rend != null)
        {
            originalMaterials = rend.materials;
        }
    }

    public void AddHighlight()
    {
        if (!isHighlighted && rend != null)
        {
            text.SetActive(true);
            Material[] newMaterials = new Material[rend.materials.Length + 1];
            for (int i = 0; i < rend.materials.Length; i++)
            {
                newMaterials[i] = rend.materials[i];
            }
            newMaterials[newMaterials.Length - 1] = highlightMaterial;

            rend.materials = newMaterials;
            isHighlighted = true;
        }
    }

    public void RemoveHighlight()
    {
        if (isHighlighted && rend != null)
        {
            text.SetActive(false);
            Material[] newMaterials = new Material[originalMaterials.Length];
            int index = 0;
            foreach (Material mat in originalMaterials)
            {
                if (mat != highlightMaterial)
                {
                    newMaterials[index] = mat;
                    index++;
                }
            }

            rend.materials = newMaterials;
            isHighlighted = false;
        }
    }
}
