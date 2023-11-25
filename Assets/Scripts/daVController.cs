using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class daVController : MonoBehaviour
{
    public VideoClip[] videoClips;  // 用于存储所有视频片段的数组
    private VideoPlayer videoPlayer;
    private int currentClipIndex = 0;
    [SerializeField] private CharacterInfo characterInfo;
    [SerializeField] private GameObject characterInfoView;
    [SerializeField] private TextMeshProUGUI cName;
    [SerializeField] private TextMeshProUGUI cStrokes;
    [SerializeField] private TextMeshProUGUI cDefinitions;
    private bool display = false;
    private float touchtime;
    private bool newTouch = false;
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        PlayCurrentVideo();
    }

    void PlayCurrentVideo()
    {
        if (currentClipIndex < videoClips.Length)
        {
            videoPlayer.clip = videoClips[currentClipIndex];
            videoPlayer.Play();
        }
        else
        {
            currentClipIndex = 0;
            videoPlayer.clip = videoClips[currentClipIndex];
            videoPlayer.Play();
        }
    }

    public void OnNextButtonClick()
    {
        currentClipIndex++;
        PlayCurrentVideo();
    }
    public void ShowCharacterInfo(CharacterInfo info)
    {
        if (display == false)
        {
            cName.text = info.Name;
            cStrokes.text =  $"{info.Strokes}";
            cDefinitions.text = info.Definitions;
            characterInfoView.SetActive(true);
            display = true;
        }
        else if (display)
        {
            characterInfoView.SetActive(false);
            display = false;
        }

    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (Input.touches[0].phase == TouchPhase.Began)
                {
                    if (hit.transform.name == "da")
                    {
                        newTouch = true;
                        touchtime = Time.time;
                        OnNextButtonClick();
                    }
                }
                else if (Input.touches[0].phase == TouchPhase.Stationary)
                {
                    if (newTouch && hit.transform.name == "da" && (Time.time - touchtime) >= 0.3f)
                    {
                        newTouch = false;
                        ShowCharacterInfo(characterInfo);
                    }
                }
                else
                {
                    newTouch = false;
                }
            }
        }
       
    }
}