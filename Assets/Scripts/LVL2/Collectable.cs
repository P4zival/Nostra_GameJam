using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private L2Manager l2m;
    // Start is called before the first frame update
    void Start()
    {
        l2m= GetComponent<L2Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player hits an obstacle
        if (collision.collider.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            l2m.CoinsCollected++;
            Debug.Log("Collectable done");

        }

    }
}
