using System.Collections.Generic;
using UnityEngine;

public class TerrainMeshBuilder 
{   
    public static Mesh Build(Terrain terrain) 
    {
        List<Vector3> vertices = new List<Vector3>();
        List<Vector2> uv       = new List<Vector2>();
        List<int> triangles    = new List<int>();

        float heightScale = 10f;

        for (int z = 0; z < Terrain.size.y; z++) 
        {
            for (int x = 0; x < Terrain.size.x; x++) 
            {
                int i = vertices.Count;

                float y0 = terrain.heights[x    , z    ] * heightScale;
                float y1 = terrain.heights[x + 1, z    ] * heightScale;
                float y2 = terrain.heights[x    , z + 1] * heightScale;
                float y3 = terrain.heights[x + 1, z + 1] * heightScale;

                float u0 = 0f, v0 = 0f;
                float u1 = 1f, v1 = 1f;

                vertices.AddRange(new Vector3[] {
                    new Vector3(x    , y0, z    ),
                    new Vector3(x    , y2, z + 1),
                    new Vector3(x + 1, y1, z    ),
                    new Vector3(x + 1, y3, z + 1),
                });

                uv.AddRange(new Vector2[] {
                    new Vector2(u0, v0), 
                    new Vector2(u0, v1), 
                    new Vector2(u1, v0),
                    new Vector2(u1, v1),
                });

                triangles.AddRange(new int[] {
                    i + 0, i + 1, i + 2, 
                    i + 2, i + 1, i + 3, 
                });
            }
        }

        Mesh mesh = new Mesh();
        mesh.SetVertices(vertices);
        mesh.SetUVs(0, uv);
        mesh.SetTriangles(triangles, 0);
        mesh.RecalculateNormals();

        return mesh;
    }
}