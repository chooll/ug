using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed; 
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D body; 
    private Animator anim; 
    private BoxCollider2D boxCollider;

    private void Awake() { 
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Jump () {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger ("jump");
    }

    private bool isGrounded () {
        RaycastHit2D raycastHit = Physics2D.BoxCast (boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.2f);
        return raycastHit;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (horizontalInput > 0.01f) {
            transform.localScale = Vector3.one; 
        } else if (horizontalInput < -0.01f) {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded()) {
            Jump();
        }

        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());
    }
}
