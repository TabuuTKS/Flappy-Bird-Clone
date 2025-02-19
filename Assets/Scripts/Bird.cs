using UnityEngine;

public class Bird : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public float JumpForce = 1000f;
    bool isFalling;
    void Start()
    {
        rigidbody2d = this.GetComponent<Rigidbody2D>();
        isFalling = true;
    }
    void Update()
    {
        RotateBird();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2d.linearVelocity = new Vector2(0, JumpForce);
            
        }
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
}
