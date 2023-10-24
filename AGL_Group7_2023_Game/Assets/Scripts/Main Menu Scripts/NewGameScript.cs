using System.Collections;
using TMPro;
using UI_Scripts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class NewGameScript : MonoBehaviour
{
    private Canvas mainMenu;
    private Image mainMenuBackground;
    private TextMeshProUGUI newGameButton;
    private TextMeshProUGUI settingsButton;
    private TextMeshProUGUI quitButton;
    private RawImage videoRaw;
    private VideoPlayer videoPlayer;
    private Image crewmateScreen;
    private Image surviveScreen;
    private VisibilityModifier mod;
    [SerializeField] private VideoClip shush;
    [SerializeField] private VideoClip glitch;
    private VideoScript videoPlay;
    private SceneChanger scene;
    
    void Start()
    {
        mainMenu = GameObject.Find("MainMenu").GetComponent<Canvas>();
        mainMenuBackground = GameObject.Find("MainMenuBackground").GetComponent<Image>();
        newGameButton = GameObject.Find("New Game (Text)").GetComponent<TextMeshProUGUI>();
        settingsButton = GameObject.Find("Settings (Text)").GetComponent<TextMeshProUGUI>();
        quitButton = GameObject.Find("Quit (Text)").GetComponent<TextMeshProUGUI>();
        videoRaw = GameObject.Find("VideoRaw").GetComponent<RawImage>();
        videoPlayer = GameObject.Find("Video Player").GetComponent<VideoPlayer>();
        crewmateScreen = GameObject.Find("CrewmateScreen").GetComponent<Image>();
        surviveScreen = GameObject.Find("SurviveTransition").GetComponent<Image>();
        mod = gameObject.AddComponent<VisibilityModifier>();
        videoPlay = videoPlayer.AddComponent<VideoScript>();
        scene = gameObject.AddComponent<SceneChanger>();
    }

    public void startNewGame()
    {
        StartCoroutine(UITransition());
        //VisibilityModifier is the class used to change the visibility of objects
        // VideoScript is the class used to utilize the VideoPlayer in our script
        // This section Fades out the entire menu screen
        /*mod.Fade(crewmateScreen.GetComponent<Image>(), 0, 0.1f);
        mod.Fade(mainMenuBackground.GetComponent<Image>(), 0, 1);
        mod.Fade(newGameButton.GetComponent<TextMeshProUGUI>(), 0, 1);
        mod.Fade(settingsButton.GetComponent<TextMeshProUGUI>(), 0, 1);
        mod.Fade(quitButton.GetComponent<TextMeshProUGUI>(), 0, 1);
        // This disables the mainMenuBackground, if that actually does anything
        mod.enableWithDelay(mainMenuBackground.GetComponent<Image>(), 2, false);
        // This sets up and plays the shush clip
        videoPlay.clipWithDelay(videoPlayer.GetComponent<VideoPlayer>(), shush, 2);
        mod.enableWithDelay(videoRaw.GetComponent<RawImage>(), 3, true);
        videoPlay.playWithDelay(videoPlayer.GetComponent<VideoPlayer>(), 2.5f);
        videoPlay.stopWithDelay(videoPlayer.GetComponent<VideoPlayer>(), 6);
        // This disables the video clip
        mod.enableWithDelay(videoRaw.GetComponent<RawImage>(), 6, false);
        // This makes the crewmate screen fade in
        mod.enableWithDelay(crewmateScreen.GetComponent<Image>(), 6, true);
        mod.fadeWithDelay(crewmateScreen.GetComponent<Image>(),  1, 2, 6.2f);
        // This sets up the glitch video 
        videoPlay.loop(videoPlayer.GetComponent<VideoPlayer>(), true, 7.2f);
        videoPlay.clipWithDelay(videoPlayer.GetComponent<VideoPlayer>(), glitch, 7.2f);
        // This disables the crewmate screen image
        mod.enableWithDelay(crewmateScreen.GetComponent<Image>(), 8.2f, false);
        // This shows and play the glitch rawImage
        mod.enableWithDelay(videoRaw.GetComponent<RawImage>(), 8.2f, true);
        videoPlay.playWithDelay(videoPlayer.GetComponent<VideoPlayer>(), 8.2f);
        // This shows the "Survive" screen
        mod.enableWithDelay(surviveScreen.GetComponent<Image>(), 8.2f, true);
        // This stops he glitch video
        videoPlay.stopWithDelay(videoPlayer.GetComponent<VideoPlayer>(), 10.2f);
        // This disables the glitch video 
        mod.enableWithDelay( videoRaw.GetComponent<RawImage>(), 10.2f, false);
        // This fades the "surviveScreen"
        mod.fadeWithDelay(surviveScreen.GetComponent<Image>(), 0, 2, 14.2f);
        // This changes the scene
        scene.ChangeSceneWithDelay("Night1Scene", 17);*/
    }

    IEnumerator UITransition()
    {
        // This sets the crewmateScreen's alpha to 0 so that we can fade it in
        mod.Fade(crewmateScreen, 0, 0.1f);
        // This fades out every element of the menu screen
        mod.Fade(mainMenuBackground, 0, 1);
        mod.Fade(newGameButton, 0, 1);
        mod.Fade(settingsButton, 0, 1);
        mod.Fade(quitButton, 0, 1);
        // Delays the program for 1 second
        yield return new WaitForSeconds(1);
        // Disables the mainMenuBackground Image and rests the alpha of the menu assets to 1
        mod.Enable(mainMenu, false);
        mod.Fade(mainMenuBackground, 1, 0.1f);
        mod.Fade(newGameButton, 1, 0.1f);
        mod.Fade(settingsButton, 1, 0.1f);
        mod.Fade(quitButton, 1, 0.1f);
        // Plays the video clip of the Amogus character shushing and enables the Video
        videoPlay.playClip(videoPlayer, shush, 3.5f, false);
        yield return new WaitForSeconds(0.5f);
        mod.Enable(videoRaw, true);
        // Waits for the length of the video until moving onto the next lines of code
        yield return new WaitForSeconds(2.5f);
        // Disables the Video
        mod.Enable(videoRaw, false);
        // Enables the crewmateScreen and causes it to fade in (with a small delay in between)
        mod.Enable(crewmateScreen, true);
        yield return new WaitForSeconds(0.2f);
        mod.Fade(crewmateScreen, 1, 2);
        // After 2 seconds, plays the Glitch video for a length of 2 seconds
        yield return new WaitForSeconds(2);
        videoPlay.playClip(videoPlayer, glitch, 2, true);
        yield return new WaitForSeconds(0.5f);
        mod.Enable(videoRaw, true);
        // Disables the crewmate screen
        mod.Enable(crewmateScreen, false);
        mod.Fade(crewmateScreen, 0, 0.1f);
        // Waits for the length of the Glitch video and then disables it
        yield return new WaitForSeconds(1.5f);
        mod.Enable(videoRaw, false);
        // Enables the surviveScreen 
        mod.Enable(surviveScreen, true);
        yield return new WaitForSeconds(2);
        // After 2 seconds, the surviveScreen begins to fade out, and the scene changes
        mod.Fade(surviveScreen, 0, 2);
        yield return new WaitForSeconds(3);
        SceneChanger.ChangeScene("Night1Scene");
    }
}
