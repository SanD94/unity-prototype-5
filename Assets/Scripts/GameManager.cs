using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    

    public GameObject titleScreen;
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    
    public bool isGameActive;

    private int score;
    private float spawnRate = 1.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;

        isGameActive = true;
        StartCoroutine(SpawnTarget());

        score = 0;
        UpdateScore(0);

        titleScreen.SetActive(false);
    }
     
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score : " + score;
    }
    

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }
    

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
}
