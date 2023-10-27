
using System.Collections;
using System.Collections.Generic;
using UI_Scripts;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    private VisibilityModifier mod;
    public UnityEngine.UI.Image image;
    public UnityEngine.UI.Button button;
    private UnityEngine.UI.Image bImage;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(winTransition());
    }

    // ReSharper disable Unity.PerformanceAnalysis
    IEnumerator winTransition()
    {
        mod = gameObject.AddComponent<VisibilityModifier>();
        bImage = button.GetComponent<UnityEngine.UI.Image>();
        mod.Enable(image, false);
        mod.Enable(bImage, false);
        mod.Fade(image, 0, 0.1f);
        mod.Fade(bImage, 0, 0.1f);
        yield return new WaitForSeconds(0.3f);
        Cursor.lockState = CursorLockMode.None;
        mod.Enable(image, true);
        mod.Enable(bImage, true);
        mod.Fade(image, 1, 2);
        mod.Fade(bImage, 1, 2);
    }

    // Update is called once per frame
    void Exit()
    {
        
    }
}
