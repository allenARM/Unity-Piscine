using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript_ex01 : MonoBehaviour
{
    bool onGround = true;
    Rigidbody2D _rb;
    public float       speed;
    float       moveInput;
    public Transform   feetpos;
    float       checkRadius;
    public float    jump_power;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        checkRadius = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.OverlapCircle(feetpos.position, checkRadius, LayerMask.GetMask("Ground"));
        moveInput = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(moveInput * speed, _rb.velocity.y);
        if (onGround == true && Input.GetKeyDown(KeyCode.Space))
            _rb.velocity = Vector2.up * jump_power;
    }
     void OnCollisionStay2D(Collision2D col)
     {
        if (col.gameObject.CompareTag("Player"))
            onGround = true;
        if (onGround == true && Input.GetKeyDown(KeyCode.Space))
            _rb.velocity = Vector2.up * jump_power;
     }
}
