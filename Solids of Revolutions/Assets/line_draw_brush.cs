using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line_draw_brush: MonoBehaviour
{
    //Keeps track of a list of points that the attached object has been at every frame / every x frames
    //will use this to generate the list of points to input to the draw function for a user drawn line / function to rotate
    public static List<Vector3> drawn_points = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        drawn_points.Clear();

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += Vector3.up * 10.0f;
        drawn_points.Add(gameObject.transform.position);
        string str = "";
        foreach (Vector3 point in drawn_points)
            str += point;
        Debug.Log(str);
    }
}
