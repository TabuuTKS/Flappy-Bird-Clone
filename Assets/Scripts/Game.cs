using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    public float Score = 0f;
    public Transform SpawnPoint;
    public GameObject Pipe;
    public float PipeSpawnDelay = 5f;
    public float HeightOffset = 10f;
    public TMP_Text ScoreText;
    void Start()
    {
        InvokeRepeating("SpawnPipe",2f,PipeSpawnDelay);
    }
    public void SpawnPipe()
    {
        float LowestPoint = SpawnPoint.position.y - HeightOffset;
        float HighestPoint = SpawnPoint.position.y + HeightOffset;

        Instantiate(Pipe, new Vector3(SpawnPoint.position.x, Random.Range(LowestPoint,HighestPoint)), SpawnPoint.rotation);
    }
    public void AddScore()
    {
        Score += 1;
        ScoreText.text = System.Convert.ToString(Score);
    }
}
