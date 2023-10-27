using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReactorFunctions : MonoBehaviour
{
    AudioSource audio;
    public AudioClip alarm;
    public AudioClip click;
    public AudioClip powerup;
    public Camera cam;
    public MeshRenderer imposter;
    public double timer = 0;
    public int meltdownTimer = 0;
    public int codeInt = 0;
    public TMPro.TextMeshPro code;
    private string codeStr;
    private string userInput = "";
    private bool chikReactor;

    // Start is called before the first frame update
    void Start()
    {
        audio  = GetComponent<AudioSource>();
        chikReactor = false;
        imposter.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (chikReactor == false) return;
        timer += Time.deltaTime;

        if (timer > meltdownTimer) {
            Debug.Log("Reactor Explosion/GameOver");
            SceneManager.LoadScene("LoseScene");
        }

        if (cam.transform.position == new Vector3((float)1.4, (float)5.3, (float)22)) {
            
            if (Input.GetKeyDown(KeyCode.Alpha0)) {
                userInput += "0";
                audio.PlayOneShot(click, 0.2f);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1)) {
                userInput += "1";
                audio.PlayOneShot(click, 0.2f);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2)) {
                userInput += "2";
                audio.PlayOneShot(click, 0.2f);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3)) {
                userInput += "3";
                audio.PlayOneShot(click, 0.2f);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4)) {
                userInput += "4";
                audio.PlayOneShot(click, 0.2f);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5)) {
                userInput += "5";
                audio.PlayOneShot(click, 0.2f);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6)) {
                userInput += "6";
                audio.PlayOneShot(click, 0.2f);
            }
            else  if (Input.GetKeyDown(KeyCode.Alpha7)) {
                userInput += "7";
                audio.PlayOneShot(click, 0.2f);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8)) {
                userInput += "8";
                audio.PlayOneShot(click, 0.2f);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha9)) {
                userInput += "9";
                audio.PlayOneShot(click, 0.2f);
            }



            if ((userInput.Length == 4) && (userInput == codeStr)) {
               chikReactor = false; 
               code.text = "Safe";
               meltdownTimer = -1;
               timer = 0;
               audio.PlayOneShot(powerup, 0.3f);
            }
            else if (userInput.Length == 4 && userInput != codeStr) {
                userInput = "";
            }
        }
    }
    public void Meltdown()
    {
        audio.PlayOneShot(alarm); 
        codeInt = Random.Range(1000, 9999);
        codeStr = codeInt.ToString();
        code.text = $"Critical:\n{codeStr}";
        timer = 0;
        meltdownTimer = 30;
        chikReactor = true;
    }

    public bool ResetChik()
    {
        if (meltdownTimer == -1)
        {
            meltdownTimer = 0;
            return true;
        }

        return false;
    }
}
