using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class MeltingFurnaceController : MonoBehaviour
{
    public GameObject ironIngotPrefab;
    public Transform rawIronMeltingPos;
    public Transform ironIngotCreatePos;
    public Transform[] ironIngotPoses;
    public List<GameObject> ironIngots = new List<GameObject>();

    public GameObject flameObject;
    public GameObject smokeObject;
    public GameObject lavaEffect;
    public int createdIronCount;

    // Start is called before the first frame update
    void Start()
    {
        StopMelting();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartMelting()
    {
        StartCoroutine(StartMeltingCoroutine());
    }
    private IEnumerator StartMeltingCoroutine()
    {
        SoundControllerManager.instance.Play(SoundType.meltingSound);
        flameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        smokeObject.SetActive(true);
        yield return new WaitForSeconds(1);
        lavaEffect.SetActive(true);
        yield return new WaitForSeconds(5);
        StopMelting();
    }
    public void StopMelting()
    {
        SoundControllerManager.instance.Stop(SoundType.meltingSound);
        flameObject.SetActive(false);
        smokeObject.SetActive(false);
        lavaEffect.SetActive(false);
    }
    public void MakeIronIngot()
    {
        GameObject newIronIngot = Instantiate(ironIngotPrefab, ironIngotCreatePos);
        ironIngots.Add(newIronIngot);
        newIronIngot.transform.parent = ironIngotPoses[createdIronCount];
        createdIronCount++;
        newIronIngot.transform.DOLocalMove(Vector3.zero, 1f);
    }
}
