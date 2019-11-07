using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseMap : MonoBehaviour
{
    // funciton overflow on generateBaseNoise is to allow for offsets
    public float[,] generateBaseNoise(int mapX, int mapY, float scale)
    {
        // create an empty noise map with the mapDepth and mapWidth coordinates
        float[,] noiseMap = new float[mapX, mapY];

        for (int xIndex = 0; xIndex < mapX; xIndex++)
        {
            for (int yIndex = 0; yIndex < mapY; yIndex++)
            {
                // calculate sample indices based on the coordinates and the scale
                float sampley = yIndex / scale;
                float samplex = xIndex / scale;

                // generate noise value using PerlinNoise
                float noise = Mathf.PerlinNoise(sampley, samplex);

                noiseMap[xIndex, yIndex] = noise;
            }
        }

        return noiseMap;
    }

    public float[,] generateBaseNoisePerlin(int mapX, int mapY, float scale, float offsetX, float offsetY, float heightScale)
    {
        // create an empty noise map with the mapDepth and mapWidth coordinates
        float[,] noiseMap = new float[mapX, mapY];

        for (int xIndex = 0; xIndex < mapX; xIndex++)
        {
            for (int yIndex = 0; yIndex < mapY; yIndex++)
            {
                // calculate sample indices based on the coordinates and the scale
                float sampley = (yIndex + offsetY) / scale;
                float samplex = (xIndex + offsetX) / scale;

                // generate noise value using PerlinNoise
                float noise = Mathf.PerlinNoise(sampley, samplex) * heightScale;

                noiseMap[xIndex, yIndex] = noise;
            }
        }

        return noiseMap;
    }

    public float[,] generateBaseNoisePerlin(int mapX, int mapY, float scale, float offsetX, float offsetY)
    {
        // create an empty noise map with the mapDepth and mapWidth coordinates
        float[,] noiseMap = new float[mapX, mapY];

        for (int xIndex = 0; xIndex < mapX; xIndex++)
        {
            for (int yIndex = 0; yIndex < mapY; yIndex++)
            {
                // calculate sample indices based on the coordinates and the scale
                float sampley = (yIndex + offsetY) / scale;
                float samplex = (xIndex + offsetX) / scale;

                // generate noise value using PerlinNoise
                float noise = Mathf.PerlinNoise(sampley, samplex);

                noiseMap[xIndex, yIndex] = noise;
            }
        }

        return noiseMap;
    }

}
