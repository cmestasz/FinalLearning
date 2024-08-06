using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator interactText;
    private IKeyInteractable interactable;
    private Rigidbody2D rb;
    public static bool canMove;
    private float moveSpeed;
    private Animator animator;
    private Vector3 scale;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = PlayerPrefs.GetInt("speed") * 0.0025f;
        animator = GetComponent<Animator>();
        scale = transform.localScale;
        canMove = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 dir = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            dir += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            dir += Vector2.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            dir += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dir += Vector2.right;
        }
        dir = dir.normalized;
        if (canMove && dir != Vector2.zero)
        {
            if (dir.x < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (dir.x > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            animator.SetBool("Moving", true);
            rb.MovePosition((Vector2)transform.position + moveSpeed * dir);
        }
        else
        {
            animator.SetBool("Moving", false);
        }

        if (Input.GetMouseButton(0) && interactable != null)
        {
            StartCoroutine(interactable.Interact());
            interactText.SetBool("CanInteract", false);
            interactable = null;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Warp"))
        {
            WarpController warp = other.GetComponent<WarpController>();
            if (warp != null)
            {
                warp.Warp(transform, other.gameObject.transform.position);
            }
        }
        else if (other.CompareTag("KeyInteractable"))
        {
            IKeyInteractable interactable = other.GetComponent<IKeyInteractable>();
            if (interactable != null)
            {
                interactText.SetBool("CanInteract", true);
                this.interactable = interactable;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("KeyInteractable"))
        {
            interactText.SetBool("CanInteract", false);
            interactable = null;
        }
    }
}
