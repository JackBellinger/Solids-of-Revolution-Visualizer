using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Generate : MonoBehaviour
{
    public GameObject axis;
    void Start()
    {
        Instantiate(axis, new Vector3(0, 0, 5), Quaternion.Euler(0, 0, 0));
        Instantiate(axis, new Vector3(0, 0, 5), Quaternion.Euler(0, 90, 0));
        Instantiate(axis, new Vector3(0, 0, 5), Quaternion.Euler(90, 0, 0));

        File2list.listify("const", 0, 0, 5, 5);
        File2list.extend();

        Rotator.do_Rotation(File2list.points);
        Debug.Log(File2list.points.Count);
        Debug.Log(File2list.meshpoints.Count);
        Debug.Log(File2list.meshnormals.Count);
        Debug.Log(File2list.meshpoints[7999]);
	
    }
    void Update()
    {
        
    }
}
