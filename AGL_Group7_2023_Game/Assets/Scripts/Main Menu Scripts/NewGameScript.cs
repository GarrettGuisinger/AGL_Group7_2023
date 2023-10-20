using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI_Scripts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class NewGameScript : MonoBehaviour
{
    private GameObject mainMenuBackground;
    private GameObject newGameButton;
    private GameObject settingsButton;
    private GameObject quitButton;
    private GameObject videoRaw;
    private GameObject videoPlayer;
    private GameObject crewmateScreen;
    private GameObject surviveScreen;
    [SerializeField] private VideoClip shush;
    [SerializeField] private VideoClip glitch; 
    
    void Start(){
        mainMenuBackground = GameObject.Find("MainMenuBackground");
        newGameButton = GameObject.Find("New Game (Text)");
        settingsButton = GameObject.Find("Settings (Text)");
        quitButton = GameObject.Find("Quit (Text)");
        videoRaw = GameObject.Find("VideoRaw");
        videoPlayer = GameObject.Find("Video Player");
        crewmateScreen = GameObject.Find("CrewmateScreen");
        surviveScreen = GameObject.Find("SurviveTransition");
    }

    public void startNewGame()
    {
        VisibilityModifier mod = gameObject.AddComponent<VisibilityModifier>();
        VideoScript videoPlay = videoPlayer.AddComponent<VideoScript>();
        mod.Fade(crewmateScreen.GetComponent<Image>(), 0, 0.1f);
        mod.Fade(mainMenuBackground.GetComponent<Image>(), 0, 1);
        mod.Fade(newGameButton.GetComponent<TextMeshProUGUI>(), 0, 1);
        mod.Fade(settingsButton.GetComponent<TextMeshProUGUI>(), 0, 1);
        mod.Fade(quitButton.GetComponent<TextMeshProUGUI>(), 0, 1);
        mod.enableWithDelay(mainMenuBackground.GetComponent<Image>(), 2, false);
        videoPlay.clipWithDelay(videoPlayer.GetComponent<VideoPlayer>(), shush, 2);
        mod.enableWithDelay(videoRaw.GetComponent<RawImage>(), 3, true);
        videoPlay.playWithDelay(videoPlayer.GetComponent<VideoPlayer>(), 2.5f);
        videoPlay.stopWithDelay(videoPlayer.GetComponent<VideoPlayer>(), 6);
        mod.enableWithDelay(videoRaw.GetComponent<RawImage>(), 6, false);
        mod.enableWithDelay(crewmateScreen.GetComponent<Image>(), 6, true);
        mod.fadeWithDelay(crewmateScreen.GetComponent<Image>(),  1, 2, 6.2f); 
        videoPlay.loop(videoPlayer.GetComponent<VideoPlayer>(), true, 7.2f);
        videoPlay.clipWithDelay(videoPlayer.GetComponent<VideoPlayer>(), glitch, 7.2f);
        mod.enableWithDelay(crewmateScreen.GetComponent<Image>(), 8.2f, false);
        mod.enableWithDelay(videoRaw.GetComponent<RawImage>(), 8.2f, true);
        videoPlay.playWithDelay(videoPlayer.GetComponent<VideoPlayer>(), 8.2f);
        mod.enableWithDelay(surviveScreen.GetComponent<Image>(), 8.2f, true);
        videoPlay.stopWithDelay(videoPlayer.GetComponent<VideoPlayer>(), 10.2f);
        mod.enableWithDelay( videoRaw.GetComponent<RawImage>(), 10.2f, false);
        mod.fadeWithDelay(surviveScreen.GetComponent<Image>(), 0, 2, 14.2f);
        SceneChanger scene = gameObject.AddComponent<SceneChanger>();
        scene.ChangeSceneWithDelay("Night1Scene", 17);
    }
}
