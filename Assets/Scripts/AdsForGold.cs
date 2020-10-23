using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdsForGold : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private GameObject _startWathingButton;

    private string _gameId = "3874333";
    private string _myPlacementId = "rewardedVideo"; 
    private bool _testMode = true;

    private void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(_gameId, _testMode);

        _startWathingButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            Advertisement.Show(_myPlacementId);
            _startWathingButton.SetActive(false);
        });

    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            Debug.Log("Вам начислено сто монеток");
        }
        else if (showResult == ShowResult.Skipped)
        {
            Debug.Log("Вы пропустили рекламу");
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.Log("Не удалось загрузить рекламу");
        }
        Time.timeScale = 1;
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == _myPlacementId)
        {
            _startWathingButton.SetActive(true);
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Time.timeScale = 0;
    }
}
