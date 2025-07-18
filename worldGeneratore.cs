using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class worldGeneratore : MonoBehaviour
{
    public GameObject blockPrefab;
    
    
    public int width;
    public int length;
    public float noiseScale;
    public float heightScale;
    public List<Color> Colors;
    private void Start()
    {
        GenerateWorld();
    }


    public void GenerateWorld()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < length; j++)
            {
                int height = Mathf.CeilToInt(Mathf.PerlinNoise(i / noiseScale, j / noiseScale)*heightScale);
                
                for (int k = 0; k < height; k++)
                {
                    Vector3 pos = new Vector3(i, k, j);
                    GameObject cube = Instantiate(blockPrefab, pos, quaternion.identity);

                    int index = Mathf.FloorToInt(k / heightScale * Colors.Count);

                    cube.GetComponent<MeshRenderer>().material.color = Colors[index];

                }
                

            }
        }
    }
}
