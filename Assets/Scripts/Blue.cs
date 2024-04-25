using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : MonoBehaviour
{
    public Texture2D drawingTexture;
    public Color targetColor = Color.blue;
    public float colorThreshold = 0.1f; // Adjust as needed

    void Start()
    {
        int blueCount = 0;

        for (int y = 0; y < drawingTexture.height; y++)
        {
            for (int x = 0; x < drawingTexture.width; x++)
            {
                Color pixelColor = drawingTexture.GetPixel(x, y);
                if (ColorCloseToTarget(pixelColor, targetColor, colorThreshold))
                {
                    blueCount++;
                }
            }
        }

        Debug.Log("Number of blue pixels: " + blueCount);
    }

    bool ColorCloseToTarget(Color pixelColor, Color targetColor, float threshold)
    {
        float rDiff = Mathf.Abs(pixelColor.r - targetColor.r);
        float gDiff = Mathf.Abs(pixelColor.g - targetColor.g);
        float bDiff = Mathf.Abs(pixelColor.b - targetColor.b);

        return rDiff + gDiff + bDiff <= threshold;
    }

    void Update() {
        
    } //-- Update end

} //-- class end


/*
Project: 
Made by: 
*/

