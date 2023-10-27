using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminMarkers : MonoBehaviour
{
    [SerializeField] private Vector3[] FredgusMarks;
    [SerializeField] private Vector3[] BongusMarks;
    [SerializeField] private Vector3[] ChikusMarks;
    public GameObject FredMark;
    public GameObject BonMark;
    public GameObject ChikMark;
    
    // Start is called before the first frame update

    void Start()
    {
        transform.position = new Vector3(16.0440006f, 6.875f, -22.4060001f);
        FredMark.GetComponent<Transform>().localPosition = FredgusMarks[0];
        BonMark.GetComponent<Transform>().localPosition = BongusMarks[0];
        ChikMark.GetComponent<Transform>().localPosition = ChikusMarks[0];
    }

    public void updateFredgus(int position)
    {
        FredMark.transform.localPosition = FredgusMarks[position];
        if (position == 5)
        {
            return;
        }
    }
    public void updateBongus(int position)
    {
        if (position == 7)
        {
            BonMark.transform.localPosition = BongusMarks[2];
        }
        else if (position == 8)
        {
            BonMark.transform.localPosition = BongusMarks[6];
        }
        else if (position == 9)
        {
            BonMark.transform.localPosition = BongusMarks[7];
        }
        else
        {
            BonMark.transform.localPosition = BongusMarks[position]; 
        }
        
    }
    public void updateChikus(int position)
    {
        ChikMark.transform.localPosition = ChikusMarks[position];
    }
}
