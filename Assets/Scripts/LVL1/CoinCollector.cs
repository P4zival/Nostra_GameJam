using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    PlayerManager playerManager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Coin Collided");
            this.gameObject.SetActive(false);
            playerManager.CurrentCoinsCollected++;
            Debug.Log("Coin Collected");
            
        }
    }

}
