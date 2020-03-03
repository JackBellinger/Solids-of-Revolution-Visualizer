using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using System.Diagnostics;


public class File2list : MonoBehaviour
{
    public static List<Vector3> points = new List<Vector3>();
    public static List<Vector3> meshpoints = new List<Vector3>();
    public static List<Vector3> meshnormals = new List<Vector3>();
    public static Vector2[] uvs = new Vector2[1000]; // 1000 vertices means 1000 uvs
    public static Vector3[] points2 = new Vector3[1000]; // 1000 vertices means 1000 uvs
    //public String filename; // added 2/26/20 by Kyle to make filename accessible through Unity interface. This makes the user able to change which file is read from.

    public static void listify(String filename, int xshift = 0, int yshift = 0, int xscale = 1, int yscale = 1)
    {
        string line;
        string[] pairs;
        string path = Path.GetFullPath("./Assets/EquationData/" + filename + ".txt");
        System.IO.StreamReader file = new System.IO.StreamReader(path);
        int counter = 0; // for while loop
        while((line = file.ReadLine()) != null)
        {
            pairs = line.Split(',');
            points.Add(new Vector3((xscale * float.Parse(pairs[0])) + xshift, (yscale * float.Parse(pairs[1])) + yshift, 5));
            points2[counter] = new Vector3((xscale * float.Parse(pairs[0])) + xshift, (yscale * float.Parse(pairs[1])) + yshift, 5); // CHANGED FROM points.Add TO WORK WITH AN ARRAY RATHER THAN A LIST
        }
    }

    public static void listify2D(String filename, int xshift = 0, int yshift = 0, int xscale = 1, int yscale = 1)
    {
        string line;
        string[] pairs;
        string path = Path.GetFullPath("./Assets/EquationData/" + filename + ".txt");
        System.IO.StreamReader file = new System.IO.StreamReader(path);
        int counter = 0; // used for while loop
        while ((line = file.ReadLine()) != null)
        {
            pairs = line.Split(',');
            uvs[counter] = new Vector2((xscale * float.Parse(pairs[0])) + xshift, (yscale * float.Parse(pairs[1])) + yshift);
            counter++;
        }
    }

    public static void extend()
    {
        List<Vector3> linemaker = new List<Vector3>();
        linemaker.Add(new Vector3(0, 0, .025f));
        linemaker.Add(new Vector3(0, (.025f / ((float)Math.Sqrt(2))), (.025f / ((float)Math.Sqrt(2)))));
        linemaker.Add(new Vector3(0, .025f, 0));
        linemaker.Add(new Vector3(0, (-.025f / ((float)Math.Sqrt(2))), (.025f / ((float)Math.Sqrt(2)))));
        linemaker.Add(new Vector3(0, 0, -.025f));
        linemaker.Add(new Vector3(0, (-.025f / ((float)Math.Sqrt(2))), (-.025f / ((float)Math.Sqrt(2)))));
        linemaker.Add(new Vector3(0, -.025f, 0));
        linemaker.Add(new Vector3(0, (.025f / ((float)Math.Sqrt(2))), (-.025f / ((float)Math.Sqrt(2)))));
        foreach (Vector3 element in points)
        {
            for(int i = 0; i < 8; i++)
            {
                meshpoints.Add(element+linemaker[i]);
                meshnormals.Add(linemaker[i]);
            }
        }
    }
}
