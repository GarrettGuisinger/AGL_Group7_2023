using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorStates : MonoBehaviour
{

    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;
    public double timer;
    public bool canClose = true;
    

    // Start is called before the first frame update
    void Start()
    {
        door1.active = false;
        door2.active = false;
        door3.active = false;
        door4.active = false;
    }

    // Update is called once per frame
    void Update()
    {
    
    if (Input.GetKeyDown(KeyCode.A) && canClose) {
        door1.active = !(door1.active);
        door2.active = !(door2.active);
    }
    else if (Input.GetKeyDown(KeyCode.D) && canClose) {
        door3.active = !(door3.active);
        door4.active = !(door4.active);
    }

    if (door1.active && canClose) {
        timer += Time.deltaTime;
    }

    if (door3.active && canClose) {
        timer += Time.deltaTime;
    }

    if (timer > 34 && canClose) {

        door1.active = false;
        door2.active = false;
        door3.active = false;
        door4.active = false;
        canClose = false;
        timer = 0;
    }

    if (!canClose) {
       timer += Time.deltaTime; 
       if (timer > 30) {
        canClose = true;
        timer = 0;
       }
    }
    else if (!door1.active && !door3.active) {
        if (timer > 0) {
        timer -= Time.deltaTime;
        }

    }
}
}