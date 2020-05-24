using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector]
    private Rigidbody2D rb;

    [SerializeField] float velocity = 3.5f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-velocity, 0);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(velocity, 0);
        }
        else
        {
            rb.velocity = new Vector2();
        }
    }
}