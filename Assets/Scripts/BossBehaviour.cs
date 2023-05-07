using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    private float healt = 3;
    public float Healt { get { return healt; } set { healt = value; SetHealtBar(); } }


    public BloodParticalController bloodParticalController;
    public Animator bossAnimator;

    private void Start()
    {
        bossAnimator = GetComponent<Animator>();
    }
    public void DamageBoss()
    {
        if (healt > 0)
        {
            Healt--;
            bloodParticalController.CreateBlood();
        }
        else
        {
            bossAnimator.SetBool("Die",true);
            SoundControllerManager.instance.Play(SoundType.DieSound);
            Manager.instance.SetPlayerUsingTool(ToolType.Mop);

        }
    }
    private void SetHealtBar()
    {
        UIControllerManager.instance.bossHealthBar.SetHealt(Healt / 3);
    }


}
