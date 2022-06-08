using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public Rigidbody2D rb;
    public Collider2D coll;
    public Animator anim;
    public LayerMask Ground;



    public float Speed, JumpForce;
    public bool IsGround,IsAttack,IsWalk;
    private bool JumpPressed;

    void Start()
    {
    }



    void Update()
    {
        //检测人物和地面是否有碰撞
        IsGround = coll.IsTouchingLayers(Ground);
        

        //游戏中跳跃
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpPressed = true;
        }
        else
        {
            JumpPressed = false;
        }
        Move();
        Jump();
        SwitchAnim();


    }
    private void FixedUpdate()
    {

    }


    void Move()
    {

        //移动
        float horinzontalmove = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(horinzontalmove * Speed, rb.velocity.y);

        //人物左右转向
        if (horinzontalmove != 0) transform.localScale = new Vector2(horinzontalmove, 1);
        

        //走路动画
        anim.SetFloat("walking", Mathf.Abs(rb.velocity.x));
    }

    void Jump()
    {
        if (IsGround && JumpPressed)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }
    }



    void SwitchAnim()
    {
        ///
        if (rb.velocity.y == 0)
        {
            anim.SetBool("falling", false);
            anim.SetBool("jumping", false);
        }
        else if (JumpPressed && rb.velocity.y > 0)
        {
            anim.SetBool("jumping", true);
            anim.SetBool("falling", false);
        }
        else if (rb.velocity.y < 0)
        {
            anim.SetBool("jumping", false);
            anim.SetBool("falling", true);
        }


        ///攻击动画
        if (Input.GetKeyDown(KeyCode.J) && (Mathf.Abs(rb.velocity.x) <= 0))
        {

            anim.SetTrigger("attack");
        }

        ///走路攻击动画
        if (Input.GetKeyDown(KeyCode.J) && (Mathf.Abs(rb.velocity.x) > 0.1))
        {
            anim.SetTrigger("attack_move");
        }
    }

}