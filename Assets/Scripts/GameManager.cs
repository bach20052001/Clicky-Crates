using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public bool active;
    private float timeInterval = 1;
    public int score;
    public TextMeshProUGUI scoreText;
    public GameObject gameOver;
    private IEnumerator coroutine;

    public void SetInterval(float time)
    {
        timeInterval = time;
    }

    //Singleton
    private static GameManager instance;

    public static GameManager Instance()
    {
        if (instance == null)
        {
            instance = new GameManager();
        }
        return instance;
    }
    //==========

    public void IncreaseScore(int num)
    {
        score += num;
        scoreText.text = "Score : " + score;
    }

    IEnumerator SpawnObject()
    {
        while (active)
        {
            yield return new WaitForSeconds(timeInterval);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void GameOver()
    {
        active = false;
        gameOver.SetActive(true);
        StopCoroutine(coroutine);
    }
    public void StartGame()
    {
        instance = GetComponent<GameManager>();
        gameOver.SetActive(false);
        score = 0;
        scoreText.text = "Score : " + score;
        coroutine = SpawnObject();
        active = true;
        StartCoroutine(coroutine);
        GameObject.Find("SetLevel").SetActive(false);
    }
}
