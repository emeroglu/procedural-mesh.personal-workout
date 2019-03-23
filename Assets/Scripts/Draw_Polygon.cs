using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw_Polygon : Meshy
{
    [Range(3, 20)]
    public int Poly = 3;

    private List<Vector3> verticies;

    protected override List<Triangle> Generate_Triangles()
    {
        Generate_Verticies();

        List<Triangle> listTriangles = new List<Triangle>();
        Triangle triangle;

        for (int i = 0; i < Poly - 2; i++)
        {
            triangle = new Triangle()
            {
                Vertex_1 = verticies[0],
                Vertex_2 = verticies[i + 1],
                Vertex_3 = verticies[i + 2]
            };

            listTriangles.Add(triangle);
        }

        return listTriangles;
    }

    private void Generate_Verticies()
    {
        verticies = new List<Vector3>();

        float angleDiff = 360 / Poly;
        float angle = 0;

        Vector3 vertex;

        for (int i = 1; i <= Poly; i++)
        {
            vertex = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
            verticies.Add(vertex);

            angle = (Mathf.PI / 180) * (angleDiff * i);
            angle = angle % 360;
        }
    }
}
