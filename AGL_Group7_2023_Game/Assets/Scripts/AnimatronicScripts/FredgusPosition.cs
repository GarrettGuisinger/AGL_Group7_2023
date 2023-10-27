using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FredgusPosition : MonoBehaviour
{
    public void setPosition(int pos)
    {
        if (pos == 0)
        {
            transform.position = new Vector3(30, 2, -4);
        }
        if (pos == 1)
        {
            transform.position = new Vector3(9, 2, -1.5f);
        }
    }
}
