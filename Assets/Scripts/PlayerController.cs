using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public const float MOVE_SPEED = 1.5f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            dir = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir = Vector2.down;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            dir = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir = Vector2.right;
        }
        rb.MovePosition((Vector2)transform.position + MOVE_SPEED * Time.deltaTime * dir);
    }
}
