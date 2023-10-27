using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class VentStates : MonoBehaviour
{

    public GameObject vent1;
    public GameObject vent2;
    public GameObject imposter;
    public GameObject floorPos;
    public Camera cam;
    [SerializeField] private double timer;
    [SerializeField] private int waitTime;
    public int counter;
    public bool bonVent;

    // Start is called before the first frame update
    void Start()
    {
        vent1.SetActive(true);
        vent2.SetActive(false);
        imposter.SetActive(false);
        bonVent = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!bonVent) return;
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && (cam.transform.position == (floorPos.transform.position + new Vector3(0, 4, 0))))
        {
            counter += 1;
            if (counter == 4) {
                vent1.SetActive(true);
                vent2.SetActive(false);
                imposter.SetActive(false);
                counter = -1;
                bonVent = false;
            }
        }
        if (timer > waitTime)
        {
            Debug.Log("Bongus Jumpscare");
        }
    }
        /*if (timer > randVal && !(imposter.active)) {
            vent1.active = false;
            vent2.active = true;
            imposter.active = true;
            randVal = Random.Range(24, 45);
            timer = 0;
        }
        if (timer > randVal && imposter.active) {
            Debug.Log("Bongus Jumpscare");
        }
    }*/

    public void BongVentActivate()
    {
        vent1.SetActive(false);
        vent2.SetActive(true);
        imposter.SetActive(true);
        waitTime = Random.Range(18,28);
        timer = 0;
        bonVent = true;
    }
    // ReSharper disable Unity.PerformanceAnalysis
    public bool BonReset()
    {
        if (counter == -1)
        {
            counter = 0;
            return true;
        }

        return false;
    }
}
