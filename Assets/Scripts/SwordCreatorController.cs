using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCreatorController : MonoBehaviour
{

    public Transform IronIngotTakingPos;
    public Transform IronIngotSmashPos;
    public Transform SwordCreatePos;


    public GameObject flameObject;
    public GameObject smokeObject;
    public GameObject SwordSpawEffect;
    public Animation smasherObjectAnimator;
    public bool playerTakedSword;


    // Start is called before the first frame update
    void Start()
    {
        StopSwordCreating();
        SwordSpawEffect.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartSwordCreating()
    {
        StartCoroutine(StartSwordCreatingCoroutine());
    }
    private IEnumerator StartSwordCreatingCoroutine()
    {
        SoundControllerManager.instance.Play(SoundType.SwordCreateSound);
        flameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        smokeObject.SetActive(true);
        yield return new WaitForSeconds(1);
        smasherObjectAnimator.enabled = true;
        yield return new WaitForSeconds(10);
        StopSwordCreating();
    }
    public void StopSwordCreating()
    {
        SoundControllerManager.instance.Stop(SoundType.SwordCreateSound);
        flameObject.SetActive(false);
        smokeObject.SetActive(false);

        smasherObjectAnimator.enabled = false;
    }
    public void MakeSword()
    {
        Transform sword = Manager.instance.weaponAndToolController.swordGameObject.transform;
        sword.SetParent(SwordCreatePos);
        sword.localPosition = Vector3.zero;
        sword.localRotation = Quaternion.identity;
        SwordSpawEffect.SetActive(true);
        Manager.instance.AllMissonComplate = true;
        ScaleSwordAnim();


    }
    private void ScaleSwordAnim()
    {
        Transform sword = Manager.instance.weaponAndToolController.swordGameObject.transform;

        if (!playerTakedSword)
        {
            sword.DOScale(2.5f, 1).SetEase(Ease.InOutSine).OnComplete(() =>
            {
                sword.DOScale(1.5f, 1).SetEase(Ease.InOutSine).SetDelay(0.5f).OnComplete(ScaleSwordAnim);
            });
        }
        else
        {
            sword.DOScale(1.5f, 1);
        }
    }
}
