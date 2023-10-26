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

    public bool doorClosed;
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
                StartCoroutine(ChikusMovement());
                break;
            case >= 540 when phase == 3:
                phase++;
                SceneManager.LoadScene("WinScene");
                break;
        }
    }

    private bool SceneCheck(string sceneName)
    {
        return SceneManager.GetActiveScene().name.Equals(sceneName);
    }
    
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
                > 3 => Random.Range(15, 25),
                _ => Random.Range(5, 10)
            };
            yield return new WaitForSeconds(waitTime);
            fredPosition++;
            if (fredPosition == 4)
            {
                // Check if door is closed
            }
            if (fredPosition == 5)
            {
                if (doorClosed)
                {
                    fredPosition = 0;
                }
                else
                {
                    //SceneManager.LoadScene("LoseScene");
                }
                // Kills you
            }
        }
    }

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
         * 8 == Electrical Vent 2
         * 9 == Electrical Vent 3
         * ----------------------
         * 10 == Medbay Vent 1
         * 11 == Medbay Vent 2
         * 12 == Medbay Vent 3
         * ------------------------
         * 13 == In Office
         */ 
        bonPosition = 0;
        while (SceneCheck("Night1Scene"))
        {
            float waitTime = bonPosition switch
            {
                > 7 => Random.Range(10, 20),
                _ => Random.Range(5, 10)
            };
            yield return new WaitForSeconds(waitTime);
            if (bonPosition == 0)
            {
                float random = Random.Range(0,1);
                var randomInt = Math.Floor(random);
                if (randomInt == 0){bonPosition = 1;}
                else if (randomInt == 1){bonPosition = 3;}
            }
            else if(bonPosition == 2)
            {
                bonPosition = 7;
            }
            else if (bonPosition == 6)
            {
                bonPosition = 10;
            }
            else
            {
                bonPosition++;
                if (bonPosition == 13)
                {
                    // Kills you
                    //SceneManager.LoadScene("LoseScene");
                }
            }
        }
    }

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
            chikPosition++;
            if (chikPosition == 10)
            {
                // Activates Reactor
            }
        }
    }
}
