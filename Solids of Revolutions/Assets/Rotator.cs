using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Rotator : MonoBehaviour
{
    public static List<Vector3> do_Rotation(List<Vector3> orig)
    {
	const int NUM_ROT = 4;
	const float ANGLE = 2f * (float)Math.PI / NUM_ROT;
	
	List<Vector3> rot = new List<Vector3>();
	
	for (int i=0; i < orig.Count; i++)
	{
		for (int t=0; t < NUM_ROT; t++)
		{
			Vector3 ins = new Vector3(orig[i].x, orig[i].y * (float)Math.Sin(t * ANGLE), orig[i].y * (float)Math.Cos(t * ANGLE));
			rot.Add(ins);
		}
	}
			
	Debug.Log(rot.Count);
	return rot;
    }
}
