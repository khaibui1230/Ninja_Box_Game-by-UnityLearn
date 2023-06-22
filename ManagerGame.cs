using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagerGame : MonoBehaviour
{
    //List được sử dụng khi cần một cấu trúc dữ liệu linh hoạt với khả năng thêm/xóa/phân loại dữ liệu dễ dàng.

    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    

    private float spawnRate = 1f;
    private int score;

    //public GameObject[] target1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
       
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score : " + score;
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = UnityEngine.Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            
        }
    }
        // Update is called once per frame
        void Update()
    {


    }
}
