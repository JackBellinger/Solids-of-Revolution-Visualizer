using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ONLY FOCUS ON HAVING THE SLIDER OBJECTS CONSTRAINED PROPERLY IN THIS SCRIPT

public class SliderObjectScript : MonoBehaviour
{
    Vector3 localPos, initialPos;
    GameObject slider;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = this.transform.position;
        localPos = this.transform.position;
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ; // set it so that it does not move unless touched by user
    }

    // Update is called once per frame
    void Update()
    {
        localPos = this.transform.position;
        /*if (localPos == initialPos)
        {
            // do nothing. this will increase efficiency.
        }
        else
        {*/
            if (localPos.x <= initialPos.x)
                localPos.x = initialPos.x;
            if (localPos.x >= initialPos.x + (float)0.3f)
                localPos.x = initialPos.x + (float)0.3f;
            if (localPos.y != initialPos.y)
                localPos.y = initialPos.y;
            if (localPos.z != initialPos.z)
                localPos.z = initialPos.z;
        //}
    }

}
