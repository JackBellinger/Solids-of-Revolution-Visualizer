using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class line_draw_brush: MonoBehaviour
{
  //Keeps track of a list of points that the attached object has been at every frame / every x frames
  //will use this to generate the list of points to input to the draw function for a user drawn line / function to rotate
  public List<Vector3> drawn_points = new List<Vector3>();
  private Vector3 OldPos = Vector3.zero;
  public GameObject canvasPrefab;
  public GameObject canvas;
  public bool line_done = false;
  public float speed = 1.0f;
  public float canvas_bounds = 5f;
  // Start is called before the first frame update
  void Start()
  {
    canvas = Instantiate(canvasPrefab, new Vector3(0, 0, 5), Quaternion.Euler(-90, 0, 0));
    //rotate_towards(plane);
    drawn_points.Clear();

  }

  // Update is called once per frame
  void Update()
  {
    string str = "";
    Vector3 brush_pos = gameObject.transform.position;
    brush_pos.z = 5;
    if(brush_pos.x <= -1*canvas_bounds)
      brush_pos.x = -1*canvas_bounds;
    if(brush_pos.x >= canvas_bounds)
      brush_pos.x = canvas_bounds;

    if(brush_pos.y <= -1*canvas_bounds)
      brush_pos.y = -1*canvas_bounds;
    if(brush_pos.y >= canvas_bounds)
      brush_pos.y = canvas_bounds;
    gameObject.transform.position = brush_pos;

    if(!line_done)
    {
      //if the brush has moved add the new position to the list
      if(Vector3.Distance(gameObject.transform.position, OldPos) > .001)
      {
        Vector3 point =gameObject.transform.position;
        point.z = 5;
        str += point;
        // Debug.Log("drawn points[" + drawn_points.Count + "]: " + str);
        drawn_points.Add(point);
      }
      if(drawn_points.Count == 1000 || Input.GetKeyDown("b"))
      {
        line_done = true;
        Destroy(canvas);
        //File2list.points = drawn_points;

      }

      OldPos = gameObject.transform.position;

      // for(int i = 0; i < drawn_points.Count; i++)
      // {
      //   Vector3 point = drawn_points[i];
      //   point.z = 0;
      //   str += point;
      //   drawn_points[i] = point;
      // }


    }else{
      // Debug.Log("Finished drawn points[" + drawn_points.Count + "]: " + str);
      //Destroy(canvas);
            //List<Vector3> rotated = MeshTestFive.do_Rotation(drawn_points);
    }
  }

  public void rotate_towards(GameObject target)
  {
    Camera maincam = GameObject.Find("Main Camera").GetComponent<Camera>();
    Vector3 relativePos = target.transform.position - maincam.transform.position;
    //Quaternion rotation = Quaternion.LookRotation(relativePos);
    target.transform.Rotate(relativePos.x, relativePos.y, relativePos.z, Space.World);
    // Debug.Log("Relative pos: " + relativePos);
  }

  public void move(string dir)
  {
    if(dir== "up")
      transform.Translate(new Vector3(0, 1f * speed * Time.deltaTime, 0));
    if(dir== "down")
      transform.Translate(new Vector3(0, -1f * speed * Time.deltaTime, 0));
    if(dir== "right")
      transform.Translate(new Vector3(1f * speed * Time.deltaTime, 0, 0));
    if(dir== "left")
      transform.Translate(new Vector3(-1f * speed * Time.deltaTime, 0, 0));
  }

}
