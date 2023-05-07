using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkStateController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RawIronMiningArea") && !Manager.instance.player.IsBagFull && Manager.instance.player.BagCurrentItemType != ItemType.IronIngot && Manager.instance.playerUsingToolType == ToolType.None)
        {
            Manager.instance.SetPlayerUsingTool(ToolType.PickAxe);
        }
        if (other.CompareTag("RawIronDeliverPoint") && Manager.instance.player.IsBagFull && Manager.instance.player.BagCurrentItemType == ItemType.RawIron)
        {
            StartCoroutine(Manager.instance.DeliverRawIron());
        }
        if (other.CompareTag("IronIngotTakePoint") && !Manager.instance.player.IsBagFull && Manager.instance.player.BagCurrentItemType != ItemType.RawIron)
        {
            Manager.instance.TakeIronIngot();
        }
        if (other.CompareTag("IronIngotDeliverPoint") && Manager.instance.player.IsBagFull && Manager.instance.player.BagCurrentItemType == ItemType.IronIngot)
        {
            StartCoroutine(Manager.instance.DeliverIronIngot());
        }
        if (other.CompareTag("SwordTakePoint") && Manager.instance.player.BagCurrentItemType == ItemType.None)
        {
            Manager.instance.TakeSword();
        }
        if (other.CompareTag("BossAttackArea") && Manager.instance.playerUsingToolType == ToolType.Sword)
        {
            Manager.instance.PlayerAttack(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("RawIronMiningArea"))
        {
            Manager.instance.SetPlayerUsingTool(ToolType.None);
        }
        if (other.CompareTag("BossAttackArea") && Manager.instance.playerUsingToolType == ToolType.Sword)
        {
            Manager.instance.PlayerAttack(false);
        }
    }
}
