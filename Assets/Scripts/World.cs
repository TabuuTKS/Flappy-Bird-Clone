using UnityEngine;

public class World : MonoBehaviour
{
    Vector3 RepeatPos;
    public float Speed;
    void Start()
    {
        RepeatPos = transform.position;
    }
    void Update()
    {
        if (transform.position.x <= -7.69f)
        {
            transform.position = RepeatPos;
        }
        else
        {
            transform.position -= new Vector3(Speed * Time.deltaTime, 0, 0);
        }
    }
}
