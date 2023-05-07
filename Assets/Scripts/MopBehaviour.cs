using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MopBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Decal") && Manager.instance.currentAnimationState == AnimState.Mop)
        {
            Manager.instance.CleanBlood(other.gameObject);
        }
    }
}
