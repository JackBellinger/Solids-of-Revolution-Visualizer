using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//THIS SCRIPT IS THE SAME AS TEST THREE, BUT HAS BEEN ALTERED TO READ IN POINTS FROM A FILE INSTEAD OF USING A PREBUILT VECTOR3.

public class MeshTestFive : MonoBehaviour
{
    Mesh msh;
    Mesh msh2;
    GameObject yes;
    public Material mesh2;
    public line_draw_brush brushPrefab;
    public line_draw_brush brush;
    public bool started_drawing = false;
    List<GameObject> meshes = new List<GameObject>();
    List<Vector3> list = new List<Vector3>();
    Vector3[] vertices;
    Vector3[] vertices2;
    int[] triangles;
    int[] triangles2;
    public string Function;
    public int RingNum, RotationNum; // for indexify, replace rnum and rlen respectively. static so that Rotator.cs may access.
    public int xscale, yscale; // for listify function call
    bool cleared = true;
    bool menu_visible = true;
    GameObject user_menu;
    GameObject bounds_menu;
    public static string menu_string = "Press the M/N Key to\nGenerate the Mesh,\nB to toggle canvas, C to clear";

    // Start is called before the first frame update
    public void Start()
    {
      msh = new Mesh();
      msh2 = new Mesh();
      user_menu = GameObject.Find("UserMenu");
      bounds_menu = GameObject.Find("BoundsManager");
    }
    public int generate(string Function, float start, float end)
    {
        for(int i = 0; i < meshes.Count; i++)
        {
            Destroy(meshes[i]);
        }
        meshes.Clear();
        msh = new Mesh();
        msh2 = new Mesh();

        yes = new GameObject("Mesh2");
        meshes.Add(yes);
        // Set up game object with mesh;
        MeshRenderer renderer = yes.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
        //Material newMat = Resources.Load("Assets/MixedRealityToolkit.SDK/StandardAssets/Materials/MRTK_Standard_Orange.mat", typeof(Material)) as Material;
        //renderer.material = materials[0];
        //renderer.materials[0] = newMat;
        renderer.material = mesh2;
        MeshFilter filter = yes.AddComponent(typeof(MeshFilter)) as MeshFilter;
        filter.mesh = msh2;

        GetComponent<MeshFilter>().mesh = msh;

        //File2list.listify(Function, 0, 0, xscale, yscale); // populates Vector3[] uvs in File2list.
        if (Function == "x")
            list = Gen_Lin(start, end);
        else if (Function == "x2")
            list = Gen_Quad(start, end);
        else if (Function == "x3")
            list = Gen_Cube(start, end);
        else if (Function == "sqrt")
            list = Gen_Sqrt(start, end);
        else if (Function == "recip")
            list = Gen_Recip(start, end);
        else if (Function == "sin")
            list = Gen_Sin(start, end);
        else if (Function == "cos")
            list = Gen_Cos(start, end);
        else if (Function == "exp")
            list = Gen_Exp(start, end);
        else if (Function == "const")
            list = Gen_Const(start, end);
        else if (Function == "Draw")
            list = brush.drawn_points;

        if (list != null)
        {
            RingNum = list.Count;
            File2list.points.Clear();
            for (int i = 0; i < list.Count; i++)
                File2list.points.Add(list[i]);

            Create2dMesh();

            UpdateMesh(vertices2);
        }
        else
        {
            return 1;
        }
        cleared = false;
        return 0;
    }

    void Update()
    {
        if (Input.GetKeyDown("v"))//toggle user_menu visibilty
        {
          user_menu.SetActive(!user_menu.activeSelf);
          bounds_menu.SetActive(!bounds_menu.activeSelf);
          menu_visible = !menu_visible;
        }
        if(menu_visible){
          TextMesh displayInfo = user_menu.GetComponentInChildren<TextMesh>();
          displayInfo.text = menu_string;
        }
        if (Input.GetKeyDown("c"))//clear screen
        {
          ClearAll();
          GameObject user_menu = GameObject.Find("UserMenu");
          menu_string = "Press the M/N Key to\nGenerate the Mesh,\nB to toggle canvas, C to clear";
        }

        if (Input.GetKeyDown("m"))//rotate x
        {
            if (!cleared)
            {
                CreateShape();
                UpdateMesh(vertices);
                //GameObject user_menu = GameObject.Find("UserMenu");

                List<Vector3> ZERO = new List<Vector3>(File2list.points.Count);
                for (int i = 0; i < File2list.points.Count; i++)
                {
                    ZERO.Add(new Vector3(0, 0, 0));
                }
                menu_string = ("Volume: " + VolumeCalc(File2list.points, ZERO).ToString("#.00") + "\n" + "Surface Area: " + SurfaceCalc(File2list.points).ToString("#.00"));
            }
        }
        if (Input.GetKeyDown("n"))//rotate y
        {
            if (!cleared)
            {
                CreateShapeAroundY();
                UpdateMesh(vertices);

                List<Vector3> ZERO = new List<Vector3>(File2list.points.Count);
                for (int i = 0; i < File2list.points.Count; i++)
                {
                    ZERO.Add(new Vector3(0, 0, 0));
                }
                menu_string = ("Volume: " + VolumeCalcY(File2list.points, ZERO).ToString("#.00") + "\n" + "Surface Area: " + SurfaceCalcY(File2list.points).ToString("#.00"));
            }
        }
        if (Input.GetKeyDown("b") && !started_drawing) // maybe move out of update for performance?
        {
          brush = Instantiate(brushPrefab, new Vector3(0, 0, 5), Quaternion.Euler(0, 0, 0));
          started_drawing = true;
        }
        if(started_drawing){
           if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            brush.move("up");
          if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            brush.move("down");
          if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            brush.move("right");
          if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            brush.move("left");

          if (brush.line_done)
          {

            generate("Draw", 0, 0);
            Create2dMesh();
            UpdateMesh(vertices2);
            Destroy(brush.gameObject);
            started_drawing = false;
          }
        }
    }

    void ClearAll()
    {
        msh.Clear();
        msh2.Clear();
        meshes.Clear();
        list.Clear();
        cleared = true;
    }

    void Create2dMesh()//for displaying a 2d line
    {
        int smallNum = RingNum * RotationNum;
        List<Vector3> points = File2list.extendify();
        vertices2 = new Vector3[smallNum];
        for(int i = 0; i < smallNum; i++)
        {
            vertices2[i] = points[i];
        }

        indexify(RingNum, RotationNum);
    }

    void CreateShape()
    {
      if(RingNum > 0 && File2list.points.Count > 0)
      {
        //Debug.Log("ringnum " + RingNum);
        //Debug.Log("points count " + File2list.points.Count);
        int bigNum = (RingNum * RotationNum); // local, used for vertices Vector3 below
        vertices = new Vector3[bigNum];
        List<Vector3> rot = do_Rotation(File2list.points);
        for (int i = 0; i < bigNum; i++)
        {
            vertices[i] = rot[i];
        }
        //Debug.Log("vertex 1 " + vertices[0] + "vertex count = " + vertices.Count);


        indexify(RingNum, RotationNum);
      }
    }

    void CreateShapeAroundY() // ADDED TO DIFFERENTIATE FROM CreateShape() which is called to rotate the curve around the x-axis
    {
        int bigNum = (RingNum * RotationNum); // local, used for vertices Vector3 below
        vertices = new Vector3[bigNum];
        List<Vector3> rot = do_Rotation_Y(File2list.points);
        for (int i = 0; i < bigNum; i++)
        {
            vertices[i] = rot[i];
        }
        //Debug.Log("vertex 1 " + vertices[0] + "vertex count = " + vertices.Count);


        indexify(RingNum, RotationNum);
    }

    public List<Vector3> do_Rotation(List<Vector3> orig) // THIS IS ALL PRESTON'S WORK!!!!!!! GOOD JOB
    {
        float ANGLE = 2f * (float)Math.PI / RotationNum;

        List<Vector3> rot = new List<Vector3>();

        for (int i = 0; i < orig.Count; i++)
        {
            for (int t = 0; t < RotationNum; t++)
            {
                Vector3 ins = new Vector3(orig[i].x, orig[i].y * (float)Math.Sin(t * ANGLE), 5 + orig[i].y * (float)Math.Cos(t * ANGLE));
                rot.Add(ins);
            }
        }
        return rot;
    }

    public List<Vector3> do_Rotation_Y(List<Vector3> orig) //THIS IS ALSO ALL PRESTON'S WORK!!!!!!! GREAT JOB
    {
        float ANGLE = 2f * (float)Math.PI / RotationNum;

        List<Vector3> rot = new List<Vector3>();

        for (int i = 0; i < orig.Count; i++)
        {
            for (int t = 0; t < RotationNum; t++)
            {
                Vector3 ins = new Vector3(orig[i].x * (float)Math.Cos(t* ANGLE), orig[i].y, 5 + orig[i].x * (float)Math.Sin(t * ANGLE));
                rot.Add(ins);
            }
        }
        return rot;
    }

    void indexify(int rnum, int rlen) // first parameter is number of rotations (num points in ring), second parameter is ring length (num times rotated)
    {
        int triSize = (6 * rlen * (rnum - 1));
        triangles = new int[triSize];
        triangles2 = new int[triSize];
        int c1, c2, c3, index = 0, index2 = 0;
        for (int i = 0; i < (rnum - 1); i++)
        {
            c1 = i * rlen;
            c3 = ((i + 1) * rlen) - 1;
            for (int j = 0; j < 2 * rlen; j++)
            {
                if (j % 2 == 0)
                {
                    c3 = c3 + 1;
                    c2 = c1 + 1;
                }
                else
                {
                    c1 = c1 + 1;
                    c2 = c3 + 1;
                }
                if (j == rlen * 2 - 2)
                {
                    c2 = c2 - rlen;
                }
                if (j == rlen * 2 - 1)
                {
                    c1 = c1 - rlen;
                    c2 = c2 - rlen;
                }
                triangles[index++] = c1;
                triangles[index++] = c2;
                triangles[index++] = c3;
                triangles2[index2++] = c1;
                triangles2[index2++] = c3;
                triangles2[index2++] = c2;
            }
        }
        //for(int i = 0; i < 48; i++)
        //    Debug.Log(triangles[i]);
        //Debug.Log(triangles[triSize - 3]);
        //Debug.Log(triangles[triSize - 2]);
        //Debug.Log(triangles[triSize - 1]);
    }


    void UpdateMesh(Vector3[] vertices)
    {
        int x = vertices.Length;
        Vector2[] uvs = new Vector2[x];

        for(int i = 0; i < x; i++)
        {
            uvs[i] = new Vector2((float)i / x, (float)i / x);
        }

        msh.Clear();

        msh.vertices = vertices;
        msh.triangles = triangles;
        msh.uv = uvs;

        msh2.Clear();

        msh2.vertices = vertices;
        msh2.triangles = triangles2;
        msh2.uv = uvs;
    }

    double VolumeCalc(List<Vector3> top, List<Vector3> bot)
    {
	    double volume = 0f;
        double width = (double)(top[1][0]) - (double)(top[0][0]);
	    for (int i = 0; i < top.Count-1; i++)
	    {
            volume += ( (double)(Math.Pow(top[i][1], 2)) - (double)(Math.Pow(bot[i][1], 2)) ) * ((double)(top[i+1][0]) - (double)(top[i][0]));
	    }
	    volume *= (double)Math.PI;
        if (volume < 0.0)
            volume *= -1;
	    return volume;
    }

    double VolumeCalcY(List<Vector3> top, List<Vector3> bot)
    {
        double volume = 0f;
        double width = (double)(top[1].x) - (double)(top[0].x);

        for (int i = 0; i < top.Count-1; i++)
        {
            volume += (Math.Pow((double)(top[i].x), 2) - Math.Pow((double)(bot[i].x), 2))* ((double)(top[i+1].y) - (double)(top[i].y));
        }
        volume *= Math.PI;
        if (volume < 0.0)
            volume *= -1;
        return volume;
    }

    double SurfaceCalc(List<Vector3> curve)
    {
        double surface = 0f;
        double width = (double)(curve[1][0]) - (double)(curve[0][0]);
        for (int i = 0; i < curve.Count - 1; i++)
        {
            surface += (double)(Math.Abs(curve[i][1])) * Math.Sqrt(Math.Pow(width,2)+Math.Pow((double)(curve[i+1][1])-(double)(curve[i][1]),2));
        }
        surface *= 2 * Math.PI;
        return surface;
    }

    double SurfaceCalcY(List<Vector3> curve)
    {
        double surface = 0f;
        double width = (double)(curve[1].x) - (double)(curve[0].x);

        for (int i = 0; i < curve.Count - 1; i++)
        {
            surface += (double)(Math.Abs(curve[i].x)) * Math.Sqrt(Math.Pow(width, 2) + Math.Pow( (double)(curve[i+1][1]) - (double)(curve[i][1]), 2) );
        }
        surface *= 2 * Math.PI;
        return surface;
    }

    //Here are all preset function generators
    //all functions take in a start, end, and a number of points to generate, defaulting to 1000
    //the const generator takes in an additional value to generate a particular const function, defaulting to 1

    //all functions return null on an error such as end < start or start < 0 for sqrt function

    List<Vector3> Gen_Sin(float start, float end, int num_points = 1000)
    {
        if (start >= end)
            return null;

        List<Vector3> list = new List<Vector3>();

        float space = (end - start) / (float)(num_points);

        for (int t = 0; t < num_points; t++)
        {
            list.Add(new Vector3(start + (space * t), (float)(Math.Sin(start + (space * t))), 5));
        }

        return list;
    }

    List<Vector3> Gen_Cos(float start, float end, int num_points = 1000)
    {
        if (start >= end)
            return null;

        List<Vector3> list = new List<Vector3>();

        float space = (end - start) / (float)(num_points);

        for (int t = 0; t < num_points; t++)
        {
            list.Add(new Vector3(start + (space * t), (float)(Math.Cos(start + (space * t))), 5));
        }

        return list;
    }

    List<Vector3> Gen_Lin(float start, float end, int num_points = 1000)
    {
        if (start >= end)
            return null;

        List<Vector3> list = new List<Vector3>();

        float space = (end - start) / (float)(num_points);

        for (int t = 0; t < num_points; t++)
        {
            list.Add(new Vector3(start + (space * t), start + (space * t), 5));
        }

        return list;
    }

    List<Vector3> Gen_Quad(float start, float end, int num_points = 1000)
    {
        if (start >= end)
            return null;

        List<Vector3> list = new List<Vector3>();

        float space = (end - start) / (float)(num_points);

        for (int t = 0; t < num_points; t++)
        {
            list.Add(new Vector3(start + (space * t), (float)(Math.Pow(start + (space * t), 2)), 5));
        }

        return list;
    }

    List<Vector3> Gen_Cube(float start, float end, int num_points = 1000)
    {
        if (start >= end)
            return null;

        List<Vector3> list = new List<Vector3>();

        float space = (end - start) / (float)(num_points);

        for (int t = 0; t < num_points; t++)
        {
            list.Add(new Vector3(start + (space * t), (float)(Math.Pow(start + (space * t), 3)), 5));
        }

        return list;
    }

    List<Vector3> Gen_Sqrt(float start, float end, int num_points = 1000)
    {
        if (start >= end)
            return null;
        if (start < 0)
            return null;

        List<Vector3> list = new List<Vector3>();

        float space = (end - start) / (float)(num_points);

        for (int t = 0; t < num_points; t++)
        {
            list.Add(new Vector3(start + (space * t), (float)(Math.Sqrt(start + (space * t))), 5));
        }

        return list;
    }

    List<Vector3> Gen_Recip(float start, float end, int num_points = 1000)
    {
        if (start >= end)
            return null;
        //Debug.Log(start);
        //Debug.Log(end);
        if ((start == 0) || (end == 0) || (start * end < 0))
            return null;

        List<Vector3> list = new List<Vector3>();

        float space = (end - start) / (float)(num_points);

        for (int t = 0; t < num_points; t++)
        {
            list.Add(new Vector3(start + (space * t), (1f)/(start + (space * t)), 5));
        }

        return list;
    }

    List<Vector3> Gen_Exp(float start, float end, int num_points = 1000)
    {
        if (start >= end)
            return null;

        List<Vector3> list = new List<Vector3>();

        float space = (end - start) / (float)(num_points);

        for (int t = 0; t < num_points; t++)
        {
            list.Add(new Vector3(start + (space * t), (float)(Math.Exp(start + (space * t))), 5));
        }

        return list;
    }

    List<Vector3> Gen_Const(float start, float end, int num_points = 1000, float value = 1f)
    {
        if (start >= end)
            return null;

        List<Vector3> list = new List<Vector3>();

        float space = (end - start) / (float)(num_points);

        for (int t = 0; t < num_points; t++)
        {
            list.Add(new Vector3(start + (space * t), value, 5));
        }

        return list;
    }
}
