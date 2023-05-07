using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightTopButtonsController : MonoBehaviour
{
    public Button homePageBtn;
    public Toggle SoundOnBtn;
    public Button rePlayBtn;

    // Start is called before the first frame update
    void Start()
    {
        InitializeRightTopButtons();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void InitializeRightTopButtons()
    {

        homePageBtn.onClick.AddListener(() =>
        {
            UIControllerManager.instance.OpenHomePage();
            SoundControllerManager.instance.Play(SoundType.clickSound);
        });

        rePlayBtn.onClick.AddListener(() =>
        {
            Manager.instance.ResetScene();
            SoundControllerManager.instance.Play(SoundType.clickSound);
        });
        SoundOnBtn.onValueChanged.AddListener(soundOnBtnOnValueChanged);
    }
    private void soundOnBtnOnValueChanged(bool arg0)
    {
        SoundControllerManager.instance.sceneAudioListener.enabled = arg0;
        SoundControllerManager.instance.Play(SoundType.clickSound);
    }

}
