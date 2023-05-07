using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject tinyRockPrefab;
    public bool IsMining;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("IronRock") && !IsMining && !Manager.instance.player.IsBagFull)
        {
            StartCoroutine(CollectRawIron(other));
        }
    }
    private IEnumerator CollectRawIron(Collider other)
    {
        IsMining = true;
        Manager.instance.player.BagCurrentItemType = ItemType.RawIron;
        yield return new WaitForSeconds(0.5f);
        GameObject newTinyRock = Instantiate(tinyRockPrefab);
        newTinyRock.transform.position = other.transform.position;
        newTinyRock.transform.parent = Manager.instance.player.minerBagPositions[Manager.instance.player.BagCurrentItemCount];
        newTinyRock.transform.DOLocalMove(Vector3.zero, 0.5f);
        other.gameObject.GetComponent<RockBehaviour>().DisableRock();
        Manager.instance.player.BagCurrentItemCount++;
        IsMining = false;
    }
}
