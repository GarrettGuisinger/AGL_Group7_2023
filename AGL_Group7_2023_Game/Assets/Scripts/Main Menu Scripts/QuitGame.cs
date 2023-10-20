using UnityEngine;

namespace Main_Menu_Scripts
{
    public class QuitGame : MonoBehaviour
    {
        public void Quit()
        {
            Application.Quit();
            Debug.Log("Closing Game");
        }
    }
}