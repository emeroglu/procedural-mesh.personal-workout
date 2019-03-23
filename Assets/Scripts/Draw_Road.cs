using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security;

public class Draw_Road : Meshy
{
    private List<Vector3> verticies;

    private List<Vector4> theRoad;

    protected override List<Triangle> Generate_Triangles()
    {
        Generate_Road();
        Generate_Verticies();

        List<Triangle> listTriangles = new List<Triangle>();
        Triangle triangle;

        for (int i = 0; i < verticies.Count - 3; i++)
        {
            triangle = new Triangle()
            {
                Vertex_1 = verticies[i],
                Vertex_2 = verticies[i + 2],
                Vertex_3 = verticies[i + 1]
            };

            listTriangles.Add(triangle);

            triangle = new Triangle()
            {
                Vertex_1 = verticies[i + 2],
                Vertex_2 = verticies[i + 3],
                Vertex_3 = verticies[i + 1]
            };

            listTriangles.Add(triangle);
        }

        return listTriangles;
    }

    private void Generate_Road()
    {
        theRoad = new List<Vector4>()
        {
            new Vector4(0, 0, 0, 90),
            new Vector4(0, 0, 1, 45),
            new Vector4(3, 0, 3, 45),
            new Vector4(3, 0, 5, 90)
        };
    }

    private void Generate_Verticies()
    {
        verticies = new List<Vector3>();

        float zLeftOffset, zRightOffset;

        foreach (Vector4 point in theRoad)
        {
            zLeftOffset = 0;
            zRightOffset = 0;

            if (point.w == 45)
            {
                zLeftOffset = 0.5f;
                zRightOffset = -0.5f;
            }

            verticies.Add(new Vector3(point.x - 0.5f, 0, point.z + zLeftOffset));
            verticies.Add(new Vector3(point.x + 0.5f, 0, point.z + zRightOffset));
        }
    }
}

public class RoadPoint
{
    public Vector3 Position { get; set; }
    public float Direction { get; set; }
}
