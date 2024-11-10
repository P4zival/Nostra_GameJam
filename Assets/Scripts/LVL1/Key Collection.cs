using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollection : MonoBehaviour
{
    PlayerManager playerManager;
    public bool KeyCollected = false;
    public GameObject PortalPrefab;


    // Start is called before the first frame update
    void Start()
    {
        PortalPrefab.SetActive(false);
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
            this.gameObject.SetActive(false);
            KeyCollected = true;
            Debug.Log("Key Collected");
            PortalPrefab.SetActive(true);
            // Implement game over logic here (e.g., restart level or stop movement)
        }
    }
}
