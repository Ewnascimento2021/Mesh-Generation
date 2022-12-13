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

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
    }

    void CreateShape()
    {
        vertices = new Vector3[]
        {
            ////Cubo
            //new Vector3 (0,0,0),
            //new Vector3 (0,1,0),
            //new Vector3 (1,1,0),
            //new Vector3 (1,0,0),
            //new Vector3 (0,0,1),
            //new Vector3 (0,1,1),
            //new Vector3 (1,1,1),
            //new Vector3 (1,0,1)

            //Piramide
            new Vector3 (0,0,0),
            new Vector3 (2,0,0),
            new Vector3 (1,2,1),
            new Vector3 (0,0,2),
            new Vector3 (2,0,2)

        };

        triangles = new int[]
        {
            //Cubo
        ////face1
        //    0, 1, 2,
        //    0, 2, 3,
        ////face2
        //    4, 5, 0,
        //    0, 5, 1,
        ////face3
        //    3, 2, 7,
        //    7, 2, 6,
        ////face4
        //    6,4,7,
        //    6,5,4,
        ////face5
        //    1,5,2,
        //    2,5,6

        //Piramide
            0,2,1,
            3,2,0,
            1,2,4,
            4,2,3




            
        };
    }

    void UpdateMesh()
    {
        mesh.Clear();
        {
            mesh.vertices = vertices;
            mesh.triangles = triangles;
        }
    }


}
