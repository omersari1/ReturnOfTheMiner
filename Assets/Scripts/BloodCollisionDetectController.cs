using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodCollisionDetectController : MonoBehaviour
{
    public GameObject decalProjectorPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            GameObject bloodDecal = Instantiate(decalProjectorPrefab);
            bloodDecal.transform.position = collision.contacts[0].point+Vector3.up;
            Manager.instance.bloodObjectList.Add(bloodDecal);
            Destroy(gameObject);
        }
    }
}
