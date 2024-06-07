using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class VideoLooper : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public float rewindSpeed = 1.0f; // Speed multiplier for rewind

    private bool isReversing = false;
    private double videoDuration;

    void Start()
    {
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        if (videoPlayer.clip != null)
        {
            videoDuration = videoPlayer.clip.length;
            videoPlayer.playOnAwake = false;
            videoPlayer.isLooping = false;

            // Attach event handlers
            videoPlayer.prepareCompleted += OnPrepareCompleted;
            videoPlayer.loopPointReached += OnLoopPointReached;
            videoPlayer.errorReceived += OnErrorReceived;

            Debug.Log("Video duration: " + videoDuration);

            // Prepare the video player
            videoPlayer.Prepare();
            Debug.Log("Preparing video.");
        }
        else
        {
            Debug.LogError("Video clip is not assigned to the VideoPlayer.");
        }
    }

    void OnPrepareCompleted(VideoPlayer vp)
    {
        Debug.Log("Video prepared.");
        videoPlayer.Play();
        StartCoroutine(FrameByFramePlayback());
    }

    void OnLoopPointReached(VideoPlayer vp)
    {
        Debug.Log("Video reached end.");
    }

    void OnErrorReceived(VideoPlayer vp, string message)
    {
        Debug.LogError("VideoPlayer Error: " + message);
    }

    IEnumerator FrameByFramePlayback()
    {
        while (true)
        {
            if (!videoPlayer.isPlaying)
            {
                Debug.Log("Video is not playing, forcing playback.");
                videoPlayer.Play();
            }

            if (isReversing)
            {
                videoPlayer.time -= Time.deltaTime * rewindSpeed;
                if (videoPlayer.time <= 0)
                {
                    isReversing = false;
                    videoPlayer.time = 0.1; // Small offset to avoid getting stuck at 0
                    Debug.Log("Switching to forward playback.");
                }
            }
            else
            {
                videoPlayer.time += Time.deltaTime;
                if (videoPlayer.time >= videoDuration)
                {
                    isReversing = true;
                    videoPlayer.time = videoDuration - 0.1; // Small offset to avoid getting stuck at the end
                    Debug.Log("Switching to reverse playback.");
                }
            }

            Debug.Log("Current time: " + videoPlayer.time + ", Reversing: " + isReversing);
            yield return null;
        }
    }
}