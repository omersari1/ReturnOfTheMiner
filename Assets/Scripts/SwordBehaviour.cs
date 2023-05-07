using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehaviour : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boss") && Manager.instance.currentAnimationState == AnimState.SwordAttack)
        {
            Manager.instance.boss.DamageBoss();
            SoundControllerManager.instance.Play(SoundType.swordHit);
        }
    }
}
