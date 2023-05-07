using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum AnimState
{
    Mining,
    Sword,
    SwordAttack,
    Mop,
    Dance,
}
public enum ToolType
{
    None,
    PickAxe,
    Sword,
    Mop,
}
public enum ItemType
{
    None,
    RawIron,
    IronIngot,
}
public class Manager : MonoBehaviour
{
    public static Manager instance;


    public PlayerBehaviour player;
    public MeltingFurnaceController meltingFurnaceController;
    public WeaponAndToolController weaponAndToolController;
    public SwordCreatorController swordCreatorController;


    public BossBehaviour boss;

    public List<GameObject> bloodObjectList = new List<GameObject>();

    public AnimState currentAnimationState;
    public ToolType playerUsingToolType = ToolType.None;
    public bool AllMissonComplate;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        SetPlayerUsingTool(ToolType.None);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CleanBlood(GameObject gameObject)
    {
        bloodObjectList.Remove(gameObject);
        Destroy(gameObject);
        if (bloodObjectList.Count == 0)
        {
            FinishTheGame();
        }

    }
    public void SetPlayerUsingTool(ToolType toolType)
    {
        playerUsingToolType = toolType;

        switch (toolType)
        {
            case ToolType.PickAxe:
                player.pickAxeParent.gameObject.SetActive(true);
                player.swordParent.gameObject.SetActive(false);
                AnimationChange(AnimState.Mining, true);
                break;
            case ToolType.Sword:
                player.swordParent.gameObject.SetActive(true);
                weaponAndToolController.swordGameObject.transform.localPosition = Vector3.zero;
                weaponAndToolController.swordGameObject.transform.localRotation = Quaternion.identity;
                player.pickAxeParent.gameObject.SetActive(false);
                AnimationChange(AnimState.Sword, true);
                break;
            case ToolType.Mop:
                player.swordParent.gameObject.SetActive(false);
                player.pickAxeParent.gameObject.SetActive(false);
                player.mopParent.gameObject.SetActive(true);
                AnimationChange(AnimState.Sword, false);
                AnimationChange(AnimState.SwordAttack, false);
                AnimationChange(AnimState.Mop, true);
                break;
            case ToolType.None:
                player.swordParent.gameObject.SetActive(false);
                player.pickAxeParent.gameObject.SetActive(false);
                player.mopParent.gameObject.SetActive(false);
                AnimationChange(AnimState.Mining, false);
                AnimationChange(AnimState.SwordAttack, false);
                AnimationChange(AnimState.Mop, false);
                break;
            default:
                break;
        }
    }
    public void PlayerAttack(bool isAttack)
    {
        AnimationChange(AnimState.SwordAttack, isAttack);
    }
    public void FinishTheGame()
    {
        SetPlayerUsingTool(ToolType.None);
        AnimationChange(AnimState.Dance, true);
        UIControllerManager.instance.ShowWinPanel();
        SoundControllerManager.instance.Stop(SoundType.playingSound);
        SoundControllerManager.instance.Play(SoundType.danceSound);
    }
    public void AnimationChange(AnimState animState, bool activate)
    {
        currentAnimationState = animState;
        player.playerAnimator.SetBool(animState.ToString(), activate); ;
    }
    public void TakeIronIngot()
    {
        if (meltingFurnaceController.ironIngots.Count > 0)
        {
            for (int i = 0; i < meltingFurnaceController.ironIngots.Count; i++)
            {
                meltingFurnaceController.ironIngots[i].transform.SetParent(player.minerBagPositions[i]);
                meltingFurnaceController.ironIngots[i].transform.DOLocalMove(Vector3.zero, 0.5f);
            }
            player.BagCurrentItemType = ItemType.IronIngot;
            player.BagCurrentItemCount = meltingFurnaceController.ironIngots.Count;
            meltingFurnaceController.ironIngots.Clear();
        }
    }
    public void TakeSword()
    {
        if (AllMissonComplate)
        {
            weaponAndToolController.swordGameObject.transform.SetParent(player.swordParent);
            swordCreatorController.SwordSpawEffect.SetActive(false);
            swordCreatorController.playerTakedSword = true;
            SetPlayerUsingTool(ToolType.Sword);
            UIControllerManager.instance.ShowHealthBar();
        }
    }
    public IEnumerator DeliverRawIron()
    {
        meltingFurnaceController.StartMelting();
        for (int i = 0; i < player.minerBagPositions.Length; i++)
        {
            GameObject rawIron = player.minerBagPositions[i].GetChild(0).gameObject;
            yield return new WaitForSeconds(1);
            rawIron.transform.parent = null;
            rawIron.transform.DOMove(meltingFurnaceController.rawIronMeltingPos.position, 1f).OnComplete(() =>
            {
                Destroy(rawIron);
                meltingFurnaceController.MakeIronIngot();
            });
        }
        player.BagCurrentItemType = ItemType.None;
        player.BagCurrentItemCount = 0;
        player.IsBagFull = false;
    }
    public IEnumerator DeliverIronIngot()
    {
        swordCreatorController.StartSwordCreating();
        for (int i = 0; i < player.minerBagPositions.Length; i++)
        {
            GameObject IronIngot = player.minerBagPositions[i].GetChild(0).gameObject;
            yield return new WaitForSeconds(1.5f);
            IronIngot.transform.parent = null;
            IronIngot.transform.DOMove(swordCreatorController.IronIngotTakingPos.position, 1f).OnComplete(() =>
            {
                IronIngot.transform.DOMove(swordCreatorController.IronIngotSmashPos.position, 1f).OnComplete(()=> { Destroy(IronIngot); }) ;
            });
        }

        swordCreatorController.MakeSword();
        player.BagCurrentItemType = ItemType.None;
        player.BagCurrentItemCount = 0;
        player.IsBagFull = false;
    }
}
