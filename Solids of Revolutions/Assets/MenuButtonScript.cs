using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MenuButtonScript : MonoBehaviour
{
    public String eq; // name of equation is declared publically in Unity interface by programmer
    BoundsButton a;
    BoundsButton b;
    GameObject adjuster;

    // Start is called before the first frame update
    // On start, find child TextMesh of Button object, and change its text to match publically set equation
    void Start()
    {
        TextMesh childMesh = this.GetComponentInChildren<TextMesh>();
        childMesh.text = eq;
    }

    public void OnMouseDown()
    {
        GameObject link = GameObject.Find("MeshRendererTestFive");
        MeshTestFive M = link.GetComponent<MeshTestFive>(); // we create a new MeshTestFive?
        adjuster = GameObject.Find("BoundsManager");
        a = adjuster.transform.GetChild(5).GetComponent<BoundsButton>();
        b = adjuster.transform.GetChild(7).GetComponent<BoundsButton>();
        int x = M.generate(eq, a.getLeft(), b.getRight());

        if(x == 1)
        {
            MeshTestFive.menu_string = "Invalid bounds";
        }
    }
}
