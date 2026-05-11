using UnityEngine;
using System.Collections;

public class Outliner : MonoBehaviour
{
    /* ==== OUTLINE SETTINGS ==== */
    public Color meshColor = new Color(1f, 1f, 1f, 0.5f); // Transparent color applied to original mesh
    public Color outlineColor = new Color(1f, 1f, 0f, 1f); // Outline glow/border color

     /* ==== INITIALIZATION ==== */
    public void Start()
    {
        /* ==== ORIGINAL OBJECT MATERIAL ==== */
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>(); // Get MeshRenderer attached to object
        Material[] materials = meshRenderer.materials; // Get all materials used by mesh
        int materialsNum = materials.Length; // Store number of materials

        // Loop through all materials
        for (int i = 0; i < materialsNum; i++)
        {
            materials[i].shader = Shader.Find("Outline/Transparent"); // Replace material shader with transparent outline shader
            materials[i].SetColor("_color", meshColor); // Apply transparent mesh color
        }

         /* ==== CREATE OUTLINE OBJECT ==== */
        GameObject outlineObj = new GameObject(); // Create duplicate object, used only for outline effect
        outlineObj.transform.position = transform.position; // Match original object position
        outlineObj.transform.rotation = transform.rotation; // Match original object rotation
        outlineObj.AddComponent<MeshFilter>(); // Add mesh components to outline object
        outlineObj.AddComponent<MeshRenderer>();

        /* ==== COPY ORIGINAL MESH ==== */
        Mesh mesh;
        mesh = (Mesh)Instantiate(GetComponent<MeshFilter>().mesh); // Clone original mesh
        outlineObj.GetComponent<MeshFilter>().mesh = mesh;  // Apply copied mesh to outline object

        /* ==== PARENT OUTLINE TO ORIGINAL ==== */
        outlineObj.transform.parent = this.transform; // Make outline object follow original object
        
        /* ==== CREATE OUTLINE MATERIALS ==== */
        materials = new Material[materialsNum];  // Create new materials array

        // Loop through materials
        for (int i = 0; i < materialsNum; i++)
        {
            materials[i] = new Material(Shader.Find("Outline/Outline")); // Create outline material
            materials[i].SetColor("_OutlineColor", outlineColor); // Apply outline color
        }
        /* ==== APPLY OUTLINE MATERIALS ==== */
        outlineObj.GetComponent<MeshRenderer>().materials = materials;

    }

}
