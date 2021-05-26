using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public Texture2D map;
    public ColorToPrefab[] colorMappings;
    public float offset = 5f;

    

    // Start is called before the first frame update
    void Start()
    {
        GenerateLabirynth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenerateTile(int x, int z)
    {
        Color pixelColor = map.GetPixel(x, z);
        Debug.Log(pixelColor);
        if (pixelColor.a == 0)
        {
            return;
        }
        foreach (ColorToPrefab colorMapping in colorMappings)
        {
            if (colorMapping.Color.Equals(pixelColor))
            {
                Vector3 position = new Vector3(x, 0, z) * offset;
                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
            }
        }
    }
    public void GenerateLabirynth()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int z = 0; z < map.height; z++)
            {
                GenerateTile(x, z);
            }
        }
    }
}
