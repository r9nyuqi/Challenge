using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    public int width = 256;
    public int height = 256;
    public float scale = 20f;
    public float offsetX = 100;
    public float offsetY = 100;

    void Update()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = GenerateTexture();
    }


    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);
        for(int i = 0; i < width; i ++)
        {
            for (int j = 0; j < height; j++)
            {
                Color color = CalculateColor(i, j);
                texture.SetPixel(i, j, color);

            }


        }



        texture.Apply();
        return texture;
    }

    Color CalculateColor(int x, int y)
    {

        float fX = (float)x / width * scale +offsetX;
        float fY = (float)y / height * scale + offsetY;
        float f = Mathf.PerlinNoise(fX, fY);

        if(f > 0.3)
        {
            return new Color(1, 1, 1);
        }
        else
        {
            return new Color(0, 0, 0);
        }
        

    }
}
