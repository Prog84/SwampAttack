using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInit : MonoBehaviour
{
    private string _gameId = "3874333";
    private bool _testMode = true;

    private void Start()
    {
        Advertisement.Initialize(_gameId, _testMode);
        StartCoroutine(ShowBannerWhenReady());
        
    }

    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady("MainBottom"))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        Advertisement.Banner.Show("MainBottom");
    }
}
