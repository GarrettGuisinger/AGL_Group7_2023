using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Video;

namespace UI_Scripts 
{
    public class VideoScript : MonoBehaviour
    {
        public VideoScript()
        {
            
        }

        public void playClip(VideoPlayer player, VideoClip clip, float length, bool loop)
        {
            player.clip = clip;
            player.Prepare();
            player.Play();
            player.isLooping = loop;
            StartCoroutine(stop(player, length));
        }
        
        public void playWithDelay(VideoPlayer video, float delay)
        {
            StartCoroutine(play(video, delay));
        }

        public void stopWithDelay(VideoPlayer video, float delay)
        {
            StartCoroutine(stop(video, delay));
        }
        
        public void clipWithDelay(VideoPlayer video, VideoClip clip, float delay)
        {
            StartCoroutine(clipChange(video, clip, delay));
        }

        public void loop(VideoPlayer video, bool loop, float delay)
        {
            StartCoroutine(looper(video, loop, delay));
        }

        IEnumerator play(VideoPlayer video, float delay)
        {
            yield return new WaitForSeconds(delay);
            video.Play();
        }

        IEnumerator stop(VideoPlayer video, float delay)
        {
            yield return new WaitForSeconds(delay);
            video.Stop();
        }
        
        // ReSharper disable Unity.PerformanceAnalysis
        IEnumerator clipChange(VideoPlayer video, VideoClip clip, float delay)
        {
            yield return new WaitForSeconds(delay);
            video.clip = clip;
            video.Prepare();
        }
        
        IEnumerator looper(VideoPlayer video, bool loop, float delay)
        {
            yield return new WaitForSeconds(delay);
            video.isLooping = loop;
        }
    }
}