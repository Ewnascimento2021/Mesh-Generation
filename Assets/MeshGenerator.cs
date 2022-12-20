using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    public int xSize = 20;
    public int zSize = 20;


    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        StartCoroutine(CreateShape());
    }

    private void Update()
    {
        UpdateMesh();
    }

    IEnumerator CreateShape()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(x * .3f, z * .3f) * 2f;
                vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }

        triangles = new int[xSize * zSize * 6];

        int vert = 0;
        int tris = 0;

        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;

                yield return new WaitForSeconds(.01f);
            }
            vert++;
        }

    }

    void UpdateMesh()
    {
        mesh.Clear();
        {
            mesh.vertices = vertices;
            mesh.triangles = triangles;

            mesh.RecalculateNormals();
        }
    }

    private void OnDrawGizmos()
    {
        if (vertices == null)
            return;

        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], .1f);
        }
    }

}

// Cordenadas de Quadrado e Piramide
//vertices = new Vector3[]
//{
//    ////Cubo
//    //new Vector3 (0,0,0),
//    //new Vector3 (0,1,0),
//    //new Vector3 (1,1,0),
//    //new Vector3 (1,0,0),
//    //new Vector3 (0,0,1),
//    //new Vector3 (0,1,1),
//    //new Vector3 (1,1,1),
//    //new Vector3 (1,0,1)
//    //Piramide
//    new Vector3 (0,0,0),
//    new Vector3 (2,0,0),
//    new Vector3 (1,2,1),
//    new Vector3 (0,0,2),
//    new Vector3 (2,0,2)
//};
//triangles = new int[]
//{
//    //Cubo
//////face1
////    0, 1, 2,
////    0, 2, 3,
//////face2
////    4, 5, 0,
////    0, 5, 1,
//////face3
////    3, 2, 7,
////    7, 2, 6,
//////face4
////    6,4,7,
////    6,5,4,
//////face5
////    1,5,2,
////    2,5,6
////Piramide
//    0,2,1,
//    3,2,0,
//    1,2,4,
//    4,2,3
//};
