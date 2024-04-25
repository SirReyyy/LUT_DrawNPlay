using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBatchDraw : MonoBehaviour
{
    public Texture2D drawingTexture;
    public Color targetColor = Color.blue;
    public float colorThreshold = 0.1f; // Adjust as needed
    public int minPixelDistance = 5; // Adjust as needed
    public GameObject linePrefab;

    void Start()
    {
        int blueCount = 0;
        HashSet<Vector2Int> countedPixels = new HashSet<Vector2Int>();
        List<Vector2Int> detectedPositions = new List<Vector2Int>();

        for (int y = 0; y < drawingTexture.height; y++)
        {
            for (int x = 0; x < drawingTexture.width; x++)
            {
                Color pixelColor = drawingTexture.GetPixel(x, y);
                Vector2Int pixelPosition = new Vector2Int(x, y);

                if (!countedPixels.Contains(pixelPosition) && ColorCloseToTarget(pixelColor, targetColor, colorThreshold))
                {
                    blueCount++;
                    List<Vector2Int> detectedInstance = new List<Vector2Int>();
                    CountAdjacentPixels(pixelPosition, countedPixels, detectedInstance, targetColor, colorThreshold, minPixelDistance);
                    detectedPositions.AddRange(detectedInstance);
                }
            }
        }

        foreach (Vector2Int position in detectedPositions)
        {
            Instantiate(linePrefab, new Vector3(position.x, position.y, 0), Quaternion.identity);
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

    void CountAdjacentPixels(Vector2Int startPixel, HashSet<Vector2Int> countedPixels, List<Vector2Int> detectedInstance, Color targetColor, float threshold, int minDistance)
    {
        Queue<Vector2Int> pixelsToCheck = new Queue<Vector2Int>();
        pixelsToCheck.Enqueue(startPixel);

        while (pixelsToCheck.Count > 0)
        {
            Vector2Int currentPixel = pixelsToCheck.Dequeue();
            countedPixels.Add(currentPixel);
            detectedInstance.Add(currentPixel);

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
                        detectedInstance.Add(neighborPixel);
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

