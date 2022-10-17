using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;// load screne


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] TextMeshProUGUI killText; //hiển thị điểm số
    public GameObject restartButton;
    public GameObject titleScreen;//list button điều hành game
    public GameObject[] animalPrefabs;//list động vật


    public AudioClip pointSound;
    private AudioSource bulletAudio;




    public bool isGameActive; //trạng thái game
    private float spanwRate = 2f; //tốc dộ spawn
    public int killCount;

    private void Start()
    {
        bulletAudio = GetComponent<AudioSource>();
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        spanwRate /= difficulty; //lấy số chọn đỗ khó cho tốc độ sinh sản
        titleScreen.gameObject.SetActive(false);// tắt nút chọn độ khó 
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }



    //điếm số kill
    public void UpdateKillCounterUI()
    {
       
        killText.text = "Kill: " + killCount.ToString();
        bulletAudio.PlayOneShot(pointSound, 1.0f);//cái số phía sau là âm lượng
    }



    public void GameOver()
    {
        isGameActive = false;
        restartButton.SetActive(true);
    }



    //nút restart
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



    //điếm ngược sinh sản
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spanwRate);//điếm ngược thực thi
            int animalIndex = Random.Range(0, animalPrefabs.Length);//index nhận ngẫu nhiên giá trị 0-3 trong list
            //sinh ra ở vị trí 
            int randomX = Random.Range(-10, 10);
            int randomZ = Random.Range(10, 30);
            Instantiate(animalPrefabs[animalIndex], new Vector3(randomX, 0, randomZ), animalPrefabs[animalIndex].transform.rotation);//khởi tạo giá trị trong list
        }
    }
}
