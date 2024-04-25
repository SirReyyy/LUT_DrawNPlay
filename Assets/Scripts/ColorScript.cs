using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorScript : MonoBehaviour
{
    public Texture2D texture;
    void Start() {
        Color[] pixels = texture.GetPixels();

        // Example: Detect multiple colors
        int redCount = 0;
        int greenCount = 0;
        int blueCount = 0;

        foreach (Color pixel in pixels) {
            if (IsRed(pixel)) {
                redCount++;
            } else if (IsGreen(pixel)) {
                greenCount++;
            } else if (IsBlue(pixel)) {
                blueCount++;
            }
        }

        Debug.Log("Red count: " + redCount);
        Debug.Log("Green count: " + greenCount);
        Debug.Log("Blue count: " + blueCount);
    } //-- start end

    void Update() {
        
    } //-- Update end

    bool IsRed(Color color) {
        return color.r > 0.8f && color.g < 0.2f && color.b < 0.2f;
    }

    bool IsGreen(Color color) {
        return color.r < 0.2f && color.g > 0.8f && color.b < 0.2f;
    }

    bool IsBlue(Color color) {
        return color.r < 0.2f && color.g < 0.2f && color.b > 0.8f;
    }
} //-- class end


/*
Project: 
Made by: 
*/

