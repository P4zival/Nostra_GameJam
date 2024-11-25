using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Max and Current Values")]
    public int MaxPlayerLives = 3;
    public int CurrentPlayerLives = 3;
    public int MaxCoinsToCollect = 12;
    public int CurrentCoinsCollected = 0;

    [Header("References")]
    public GameObject KeyPrefab;
    public GameObject PortalPrefab;
    public Transform LvlSpawnPos;
    private CoinCollector coinCollector;
    // Start is called before the first frame update
    void Start()
    {
        coinCollector = FindObjectOfType<CoinCollector>();
    }

    // Update is called once per frame
    void Update()
    {
        LivesDetect();
    }
    void LivesDetect()
    {
        if (CurrentPlayerLives == 0)
        {
            Debug.Log("Game Over");
            string currentScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentScene);
        }
    }
    public void LevelReset()
    {
        this.gameObject.transform.position = LvlSpawnPos.transform.position;
        this.gameObject.SetActive(true);
        CurrentPlayerLives--;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Portal"))
        {
            Debug.Log("Collided");
            // Load the scene
            SceneManager.LoadScene("Flying Test");
        }
    }
 
}
