using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameEvents : MonoBehaviour
{

    [SerializeField] private double timer = 0;

    [SerializeField] private double timerAdd = 1;

    [SerializeField] private int phase = 0;

    public int fredPosition;

    public int bonPosition;

    public int chikPosition;

    public int foxPosition;

    public bool doorClosed;

    public GameObject doors;

    public GameObject fredgus;
    public GameObject bongus;
    public GameObject chikus;
    public MeshRenderer chikusModel;
    public GameObject foxgus;
    public GameObject admin;
    
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (!SceneCheck("Night1Scene")) return;
        timer += Time.deltaTime * timerAdd;
        switch (timer)
        {
            case >= 30 when phase == 0:
                phase++; 
                StartCoroutine(FredgusMovement());
                break;
            case >= 120 when phase == 1:
                phase++;
                StartCoroutine(BongusMovement());
                break;
            case >= 210 when phase == 2:
                phase++;
                StartCoroutine(FoxgusMovement());
                break;
            case >= 300 when phase == 3:
                phase++;
                StartCoroutine(ChikusMovement());
                break;
            case >= 540 when phase == 4:
                phase++;
                SceneManager.LoadScene("WinScene");
                break;
        }
    }

    private bool SceneCheck(string sceneName)
    {
        return SceneManager.GetActiveScene().name.Equals(sceneName);
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    IEnumerator FredgusMovement()
    {
        /*
         * 0 == Storage Area
         * 1 == Admin Hallway
         * 2 == Cafeteria
         * 3 == Upper Engine
         * 4 == Security Hallway
         * 5 == Security Room
         */
        fredPosition = 0;
        while (SceneCheck("Night1Scene"))
        {
            float waitTime = fredPosition switch
            {
                > 2 => Random.Range(15, 25),
                _ => Random.Range(10, 15)
            };
            yield return new WaitForSeconds(waitTime);
            if (fredPosition == 3)
            {
                fredgus.GetComponent<FredgusPosition>().setPosition(1);
            }
            if (fredPosition == 4)
            {
                if (Door1Closed())
                {
                    fredgus.GetComponent<FredgusPosition>().setPosition(0);
                    fredPosition = -1;
                }
                else
                {
                    SceneManager.LoadScene("LoseScene");
                }
            }
            fredPosition++;
            admin.GetComponent<AdminMarkers>().updateFredgus(fredPosition);
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    IEnumerator BongusMovement()
    {
        /*
         * 0 == Storage Area
         * ---------------------
         * 1 == Electrical Hallway
         * 2 == Electrical
         * --------------------
         * 3 == Admin Hallway
         * 4 == Cafeteria
         * 5 == Medbay Hallway
         * 6 == Medbay
         * ----------------------
         * 7 == Electrical Vent 1
         * ----------------------
         * 8 == Medbay Vent 1
         * ------------------------
         * 9 == In Office
         */ 
        bonPosition = 0;
        while (SceneCheck("Night1Scene") && bonPosition != 9)
        {
            float waitTime = bonPosition switch
            {
                > 7 => Random.Range(10, 21),
                _ => Random.Range(5, 11)
            };
            yield return new WaitForSeconds(waitTime);
            if (bonPosition == 0)
            {
                float random = Random.Range(0,2);
                var randomInt = Math.Floor(random);
                if (randomInt == 0){bonPosition = 1;}
                else {bonPosition = 3;}
            }
            else if(bonPosition == 2)
            {
                bonPosition = 7;
            }
            else if (bonPosition == 6)
            {
                bonPosition = 8;
            }
            else
            {
                bonPosition++;
                admin.GetComponent<AdminMarkers>().updateBongus(bonPosition);
                if (bonPosition == 9)
                {
                    bongus.GetComponent<VentStates>().BongVentActivate();
                    yield return new WaitUntil(()=> bongus.GetComponent<VentStates>().BonReset());
                    bonPosition = 0;
                    admin.GetComponent<AdminMarkers>().updateBongus(bonPosition);
                }
            }
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    IEnumerator ChikusMovement()
    {
        /*
           * 0 == Storage Area
           * ---------------------
           * 1 == Electrical Hallway
           * 2 == Lower Engine
           * 3 == Lower Engine Vent
           * --------------------
           * 4 == Admin Hallway
           * 5 == Cafeteria
           * 6 == Medbay Hallway
           * 7 == Upper Engine
           * 8 == Upper Engine Vent
           * ---------------------
           * 9 == In Reactor
           * 10 == Sabotage 
           */
        chikPosition = 0;
        while (SceneCheck("Night1Scene"))
        {
            float waitTime = Random.Range(10, 20);
            yield return new WaitForSeconds(waitTime);
            if (chikPosition == 0)
            {
                float newRand = Random.Range(1, 3);
                if (newRand == 1)
                {
                    chikPosition = 1;
                }
                else
                {
                    chikPosition = 4;
                }
            }
            else if (chikPosition is 3 or 8)
            {
                chikPosition = 9;
                chikusModel.enabled = true;
            }
            else
            {
                chikPosition++;
            }
            if (chikPosition == 10)
            {
                chikusModel.enabled = false;
                chikPosition = 0;
                admin.GetComponent<AdminMarkers>().updateChikus(chikPosition);
                chikus.GetComponent<ReactorFunctions>().Meltdown();
                yield return new WaitUntil(() => chikus.GetComponent<ReactorFunctions>().ResetChik());
                // Activates Reactor
            }
            admin.GetComponent<AdminMarkers>().updateChikus(chikPosition);
        }
    }

    IEnumerator FoxgusMovement()
    {
        /*
         * 0 == Storage Area
         * 1 == Electrical Hallway
         * 2 == Lower Engine Entrance
         * 3 == Lower Engine
         * 4 == Security Hallway
         * 5 == Security Room
         */
        foxPosition = 0;
        while (SceneCheck("Night1Scene"))
        {
            float waitTime = foxPosition switch
            {
                > 2 => Random.Range(15, 25),
                _ => Random.Range(10, 15)
            };
            yield return new WaitForSeconds(waitTime);
            if (foxPosition == 3)
            {
                foxgus.GetComponent<FoxgusPosition>().setPosition(1);
            }
            if (foxPosition == 4)
            {
                if (Door2Closed())
                {
                    foxgus.GetComponent<FoxgusPosition>().setPosition(0);
                    foxPosition = -1;
                }
                else
                {
                    SceneManager.LoadScene("LoseScene");
                }
            }
            foxPosition++;
            admin.GetComponent<AdminMarkers>().updateFoxgus(foxPosition);
        }
    }
    
    bool Door1Closed()
    {
        return doors.GetComponent<DoorStates>().door1Closed();
    }

    bool Door2Closed()
    {
        return doors.GetComponent<DoorStates>().door2Closed();
    }
}
