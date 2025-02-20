using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Game : MonoBehaviour
{
    public float Score = 0f;
    public Transform SpawnPoint;
    public GameObject Pipe;
    public float PipeSpawnDelay = 5f;
    public float HeightOffset = 10f;
    public TMP_Text ScoreText;
    public AudioSource PointSound;
    public static GameObject GameOverUI, GameUI, GameStartUI;
    public static bool GameStart;
    void Start()
    {
        Time.timeScale = 1f;
        GameStart = false;
        GameUI = GameObject.FindGameObjectWithTag("GameUI");
        GameOverUI = GameObject.FindGameObjectWithTag("GameOverUI");
        GameStartUI = GameObject.FindGameObjectWithTag("GameStartUI");
        GameOverUI.SetActive(false);
        GameUI.SetActive(false);
        GameStartUI.SetActive(true);
        InvokeRepeating("SpawnPipe",2f,PipeSpawnDelay);
    }
    public void SpawnPipe()
    {
        if (GameStart)
        {
            float LowestPoint = SpawnPoint.position.y - HeightOffset;
            float HighestPoint = SpawnPoint.position.y + HeightOffset;

            Instantiate(Pipe, new Vector3(SpawnPoint.position.x, Random.Range(LowestPoint, HighestPoint)), SpawnPoint.rotation);
        }
    }
    public void AddScore()
    {
        PointSound.Play();
        Score += 1;
        ScoreText.text = System.Convert.ToString(Score);
    }
    public static void PauseGame()
    {
        GameUI.SetActive(false);
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
