using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2Manager : MonoBehaviour
{
    private Collectable Cs;
    private AircraftController Ac;
    public GameObject CollectablePrefab;

    public int CoinsCollected = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cs = GetComponent<Collectable>();
        Ac = GetComponent<AircraftController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CoinsCollected == 10)
        {
            Debug.Log("Level req done");
        }
    }
    
}
