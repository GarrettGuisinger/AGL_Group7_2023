using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactorFunctions : MonoBehaviour
{
    AudioSource audio;
    public AudioClip alarm;
    public AudioClip clock;
    public AudioClip powerup;
    public Camera cam;
    public MeshRenderer imposter;
    public double timer = 0;
    public int randVal = 0;
    public int codeInt = 0;
    public TMPro.TextMeshPro code;
    private bool state2 = false;
    private string codeStr;
    private string userInput = "";

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        randVal = Random.Range(35,50);
        imposter.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;

        if (timer > randVal && !state2) {
            imposter.enabled = true;
            audio.PlayOneShot(alarm);  
            codeInt = Random.Range(1000, 9999);
            codeStr = codeInt.ToString();
            code.text = $"Critical:\n{codeStr}";
            timer = 0;
            randVal = 30;
            state2 = true;
        }

        if (timer > 5 && state2) {
            imposter.enabled = false;
        }

        if (timer > randVal && state2) {
            Debug.Log("Reactor Explosion/GameOver");
        }

        if (cam.transform.position == new Vector3((float)1.4, (float)5.3, (float)22) && state2) {
            
            if (Input.GetKeyDown(KeyCode.Alpha0)) {
                userInput += "0";
                audio.PlayOneShot(clock, 0.2f);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1)) {
                userInput += "1";
                audio.PlayOneShot(clock, 0.2f);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2)) {
                userInput += "2";
                audio.PlayOneShot(clock, 0.2f);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3)) {
                userInput += "3";
                audio.PlayOneShot(clock, 0.2f);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4)) {
                userInput += "4";
                audio.PlayOneShot(clock, 0.2f);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5)) {
                userInput += "5";
                audio.PlayOneShot(clock, 0.2f);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6)) {
                userInput += "6";
                audio.PlayOneShot(clock, 0.2f);
            }
            else  if (Input.GetKeyDown(KeyCode.Alpha7)) {
                userInput += "7";
                audio.PlayOneShot(clock, 0.2f);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8)) {
                userInput += "8";
                audio.PlayOneShot(clock, 0.2f);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha9)) {
                userInput += "9";
                audio.PlayOneShot(clock, 0.2f);
            }

            if ((userInput.Length == 4) && (userInput == codeStr)) {
               state2 = false; 
               code.text = "Safe";
               randVal = Random.Range(35,50);
               audio.PlayOneShot(powerup, 0.3f);
               timer = 0;
            }
            else if (userInput.Length == 4 && userInput != codeStr) {
                userInput = "";
            }
        }
        


    }
}
