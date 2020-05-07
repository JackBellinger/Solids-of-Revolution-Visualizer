using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Generate : MonoBehaviour
{
    public GameObject axis, canvas;
    void Start()
    {
        Instantiate(axis, new Vector3(0, 0, 5), Quaternion.Euler(0, 0, 0));
        Instantiate(axis, new Vector3(0, 0, 5), Quaternion.Euler(0, 90, 0));
        Instantiate(axis, new Vector3(0, 0, 5), Quaternion.Euler(90, 0, 0));

        //canvas = Find("NewCanvas");
        //Instantiate(canvas, new Vector3(2.5f, 2.5f, 5.025f), Quaternion.identity);
    }

}
