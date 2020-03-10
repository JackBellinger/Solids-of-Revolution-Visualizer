using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line_draw_brush: MonoBehaviour
{
    //Keeps track of a list of points that the attached object has been at every frame / every x frames
    //will use this to generate the list of points to input to the draw function for a user drawn line / function to rotate
    public static List<Vector3> drawn_points = new List<Vector3>();
    private Vector3 OldPos = new Vector3.Zero();

    public GameObject plane;

    // Start is called before the first frame update
    void Start()
    {
      OrthogonalInstantiate.make_prefab();
        drawn_points.Clear();

    }

    // Update is called once per frame
    void Update()
    {

        //if the brush has moved add the new position to the list
        if(Vector3.Distance(gameObject.transform.position, OldPos) > .25)
          drawn_points.Add(gameObject.transform.position;

        //if the brush moves away from the canvas, move it to the canvas
        plane.SetNormalAndPosition(this.transform.forward, this.transform.position);
        Debug.Log(plane.GetDistanceToPoint(someExternalTransform.position));
        Vecor3 OldPos = gameObject.transform.position;
        string str = "";
        foreach (Vector3 point in drawn_points)
            str += point;
        Debug.Log(str);
    }
}

public class OrthogonalInstantiate : MonoBehaviour
 {
     [SerializeField]
     private static float       m_minDistance;
     [SerializeField]
     private static float       m_maxDistance;
     [SerializeField]
     private static Plane  m_plane;
     private static float       m_distance;
     private static Vector3     m_position;
     private static bool is_instantiated = false;

     public static void make_prefab()
     {
         if(!is_instantiated)// && Input.GetMouseButtonDown(0))
         {
           GameObject go               = (GameObject)GameObject.Instantiate(m_plane);
         }else{
             if(m_position == null) m_position = new Vector3();

             m_distance = Random.Range(m_minDistance, m_maxDistance);

             //Left
             if (Random.Range(0, 2) == 0)
                 m_position.Set(-m_distance, 0f, m_distance);
             //Right
             else
                 m_position.Set(m_distance, 0f, m_distance);

             //Set position of new object
             GameObject go               = (GameObject)GameObject.Instantiate(m_plane);
             go.transform.position       = transform.position + transform.TransformVector(m_position);
             is_instantiated = true;
         }
     }
 }
