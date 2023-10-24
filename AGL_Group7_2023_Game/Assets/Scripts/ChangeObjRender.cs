using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObjRender : MonoBehaviour
{
    public Camera cam;
    public GameObject[] ventParts;
    public Clock clock;
    bool state1 = true;
    bool state2 = false;
    double time1 = 10;
    double time2 = 20;

    // Start is called before the first frame update
    void Start()
    {
        ventParts[3].active = false;
        ventParts[4].active = false;
        ventParts[5].active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(time2 < clock.timer && (time2 + 1) > clock.timer) {
        //if (state1) {
            //if(cam.transform.position == new Vector3(0, 5, 15)) {
                ventParts[0].active = true;
                ventParts[1].active = true;
                ventParts[2].active = true;
                ventParts[3].active = false;
                ventParts[4].active = false;
                ventParts[5].active = false;
                state1 = false;
                state2 = true;
        //} 
        }
        if(time1 < clock.timer && (time1 + 1) > clock.timer) {
        //else if (state2) {
            //if(cam.transform.position == new Vector3(-5, 5, -17)) {
                ventParts[0].active = false;
                ventParts[1].active = false;
                ventParts[2].active = false;
                ventParts[3].active = true;
                ventParts[4].active = true;
                ventParts[5].active = true;
                state1 = true;
                state2 = false;
        //} 
        }


        
    }
}
