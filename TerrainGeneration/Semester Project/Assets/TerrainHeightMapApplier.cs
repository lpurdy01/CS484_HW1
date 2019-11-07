using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainHeightMapApplier : MonoBehaviour
{
    public NoiseMap noiseMapGeneration;

    public Terrain terr;

    public float map1Scale;

    public Texture2D texture;

    public float height1Multiplier;

    public float map2Scale;

    public float height2Multiplier;

    public float map3Scale;

    public float height3Multiplier;

    public float seaLevelVal;


    void Start()
    {
        GenreateAndSetTerrain();
    }

    void GenreateAndSetTerrain()
    {
        // calculate tile depth and width based on the mesh vertices
        int tileDepth = terr.terrainData.heightmapWidth;
        int tileWidth = terr.terrainData.heightmapHeight;

        // calculate the offsets based on the tile position
        float offsetX = -this.gameObject.transform.position.x;
        float offsetZ = -this.gameObject.transform.position.z;

        // calculate the offsets based on the tile position
        float[,] heightMap = this.noiseMapGeneration.generateBaseNoisePerlin(tileDepth, tileWidth, this.map1Scale, offsetZ, offsetX, height1Multiplier);
        float[,] heightMap2 = this.noiseMapGeneration.generateBaseNoisePerlin(tileDepth, tileWidth, this.map2Scale, offsetZ, offsetX, height2Multiplier);
        float[,] heightMap3 = this.noiseMapGeneration.generateBaseNoisePerlin(tileDepth, tileWidth, this.map3Scale, offsetZ, offsetX, height3Multiplier);

        heightMap = mergeNoiseMaps(heightMap, heightMap2);
        heightMap = mergeNoiseMaps(heightMap, heightMap3);

        //heightMap = levelMin(heightMap, seaLevelVal);

        // generate a heightMap using noise
        Texture2D tileTexture = BuildTexture(heightMap);
        texture = tileTexture;
        // this.tileRenderer.material.mainTexture = tileTexture;

        terr.terrainData.SetHeights(0, 0, heightMap);
        //UpdateMeshVertices(heightMap);

    }

    private Texture2D BuildTexture(float[,] heightMap)
    {
        int tileDepth = heightMap.GetLength(0);
        int tileWidth = heightMap.GetLength(1);

        Color[] colorMap = new Color[tileDepth * tileWidth];
        for (int zIndex = 0; zIndex < tileDepth; zIndex++)
        {
            for (int xIndex = 0; xIndex < tileWidth; xIndex++)
            {
                // transform the 2D map index is an Array index
                int colorIndex = zIndex * tileWidth + xIndex;
                float height = heightMap[zIndex, xIndex];
                // assign as color a shade of grey proportional to the height value
                colorMap[colorIndex] = Color.Lerp(Color.black, Color.white, height);
            }
        }

        // create a new texture and set its pixel colors
        Texture2D tileTexture = new Texture2D(tileWidth, tileDepth);
        tileTexture.wrapMode = TextureWrapMode.Clamp;
        tileTexture.SetPixels(colorMap);
        tileTexture.Apply();

        return tileTexture;
    }

    private float[,] mergeNoiseMaps(float[,] map1, float[,] map2)
    {
        int mapX = map1.GetLength(0);
        int mapY = map1.GetLength(1);

        for (int xIndex = 0; xIndex < mapX; xIndex++)
        {
            for (int yIndex = 0; yIndex < mapY; yIndex++)
            {
                // calculate sample indices based on the coordinates and the scale
                map1[xIndex, yIndex] = (map1[xIndex, yIndex] + map2[xIndex, yIndex])/2 ;
            }
        }
        return map1;
    }

    private float[,] levelMin(float[,] map1, float minVal)
    {
        int mapX = map1.GetLength(0);
        int mapY = map1.GetLength(1);

        for (int xIndex = 0; xIndex < mapX; xIndex++)
        {
            for (int yIndex = 0; yIndex < mapY; yIndex++)
            {
                if (map1[xIndex, yIndex] > minVal)
                    map1[xIndex, yIndex] = minVal;
            }
        }
        return map1;
    }


}
