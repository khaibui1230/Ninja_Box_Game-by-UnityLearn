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
    public GameObject Boom;

    public Image image;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scorelivesText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI pauseText;

    public Button RestartButton;
    public bool isGameActive;
    public GameObject titleGame;
    public GameObject catchEnemi;
    public Swipe swipe;

    [Range(1f, 5f)]
    public float BoomChange;

    private float spawnRate = 1f;
    private int score;

    // gia tri dem de lam thua nguoi choi
    private uint scoreLives;

    //public GameObject[] target1;
    // Start is called before the first frame update
    void Start()
    {
        // khai bao ham de co the su dung script Swipe
        swipe = GameObject.Find("Swipe").GetComponent<Swipe>();

    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score : " + score;

    }
    public void UpdateScorelives()
    {
        scoreLives--;
        scorelivesText.text = "Lives :" + scoreLives;
        if (scoreLives <= 0)
        {
            GameOver();

        }
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        RestartButton.gameObject.SetActive(true);
        catchEnemi.SetActive(true);

    }



    // ham khoi tao ra cac doi tuong good and bad
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            // hàm doi 1 khoang thoi gian

            yield return new WaitForSeconds(spawnRate);
            int index = UnityEngine.Random.Range(0, targets.Count);
            Instantiate(targets[index]);

        }
    }
    IEnumerator SpawnBoom()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(BoomChange);
            Instantiate(Boom);
        }
    }



    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale= 1.0f;
    }
    // Update is called once per frame
    void Update()
    {
        // kiem tra thu tro choi co dang chay khong
        if (Input.GetKeyDown(KeyCode.Escape))
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
        isGameActive = false;
        pauseText.gameObject.SetActive(true);
    }

    public void StartGame(int difficult)
    {
        spawnRate /= difficult;
        BoomChange /= difficult;
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        StartCoroutine(SpawnBoom());
        score = 0;
        scoreLives = 3;

        UpdateScore(0);

        titleGame.SetActive(false);
    }

    // khoi tao ham dem neu nguoi choi lam rot qua 3 vat the good thi tro choi se dung lai


    // tao  hieu ung neu nguoi choi chem vao boom
    //public IEnumerator explosionSquence()
    //{
    //    float elapsed = 0f;
    //    float duration = 0.5f;

    //    while (elapsed < duration)
    //    {
    //        float t = Mathf.Clamp01(elapsed / duration);
    //        image.color = Color.Lerp(Color.clear, Color.white,t);

    //        Time.timeScale = 1f - t;
    //        elapsed += Time.unscaledDeltaTime;

    //        yield return null;

    //    }
    //    yield return new WaitForSecondsRealtime(1f);
    //    GameOver();

    //    elapsed= 0f;
    //    while (elapsed < duration)
    //    {
    //        float t = Mathf.Clamp01(elapsed / duration);
    //        image.color = Color.Lerp(Color.white, Color.clear, t);

    //        Time.timeScale = 1f - t;
    //        elapsed += Time.unscaledDeltaTime;

    //        yield return null;

    //    }
    //}
}
