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
        door1.SetActive(false);
        door2.SetActive(false);
        door3.SetActive(false);
        door4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && canClose) {
            door1.SetActive(!door1.activeSelf);
            door2.SetActive(!door2.activeSelf);
        }
        else if (Input.GetKeyDown(KeyCode.D) && canClose) {
            door3.SetActive(!door3.activeSelf);
            door4.SetActive(!door4.activeSelf);
        }

        if (door1.activeSelf && canClose) {
            timer += Time.deltaTime;
        }

        if (door3.activeSelf && canClose) {
            timer += Time.deltaTime;
        }

        if (timer > 34 && canClose) {

            door1.SetActive(false);
            door2.SetActive(false);
            door3.SetActive(false);
            door4.SetActive(false);
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
        else if (!door1.activeSelf && !door3.activeSelf) {
            if (timer > 0) {
                timer -= Time.deltaTime;
            }
        }
    }
    public bool door1Closed()
    {
        return door3.activeSelf;
    }
}