using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshTestThree : MonoBehaviour
{
    Mesh msh;

    Vector3[] vertices;
    int[] triangles;

    // Start is called before the first frame update
    void Start()
    {
        msh = new Mesh();
        GetComponent<MeshFilter>().mesh = msh;
        //gameObject.AddComponent(typeof(MeshRenderer));
        //MeshFilter filter = gameObject.AddComponent(typeof(MeshFilter)) as MeshFilter;
        //filter.mesh = msh;
        CreateShape();
        UpdateMesh();
    }

    void CreateShape()
    {

        //Vector3 x = new Vector3(0, 0, 0);
        //Vector3 y = new Vector3(0, 0, 1);
        //Vector3 z = new Vector3(1, 0, 0);
        vertices = new Vector3[]
        {
        new Vector3(0,0,0),
        new Vector3(0,0,1),
        new Vector3(1,0,0)
        };
        //vertices = new Vector3[3];
        //vertices[0] = new Vector3(0, 0, 0);

        triangles = new int[]
        {
            0, 1, 2
        };
    }

    void UpdateMesh()
    {
        msh.Clear();

        msh.vertices = vertices;
        msh.triangles = triangles;
    }
}
