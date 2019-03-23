using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw_Polygon_Prism : Meshy
{
	[Range(3, 20)]
	public int Poly = 3;

    [Range(1, 20)]
    public float Height = 1;

	private List<Vector3> verticiesBottom;
    private List<Vector3> verticiesTop;

    private List<Triangle> listTriangles;

    protected override List<Triangle> Generate_Triangles()
    {
        Generate_Bottom_Polygon();
        Generate_Top_Polygon();

		listTriangles = new List<Triangle>();
		Triangle triangle;

		for (int i = 0; i < Poly - 2; i++)
		{
			triangle = new Triangle()
			{
				Vertex_1 = verticiesBottom[0],
				Vertex_2 = verticiesBottom[i + 1],
				Vertex_3 = verticiesBottom[i + 2]
			};

			listTriangles.Add(triangle);
		}

		for (int i = 0; i < Poly - 2; i++)
		{
			triangle = new Triangle()
			{
				Vertex_1 = verticiesTop[0],
				Vertex_2 = verticiesTop[i + 2],
				Vertex_3 = verticiesTop[i + 1]
			};

			listTriangles.Add(triangle);
		}

        Connect();

        return listTriangles;
    }

    private void Generate_Bottom_Polygon()
    {
        verticiesBottom = new List<Vector3>();

		float angleDiff = 360 / Poly;
		float angle = 0;

		Vector3 vertex;

		for (int i = 1; i <= Poly; i++)
		{
			vertex = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
			verticiesBottom.Add(vertex);

			angle = (Mathf.PI / 180) * (angleDiff * i);
			angle = angle % 360;
		}
    }

	private void Generate_Top_Polygon()
	{
        verticiesTop = new List<Vector3>();

		float angleDiff = 360 / Poly;
		float angle = 0;

		Vector3 vertex;

		for (int i = 1; i <= Poly; i++)
		{
            vertex = new Vector3(Mathf.Cos(angle), Height, Mathf.Sin(angle));
			verticiesTop.Add(vertex);

			angle = (Mathf.PI / 180) * (angleDiff * i);
			angle = angle % 360;
		}
	}

	private void Connect()
	{
        Triangle triangle;

        for (int i = 0; i < verticiesBottom.Count; i++)
        {
            triangle = new Triangle()
            {
                Vertex_1 = verticiesBottom[i],
                Vertex_2 = verticiesTop[i],
                Vertex_3 = verticiesTop[(i + 1) % verticiesBottom.Count]
            };

            listTriangles.Add(triangle);
        }

		for (int i = 0; i < verticiesTop.Count; i++)
		{
			triangle = new Triangle()
			{
				Vertex_1 = verticiesTop[i],
                Vertex_2 = verticiesBottom[i],
                Vertex_3 = verticiesBottom[((i - 1) + verticiesTop.Count) % verticiesTop.Count]
			};

			listTriangles.Add(triangle);
		}
    }
}
