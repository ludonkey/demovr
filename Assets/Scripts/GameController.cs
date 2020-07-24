using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    public int score = 0;
    public int nbCubeToInstanciare = 20;
    public int nbCubeToCollect = 10;
    public float playAreaWidth = 45.0f;
    public float spawnMinHeight = 5.0f;
    public float spawnMaxHeight = 15.0f;
    public GameObject explosionPrefab;
    public GameObject collectiblePrefab;
    public Text scoreText;

    void Start()
    {
        PopulateCollectibles();
        UpdateTextScore();
    }

    private void PopulateCollectibles()
    {
        for (int i = 0; i < nbCubeToInstanciare; i++)
        {
            float x = Random.Range(-playAreaWidth / 2.0f, playAreaWidth / 2.0f);
            float z = Random.Range(-playAreaWidth / 2.0f, playAreaWidth / 2.0f);
            float y = Random.Range(spawnMinHeight, spawnMaxHeight);
            Vector3 randomPos = new Vector3(x, y, z);
            Instantiate(collectiblePrefab, randomPos, explosionPrefab.transform.rotation);
        }
    }

    public void PlayerCollected(GameObject collectible)
    {
        RemoveCollectible(collectible);
        IncrementScore();
        if (score >= nbCubeToCollect)
        {
            Win();
        }
    }

    private void RemoveCollectible(GameObject collectible)
    {
        Instantiate(explosionPrefab, collectible.transform.position, Quaternion.identity);
        Destroy(collectible);
    }


    private void IncrementScore()
    {
        score++;
        UpdateTextScore();
    }

    private void UpdateTextScore()
    {
        scoreText.text = score.ToString() + "/" + nbCubeToCollect;
    }

    private void Win()
    {
        Invoke("ReloadScene", 2.5f);
        GetComponent<AudioSource>().Play();
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
