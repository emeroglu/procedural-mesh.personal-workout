using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw_Triangle : Meshy
{
    public Vector3 Vertex_1;
    public Vector3 Vertex_2;
    public Vector3 Vertex_3;

    protected override List<Triangle> Generate_Triangles()
    {
        return new List<Triangle>()
        {
            new Triangle()
            {
                Vertex_1 = Vertex_1,
                Vertex_2 = Vertex_2,
                Vertex_3 = Vertex_3
            }
        };
    }
}
