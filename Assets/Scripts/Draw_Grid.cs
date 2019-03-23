using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw_Grid : Meshy
{
    [Range(20, 100)]
    public int Resolution = 20;

    private Dictionary<Vector2, Vector3> verticies;

    private int offset;
    private Vector3 vertex;

    private float ripple;
    private bool rippleUp;

    protected override List<Triangle> Generate_Triangles()
    {
        Generate_Verticies();

        List<Triangle> listTriangles = new List<Triangle>();
        Triangle triangle;

        for (int i = -offset; i <= offset - 1; i++)
        {
            for (int j = -offset; j <= offset - 1; j++)
            {
                triangle = new Triangle()
                {
                    Vertex_1 = verticies[new Vector2(i, j)],
                    Vertex_2 = verticies[new Vector2(i, j + 1)],
                    Vertex_3 = verticies[new Vector2(i + 1, j)]
                };

                listTriangles.Add(triangle);

                triangle = new Triangle()
                {
                    Vertex_1 = verticies[new Vector2(i + 1, j)],
                    Vertex_2 = verticies[new Vector2(i, j + 1)],
                    Vertex_3 = verticies[new Vector2(i + 1, j + 1)]
                };

                listTriangles.Add(triangle);
            }
        }

        return listTriangles;
    }

    private void Generate_Verticies()
    {
        verticies = new Dictionary<Vector2, Vector3>();

        if (rippleUp)
        {
            ripple += 0.1f;

            if (0.5f < ripple)
                rippleUp = false;
        }
        else
        {
            ripple -= 0.1f;

            if (ripple < -0.5f)
				rippleUp = true;
        }

        offset = int.Parse(Mathf.Floor(Resolution * 0.5f).ToString());

        for (int i = -offset; i <= offset; i++)
        {
            for (int j = -offset; j <= offset; j++)
            {
                Sin(i, j);

                verticies[new Vector2(i, j)] = vertex;
            }
        }
    }

    private Vector3 Vase(int x, int y)
    {
        float radius = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));

        return new Vector3(x, radius, y);
    }

    private void Sin(int x, int y)
    {
        float radius = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));

        vertex = new Vector3(x, Mathf.Sin(radius) * ripple, y);
    }

    private Vector3 Angular(int x, int y)
    {
        float angle = Mathf.Atan2(y, x);
        float sin = Mathf.Abs(Mathf.Sin(angle));

        return new Vector3(x * 10, sin * 20, y * 10);
    }
}
