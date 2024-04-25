using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewScript : MonoBehaviour
{
    public Texture2D image;

    void Start() {
        Color[] pixels = image.GetPixels();

        foreach (Color pixel in pixels)
        {
            // Do something with the pixel color
            Debug.Log(pixel);
        }
    } //-- start end

    void Update() {
        
    } //-- Update end

} //-- class end


/*
Project: 
Made by: 
*/

