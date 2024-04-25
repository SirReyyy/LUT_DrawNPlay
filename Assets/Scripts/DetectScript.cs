using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectScript : MonoBehaviour
{
    public Texture2D drawingTexture;

    void Start() {
        Color[] pixels = drawingTexture.GetPixels();

        // Use a HashSet to store unique colors
        HashSet<Color> uniqueColors = new HashSet<Color>();

        foreach (Color pixel in pixels)
        {
            // Add each color to the HashSet
            uniqueColors.Add(pixel);
        }

        // Output the detected colors
        foreach (Color color in uniqueColors)
        {
            Debug.Log("Detected color: " + color);
        }
    } //-- start end

    void Update() {
        
    } //-- Update end

} //-- class end


/*
Project: 
Made by: 
*/

