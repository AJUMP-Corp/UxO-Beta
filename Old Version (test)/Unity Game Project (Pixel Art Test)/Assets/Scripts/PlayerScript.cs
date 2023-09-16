using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    private Rigidbody2D rig;

    // criar colisao com chao para o player
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }
    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += (Vector3)movement * Time.deltaTime * Speed;
    }
    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            rig.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse); 
        }
        
    }
}
