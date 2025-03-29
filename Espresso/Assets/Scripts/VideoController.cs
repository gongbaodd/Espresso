using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
   [SerializeField] private string videoName;
    void Start()
    {
        var videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoName);
        var player = gameObject.GetComponent<VideoPlayer>();
        player.url = videoPath;
        player.Play();
    }
}
