using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentStates : MonoBehaviour
{

    public GameObject vent1;
    public GameObject vent2;
    public GameObject imposter;
    public GameObject floorPos;
    public Camera cam;
    public double timer;
    public int randVal = 0;
    public bool state2 = false; 
    public int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        vent2.active = false;
        imposter.active = false;
        randVal = Random.Range(15, 35);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && (cam.transform.position == (floorPos.transform.position + new Vector3(0, 4, 0)))) {
            counter += 1;
            if (counter == 4) {
                vent1.active = true;
                vent2.active = false;
                imposter.active = false;
                state2 = false;
                counter = 0;
            }
        }

        if (timer > randVal && !state2) {
            vent1.active = false;
            vent2.active = true;
            imposter.active = true;
            randVal = Random.Range(24, 45);
            state2 = true;
            timer = 0;
        }
        if (timer > randVal && state2) {
            Debug.Log("Bongus Jumpscare");
        }
    }
}
