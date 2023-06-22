using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Diagnostics.Tracing;

public class ManagerGame : MonoBehaviour
{
    //List được sử dụng khi cần một cấu trúc dữ liệu linh hoạt với khả năng thêm/xóa/phân loại dữ liệu dễ dàng.

    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scorelivesText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI pauseText;

    public Button RestartButton;
    public bool isGameActive;
    public GameObject titleGame;

    private float spawnRate = 1f;
    private int score;
    // gia tri dem de lam thua nguoi choi
    private int scoreLives ;

    //public GameObject[] target1;
    // Start is called before the first frame update
    void Start()
    {


    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score : " + score;

    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        RestartButton.gameObject.SetActive(true);

    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = UnityEngine.Random.Range(0, targets.Count);
            Instantiate(targets[index]);

        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Update is called once per frame
    void Update()
    {
        // kiem tra thu tro choi co dang chay khong
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            // neu tro choi dang choi thi co the dung game, va nguoc lai
            if (isGameActive == true)
            {
                PauseGame();
            }
            else
            {
                ContinueGame();
            }
        }

    }

    private void ContinueGame()
    {
       // dung tro choi bang cho khung hinh bang 1 va isGameActive bang true
        Time.timeScale = 1f;
        isGameActive = true;
        pauseText.gameObject.SetActive(false);
    }

    private void PauseGame()
    {
        // dung tro choi bang cho khung hinh bang 0 va isGameActive bang false
        Time.timeScale = 0f;
        isGameActive= false;
        pauseText.gameObject.SetActive(true);
    }

    public void StartGame(int difficult)
    {
        spawnRate /= difficult;
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        scoreLives = 3;
        scorelivesText.text = "Lives :" + scoreLives;
        UpdateScore(0);

        titleGame.SetActive(false);
    }
    // khoi tao ham dem neu nguoi choi lam rot qua 3 vat the good thi tro choi se dung lai
    public void IncreaseConllisonCount()
    {
        scoreLives--;
        scorelivesText.text = "Lives :" + scoreLives;
        if (scoreLives <= 0)
        {
            GameOver();
        }
    }
}
