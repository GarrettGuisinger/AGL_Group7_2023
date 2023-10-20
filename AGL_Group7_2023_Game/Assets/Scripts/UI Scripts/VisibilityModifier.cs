using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UI_Scripts
{
    public class VisibilityModifier : MonoBehaviour
    {

        public VisibilityModifier()
        {
            
        }
        
        // Fade Command
        public void Fade(Graphic UI, float alpha, float duration)
        {
            UI.CrossFadeAlpha(alpha, duration, false);
        }
        
        // Enable & Disable Command
        public void Enable(Graphic UI, float wait, bool enable)
        {
            UI.enabled = enable;
        }

        // Fade With Delay Command
        public void fadeWithDelay(Graphic UI, float alpha, float duration, float delay)
        {
            StartCoroutine(fadeWithDelayCoroutine(UI, alpha, duration, delay));
        }
        
        // Coroutine for Fade With Delay Command
        IEnumerator fadeWithDelayCoroutine(Graphic UI, float alpha, float duration, float delay)
        {
            yield return new WaitForSeconds(delay);
            UI.CrossFadeAlpha(alpha, duration, false);
        }
        
        // Enable With Delay Command
        public void enableWithDelay(Graphic UI, float delay, bool enable)
        {
            StartCoroutine(enableWithDelayCoroutine(UI, delay, enable));
        }
        
        // Coroutine for Enable With Delay Command
        IEnumerator enableWithDelayCoroutine(Graphic UI, float delay, bool enable)
        {
            yield return new WaitForSeconds(delay);
            UI.enabled = enable;
        }
    }
}
