using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsButton : MonoBehaviour
{
    public string bound;
    BoundsButton a;
    BoundsButton b;
    GameObject adjuster;
    TextMesh leftBound, rightBound;
    float[] boundValues = { 0f, 0.25f, 0.5f, 0.75f, 0.79f, 1f, 1.25f, 1.5f, 1.57f, 1.75f, 2f, 2.25f, 2.35f, 2.5f, 2.75f, 3f, 3.14f, 3.25f, 3.5f, 3.75f, 3.93f, 4f, 4.25f, 4.5f, 4.71f, 4.75f, 5f, 5.5f, 6.28f};
    public int trackerleft, trackerright;
    // Start is called before the first frame update
    void Start()
    {
        adjuster = GameObject.Find("BoundsManager");
        leftBound = adjuster.transform.GetChild(1).GetComponent<TextMesh>();
        rightBound = adjuster.transform.GetChild(2).GetComponent<TextMesh>();
        a = adjuster.transform.GetChild(5).GetComponent<BoundsButton>();
        b = adjuster.transform.GetChild(7).GetComponent<BoundsButton>();
        a.trackerleft = 0;
        b.trackerright = 5;
    }

    public float getLeft() //left
    {
        return boundValues[trackerleft];
    }

    public float getRight()
    {
        return boundValues[trackerright];
    }

    public void OnMouseDown()
    {
        if (bound == "left") // if left boundary
        {
            if (this.GetComponentInChildren<TextMesh>().text == "-") // if a - button
            {
                if (a.trackerleft == 0) // if left bound at minimum
                {
                    leftBound.text = "" + boundValues[a.trackerleft];
                }
                else
                {
                    a.trackerleft--;
                    leftBound.text = "" + boundValues[a.trackerleft];
                }
            }
            if (this.GetComponentInChildren<TextMesh>().text == "+")
            {
                if (a.trackerleft == boundValues.Length - 1) // if left bound at maximum
                {
                    leftBound.text = "" + boundValues[a.trackerleft];
                }
                else
                {
                    a.trackerleft++;
                    leftBound.text = "" + boundValues[a.trackerleft];
                }
            }
        }
        if (bound == "right") // if left boundary
        {
            if (this.GetComponentInChildren<TextMesh>().text == "-") // if a - button
            {
                if (b.trackerright == 0) // if left bound at minimum
                {
                    rightBound.text = "" + boundValues[b.trackerright];
                }
                else
                {
                    b.trackerright--;
                    rightBound.text = "" + boundValues[b.trackerright];
                }
            }
            if (this.GetComponentInChildren<TextMesh>().text == "+")
            {
                if (b.trackerright == boundValues.Length - 1) // if left bound at maximum
                {
                    rightBound.text = "" + boundValues[b.trackerright];
                }
                else
                {
                    b.trackerright++;
                    rightBound.text = "" + boundValues[b.trackerright];
                }
            }
        }
        /*TextMesh displayInfo = menu.GetComponentInChildren<TextMesh>();
        displayInfo.text = "Press the M/N Key to\nGenerate the Mesh,\nB for drawing"; // CHANGE LATER
        GameObject link = GameObject.Find("MeshRendererTestFive");
        MeshTestFive M = link.GetComponent<MeshTestFive>(); // we create a new MeshTestFive?
        M.generate(eq);*/
    }
}
