using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainHeightMapApplier : MonoBehaviour
{
    public NoiseMap noiseMapGeneration;

    public Terrain terr;

    public float map1Scale;

    public Texture2D texture;
    public Texture2D textureAfter;

    public float height1Multiplier;

    public float map2Scale;

    public float height2Multiplier;

    public float map3Scale;

    public float height3Multiplier;

    public float seaLevelVal;

    private bool updatingTerrain = false;


    void Start()
    {
        GenreateAndSetTerrain();
    }

    void Update()
    {
        float testToRunUpdate = Input.GetAxis("Jump");

        if (testToRunUpdate > 0 && !updatingTerrain)
        {
            updatingTerrain = true;
            GenreateAndSetTerrain();
            updatingTerrain = false;
        }

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

        heightMap = matrixPass(heightMap);

        Texture2D tileTexture2 = BuildTexture(heightMap);
        textureAfter = tileTexture2;

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
                map1[xIndex, yIndex] = (map1[xIndex, yIndex] + map2[xIndex, yIndex]) / 2;
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

    private float[,] matrixPass(float[,] map1)
    {

        int mapX = map1.GetLength(0);
        int mapY = map1.GetLength(1);

        float[,] noiseMap = new float[mapX, mapY];

        for (int xIndex = 1; xIndex+1 < mapX; xIndex++)
        {
            for (int yIndex = 1; yIndex+1 < mapY; yIndex++)
            {
                float centerValue = 0;

                //Top left
                centerValue = centerValue + map1[xIndex - 1, yIndex - 1] * 0;
                //Top center
                centerValue = centerValue + map1[xIndex, yIndex - 1] * - 2;
                //Top right
                centerValue = centerValue + map1[xIndex + 1, yIndex - 1] * 0;

                //Middle left
                centerValue = centerValue + map1[xIndex - 1, yIndex] * - 2;
                //cener
                centerValue = centerValue + map1[xIndex, yIndex] * 10;
                //Middle right
                centerValue = centerValue + map1[xIndex + 1, yIndex] * - 2;

                //Lower left
                centerValue = centerValue + map1[xIndex - 1, yIndex + 1] * 0;
                //lower center
                centerValue = centerValue + map1[xIndex, yIndex - 1] * - 2;
                //lower right
                centerValue = centerValue + map1[xIndex + 1, yIndex - 1] * 0;

                centerValue = centerValue/2;

                noiseMap[xIndex, yIndex] = centerValue;

            }
        }
        return noiseMap;

    }
}
