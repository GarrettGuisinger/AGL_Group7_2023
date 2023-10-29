using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public static MeshRenderer bongus;

    private Animation anim = bongus.GetComponent<Animation>();
    // Start is called before the first frame update
    void Start()
    {
        animationTest();
    }

    // Update is called once per frame

    IEnumerator animationTest()
    {
        anim.Play();
        yield return new WaitUntil(() => !anim.isPlaying);
    }
}
