using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAndToolController : MonoBehaviour
{
    public GameObject pickAxeGameObject;
    public GameObject swordGameObject;
    public GameObject mopGameObject;
    // Start is called before the first frame update
    void Start()
    {
        Manager.instance.weaponAndToolController = this;
        if (pickAxeGameObject != null)
            pickAxeGameObject = Instantiate(pickAxeGameObject, Manager.instance.player.pickAxeParent);
        else
            Debug.LogWarning("pickAxePrefab is null");
        if (swordGameObject != null)
            swordGameObject = Instantiate(swordGameObject, Manager.instance.player.swordParent);
        else
            Debug.LogWarning("pickAxePrefab is null");
        if (mopGameObject != null)
            mopGameObject = Instantiate(mopGameObject, Manager.instance.player.mopParent);
        else
            Debug.LogWarning("pickAxePrefab is null");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
