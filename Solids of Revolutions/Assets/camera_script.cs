using UnityEngine;
using System;

public class camera_script: MonoBehaviour
{

  public float speed = 2.0f;
  void Update()
  {
    float ScrollWheelChange = Math.Sign(Input.GetAxis("Mouse ScrollWheel"));

    GameObject link = GameObject.Find("MeshRendererTestFive");
    MeshTestFive M = link.GetComponent<MeshTestFive>(); // we create a new MeshTestFive?
    if(!M.started_drawing)
    {
      if(Input.GetKey(KeyCode.RightArrow)  || Input.GetKey(KeyCode.D))
        transform.Translate(Vector3.right * speed * Time.deltaTime);

      if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
          transform.Translate(Vector3.left * speed * Time.deltaTime);

      if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
          transform.Translate(Vector3.down * speed * Time.deltaTime);

      if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
          transform.Translate(Vector3.up * speed * Time.deltaTime);

      if(Input.GetKey(KeyCode.Minus))
          transform.Translate(Vector3.back * speed * Time.deltaTime);

      if(Input.GetKey(KeyCode.Equals))
          transform.Translate(Vector3.forward * speed * Time.deltaTime);

      if(ScrollWheelChange != 0)
      {
        //Debug.Log(ScrollWheelChange);
        transform.Translate(Vector3.forward * ScrollWheelChange * 10 * speed * Time.deltaTime);
      }

      transform.LookAt(new Vector3(0, 0, 5));
    }
  }
}
