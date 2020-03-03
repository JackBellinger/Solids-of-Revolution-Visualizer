using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//THIS SCRIPT IS THE SAME AS TEST THREE, BUT HAS BEEN ALTERED TO READ IN POINTS FROM A FILE INSTEAD OF USING A PREBUILT VECTOR3.

public class MeshTestFive : MonoBehaviour
{
    Mesh msh;

    Vector3[] vertices;
    int[] triangles;


    // Start is called before the first frame update
    void Start()
    {
        msh = new Mesh();
        GetComponent<MeshFilter>().mesh = msh;
        File2list.listify("x2", 0, 0, 1, 1); // populates Vector3[] uvs in File2list.

        CreateShape();
        UpdateMesh();
    }

    void CreateShape()
    {

        vertices = File2list.points2;

        triangles = new int[]
        {
            0, 1, 2,
            1, 3, 2,
            2, 4, 3,
        };
    }

    void UpdateMesh()
    {
        msh.Clear();

        msh.vertices = vertices;
        msh.triangles = triangles;
    }
}
