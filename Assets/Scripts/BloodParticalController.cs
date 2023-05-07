using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodParticalController : MonoBehaviour
{
    public GameObject bloodPrefab;


    public float forceEffect = 2;

     
    // Start is called before the first frame update
    void Start()
    {

    }


    public void CreateBlood()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject blood = Instantiate(bloodPrefab, transform);
            Rigidbody bloodRigidbody = blood.GetComponent<Rigidbody>();
            bloodRigidbody.AddForce(new Vector3(Random.Range(-15, 15), 20, Random.Range(-15, 15)) * forceEffect);
        }
    }
}