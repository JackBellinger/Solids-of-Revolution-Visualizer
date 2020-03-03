using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using System.IO;

public class LoadVectors : MonoBehaviour
{

    //Vector2[] newUVs; DEPRECATED
    //int[] newTriangles;
    //List<Vector3> eqPoints = line_draw_brush.drawn_points; // gets the lists of points from line_draw_brush.cs
    //List<Vector3> eqPoints = File2list.points; //accesses list of points from File2list.cs successfully.
    //eqPoints.File2list.listify("x2", 0, 0, 1, 1); // would this make line 12 redundant??
    //Vector2[] uvs = new Vector2[1000]; // 1000 is length we are currently working with

    void Start()
    {
        Vector2[] uvs = new Vector2[1000]; // 1000 is length we are currently working with
        // Create Vector2 vertices
        File2list.listify2D("x2", 0, 0, 1, 1); // populates Vector2[] uvs in File2list.
        Vector2[] vertices2D = File2list.uvs; // takes above populated array and copies pointer to it

        // Use the triangulator to get indices for creating triangles
        //Triangulator tr = new Triangulator(vertices2D);
        //int[] indices = tr.Triangulate();

        // Create the Vector3 vertices
        Vector3[] vertices = new Vector3[vertices2D.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = new Vector3(vertices2D[i].x, vertices2D[i].y, 5);
        }

        // Create the mesh
        Mesh msh = new Mesh();
        msh.vertices = vertices;
        //msh.triangles = indices;
        msh.RecalculateNormals();
        msh.RecalculateBounds();

        // Set up game object with mesh;
        gameObject.AddComponent(typeof(MeshRenderer));
        MeshFilter filter = gameObject.AddComponent(typeof(MeshFilter)) as MeshFilter;
        filter.mesh = msh;
    }
    /*
    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = new Mesh();
        //GetComponent<MeshFilter>().mesh = mesh;
        GameObject gameObject = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
        mesh.SetVertices(eqPoints);

        for (int i = 0; i < uvs.Length; i++)
        {
            uvs[i] = new Vector2(vertices[i].x, vertices[i].z);
        }
        mesh.uv = uvs;
        mesh.triangles = newTriangles;
    }
    */

}