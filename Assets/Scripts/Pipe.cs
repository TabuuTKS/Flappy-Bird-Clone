using Unity.VisualScripting;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float Speed = 5f;
    GameObject gameobject;
    Game game;

    private void Start()
    {
        gameobject = GameObject.FindGameObjectWithTag("Logic");
        game = gameobject.GetComponent<Game>();
    }
    void Update()
    {
        if (Game.GameStart)
        {
            transform.position -= new Vector3(Speed, 0, 0) * Time.deltaTime;

            if (transform.position.x <= -10)
            {
                Destroy(this.gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            game.AddScore();
        }
    }
}
