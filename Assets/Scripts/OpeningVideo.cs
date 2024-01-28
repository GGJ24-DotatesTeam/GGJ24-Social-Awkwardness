using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class OpeningVideo : MonoBehaviour
{
    [SerializeField] private string videoFileName = "OpeningVideo.mp4";
    private void Start()
    {
        PlayVideo();
        Invoke("LoadNextScene", 18f);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadNextScene();
        }
    }

    public void PlayVideo()
    {
        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();

        if (videoPlayer)
        {
            videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
            videoPlayer.Play();
        }
    }
    
    private void LoadNextScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
