using UnityEngine;

public class Bird : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public float JumpForce = 1000f;
    void Start()
    {
        rigidbody2d = this.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2d.linearVelocity = new Vector2(0, JumpForce);
        }
    }
}
