using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBatch : MonoBehaviour
{
    public Texture2D drawingTexture;
    public Color targetColor = Color.blue;
    public float colorThreshold = 0.1f; // Adjust as needed
    public int minPixelDistance = 5; // Adjust as needed

    void Start()
    {
        int blueCount = 0;
        HashSet<Vector2Int> countedPixels = new HashSet<Vector2Int>();

        for (int y = 0; y < drawingTexture.height; y++)
        {
            for (int x = 0; x < drawingTexture.width; x++)
            {
                Color pixelColor = drawingTexture.GetPixel(x, y);
                Vector2Int pixelPosition = new Vector2Int(x, y);

                if (!countedPixels.Contains(pixelPosition) && ColorCloseToTarget(pixelColor, targetColor, colorThreshold))
                {
                    blueCount++;
                    CountAdjacentPixels(pixelPosition, countedPixels, targetColor, colorThreshold, minPixelDistance);
                }
            }
        }

        Debug.Log("Number of blue instances: " + blueCount);
    }

    bool ColorCloseToTarget(Color pixelColor, Color targetColor, float threshold)
    {
        float rDiff = Mathf.Abs(pixelColor.r - targetColor.r);
        float gDiff = Mathf.Abs(pixelColor.g - targetColor.g);
        float bDiff = Mathf.Abs(pixelColor.b - targetColor.b);

        return rDiff + gDiff + bDiff <= threshold;
    }

    void CountAdjacentPixels(Vector2Int startPixel, HashSet<Vector2Int> countedPixels, Color targetColor, float threshold, int minDistance)
    {
        Queue<Vector2Int> pixelsToCheck = new Queue<Vector2Int>();
        pixelsToCheck.Enqueue(startPixel);

        while (pixelsToCheck.Count > 0)
        {
            Vector2Int currentPixel = pixelsToCheck.Dequeue();
            countedPixels.Add(currentPixel);

            for (int y = -1; y <= 1; y++)
            {
                for (int x = -1; x <= 1; x++)
                {
                    if (x == 0 && y == 0) continue; // Skip the current pixel

                    Vector2Int neighborPixel = currentPixel + new Vector2Int(x, y);
                    if (countedPixels.Contains(neighborPixel)) continue; // Skip if already counted

                    Color neighborColor = drawingTexture.GetPixel(neighborPixel.x, neighborPixel.y);
                    if (ColorCloseToTarget(neighborColor, targetColor, threshold) && Vector2Int.Distance(currentPixel, neighborPixel) <= minDistance)
                    {
                        pixelsToCheck.Enqueue(neighborPixel);
                        countedPixels.Add(neighborPixel);
                    }
                }
            }
        }
    }

} //-- class end


/*
Project: 
Made by: 
*/

