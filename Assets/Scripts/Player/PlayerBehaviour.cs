using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public Animator playerAnimator;

    public Transform[] minerBagPositions;

    public int bagMaxCapacity = 5;
    private int bagCurrentItemCount;
    public int BagCurrentItemCount
    {
        get { return bagCurrentItemCount; }
        set
        {
            if (value == bagMaxCapacity)
            {
                IsBagFull = true;
            }
            bagCurrentItemCount = value;
        }
    }
    private bool isBagFull;
    public Transform pickAxeParent;
    public Transform swordParent;
    public Transform mopParent;

    public bool IsBagFull { get { return isBagFull; } set { isBagFull = value; BagStateChanged(); } }

    public ItemType BagCurrentItemType { get; internal set; }
    public bool IsBagEmpty { get; internal set; }


    // Start is called before the first frame update
    void Start()
    {
        if (playerAnimator == null)
            playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void BagStateChanged()
    {
        if (IsBagFull && Manager.instance.currentAnimationState == AnimState.Mining)
            Manager.instance.AnimationChange(AnimState.Mining, false);
    }
}
