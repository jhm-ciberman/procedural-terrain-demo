using UnityEngine;

public class Terrain3D : MonoBehaviour
{
    public void Start()
    {
        Terrain terrain = new Terrain();

        Mesh mesh = TerrainMeshBuilder.Build(terrain);

        this.GetComponent<MeshFilter>().sharedMesh = mesh;
    }
}