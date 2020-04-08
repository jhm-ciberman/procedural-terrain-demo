using UnityEngine;

public class Terrain
{
    public static Vector2Int size = new Vector2Int(20, 20);

    public float[,] heights;

    public Terrain()
    {
        this.heights = new float[Terrain.size.x + 1, Terrain.size.y + 1];

        var sampler = new NoiseSampler(seed : 0);

        for (int y = 0; y <= Terrain.size.y; y++) 
        {
            for (int x = 0; x <= Terrain.size.x; x++) 
            {
                this.heights[x, y] = sampler.Sample(x, y); 
            }
        }
    }
}