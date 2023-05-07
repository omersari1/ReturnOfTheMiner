using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControllerManager : MonoBehaviour
{
    public static UIControllerManager instance;

    public GameObject homePage;
    public GameObject winPanel;
    public HealthBar bossHealthBar;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void StartGame()
    {
        homePage.SetActive(false);
        SoundControllerManager.instance.Play(SoundType.clickSound);
        SoundControllerManager.instance.Stop(SoundType.startingSound);
        SoundControllerManager.instance.Play(SoundType.playingSound);
    }
    public void OpenHomePage()
    {
        homePage.SetActive(true);
    }
    public void ShowHealthBar()
    {
        bossHealthBar.gameObject.SetActive(true);
    }
    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
    }
}
