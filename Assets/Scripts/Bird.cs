using System.Drawing;
using UnityEngine;

public class Bird : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public float JumpForce = 1000f;
    bool isFalling;
    public AudioSource Wing, Hit;
    void Start()
    {
        rigidbody2d = this.GetComponent<Rigidbody2D>();
        isFalling = true;
    }
    void Update()
    {
        if (Game.GameStart)
        {
            rigidbody2d.gravityScale = 1;
            RotateBird();
        }


        //PC Controls
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        //Android Controls
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Jump();
            }
        }
    }

    void Jump()
    {
        if (!Game.GameStart)
        {
            Game.GameStart = true;
            Game.GameStartUI.SetActive(false);
            Game.GameUI.SetActive(true);
        }
        rigidbody2d.linearVelocity = new Vector2(0, JumpForce);
        Wing.Play();
    }
    void RotateBird()
    {
        //Clamping Z Rotation
        Vector3 currentRotation = transform.rotation.eulerAngles;
        currentRotation.z = (currentRotation.z > 180) ? currentRotation.z - 360 : currentRotation.z;
        currentRotation.z = Mathf.Clamp(currentRotation.z, -30f, 30f);
        transform.rotation = Quaternion.Euler(currentRotation);

        //Rotates The Bird
        transform.Rotate(0, 0, (isFalling) ? -5.0f : 5.0f);
        isFalling = (rigidbody2d.linearVelocityY > 0) ? false : true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Hit.Play();
            Game.PauseGame();
        }
    }
}
