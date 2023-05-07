using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehaviour : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private SphereCollider collider;
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        collider = GetComponent<SphereCollider>();
    }
    private IEnumerator Reactivate()
    {
        yield return new WaitForSeconds(10);
        meshRenderer.enabled = true;
        collider.enabled = true;
    }

    public void DisableRock()
    {
        meshRenderer.enabled = false;
        collider.enabled = false;
        SoundControllerManager.instance.Play(SoundType.pickAxe);
        StartCoroutine(Reactivate());
    }

}
