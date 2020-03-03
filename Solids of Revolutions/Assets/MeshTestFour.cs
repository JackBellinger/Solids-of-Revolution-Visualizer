using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS FILE TESTS TO SEE IF WE CAN CREATE A MESH WITHOUT A PREINSTANTIATED GAMEOBJECT. NOT CURRENTLY WORKING.

public class MeshTestFour : MonoBehaviour
{
    Mesh msh;
    GameObject newObject;

    Vector3[] vertices;
    int[] triangles;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject = Instantiate(newObject, new Vector3(0, 0, 5), Quaternion.identity) as GameObject; // not working?
        msh = new Mesh();
        //GetComponent<MeshFilter>().mesh = msh; FROM TEST THREE
        gameObject.AddComponent(typeof(MeshRenderer));
        MeshFilter filter = gameObject.AddComponent(typeof(MeshFilter)) as MeshFilter;
        filter.mesh = msh;
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
