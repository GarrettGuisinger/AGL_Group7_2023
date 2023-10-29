using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public GameObject target4;
    public Camera cam;
    bool move = false;
    [SerializeField] [Range(0f, 10f)] float speed;
    Vector3 newPos = new Vector3();

    private bool IsVisible(Camera c, GameObject target)
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(c);
        var point = target.transform.position;

        foreach (var plane in planes)
        {
            if (plane.GetDistanceToPoint(point)< 0)
            {
                return false;
            }
        }
        return true;
    }

    private void Update ()
    {

        var target1Render = target1.GetComponent<Renderer>();
        var target2Render = target2.GetComponent<Renderer>();
        var target3Render = target3.GetComponent<Renderer>();
        var target4Render = target4.GetComponent<Renderer>();

        if (move)
        {
        transform.position = Vector3.MoveTowards(transform.position, newPos, Time.deltaTime * speed);

        if (transform.position == newPos) 
         {
            move = false;
         }  
        }

        else if (IsVisible(cam,target1) && Input.GetKeyDown(KeyCode.W) && (cam.transform.position != target1.transform.position + new Vector3(0,4,0)))
        {
           newPos = target1.transform.position + new Vector3(0,4,0);
           move = true;
        }
        else if (IsVisible(cam,target2) && Input.GetKeyDown(KeyCode.W) && (cam.transform.position == target1.transform.position + new Vector3(0,4,0)))
        {
           newPos = target2.transform.position + new Vector3(0,4,0);
           move = true;
        }
        else if (IsVisible(cam,target3) && Input.GetKeyDown(KeyCode.W) && (cam.transform.position == target1.transform.position + new Vector3(0,4,0)))
        {
           newPos = target3.transform.position + new Vector3(0,4,0);
           move = true;
        }
        else if (IsVisible(cam,target4) && Input.GetKeyDown(KeyCode.W) && (cam.transform.position == target1.transform.position + new Vector3(0,4,0)))
        {
           newPos = target4.transform.position + new Vector3(0,4,0);
           move = true;
        }
    }
}

