using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxgusPosition : MonoBehaviour
{
    public void setPosition(int pos)
    {
        if (pos == 0)
        {
            transform.position = new Vector3(-16.8999996f,1.29999995f,-2.70000005f);
        }
        if (pos == 1)
        {
            transform.position = new Vector3(-8.19999981f,1.29999995f,-2.29999995f);
        }
    }
}
