using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public abstract class Meshy : MonoBehaviour
{
    public bool Redraw;
    public bool ConstantRedraw = true;

    protected abstract List<Triangle> Generate_Triangles();

	private Mesh mesh;
	private MeshRenderer meshRenderer;
	private MeshFilter meshFilter;

    private List<Vector3> Verticies; 

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshFilter = GetComponent<MeshFilter>();

        Generate_Mesh();
    }

    private void Update()
    {
        if (ConstantRedraw)
        {
            Generate_Mesh();
        }
        else
        {
            if (Redraw)
            {
                Redraw = false;
                Generate_Mesh();
            }
        }
    }

    private void Generate_Mesh()
    {
        mesh = new Mesh();

        List<Triangle> tris = Generate_Triangles();

        Verticies = new List<Vector3>();

        foreach (Triangle triangle in tris)
        {
            Verticies.Add(triangle.Vertex_1);
            Verticies.Add(triangle.Vertex_2);
            Verticies.Add(triangle.Vertex_3);
        }

        mesh.SetVertices(Verticies);

        List<int> triangles = new List<int>();

        for (int i = 0; i < Verticies.Count; i++)
        {
            triangles.Add(i);
        }

        mesh.SetTriangles(triangles, 0);

        mesh.RecalculateNormals();

        meshFilter.mesh = mesh;
    }
}
