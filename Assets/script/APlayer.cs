using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;


public class APlayer : MonoBehaviour
{
    [Header("变量")]
    public float moveSpeed, JumpForce;
    //public Transform trans;
    public Transform Sword;
    public Rigidbody2D myrigid2D;
    public float moveForce = 10;
    public Animator myanim;
    public CircleCollider2D coll2D_c;
    public LayerMask ground;

    public GameObject attackHit;
    public GameObject Boss;
    public GameObject GetHit;


    private float inputX;
    private bool isGround=true;
    public float checkRadius;
    public Transform checkArea;



    public bool Isdead;
    [Header("可更改的")]
    public float Hp=100;
    // Start is called before the first frame update
    void Start()
    {
        myrigid2D = gameObject.GetComponent<Rigidbody2D>();
        myanim = GetComponent<Animator>();
        Isdead = false;
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        isGround = Physics2D.OverlapCircle(transform.position, checkRadius, ground);

        attack();
        jump();
        getHit();
        move();
    }
    private void FixedUpdate()
    {  

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(checkArea.position,checkRadius);
    }
    void jump()
    {
        if (Input.GetButtonDown("Jump")&&isGround )
        {
            myrigid2D.velocity = new Vector2(0, JumpForce);
            myanim.SetTrigger("Jump");
        }
    }
    /*void setAnim()
    {
        if (myrigid2D.velocity.y < 0 && !coll2D_c.IsTouchingLayers(ground))
        {
            myanim.SetBool("jumping", false);
            myanim.SetBool("falling", true);
        }
        else if (coll2D_c.IsTouchingLayers(ground) && myanim.GetBool("falling"))
        {
            myanim.SetBool("falling", false);
            myanim.SetBool("jumping", false);
        }
    }
    void move()
    {
        float xxx = Input.GetAxisRaw("Horizontal");
        myrigid2D.velocity = new Vector2(xxx * moveForce * Time.deltaTime, myrigid2D.velocity.y);
        //print(myrigid2D.velocity.x);
        if (Mathf.Abs(myrigid2D.velocity.x) < 0.1)
        {
            myanim.SetBool("walking", false);

        }
        else
            myanim.SetBool("walking", true);
        if (xxx != 0)
        {
            transform.localScale = new Vector3(xxx, 1, 1);
        }
    }
*/
    private void move()
    {
        if (inputX == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (inputX == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        myrigid2D.velocity = new Vector2(inputX * moveSpeed, myrigid2D.velocity.y);

        myanim.SetBool("isGround", isGround);
        myanim.SetFloat("Horizontal", myrigid2D.velocity.x);
        myanim.SetFloat("Vertical", myrigid2D.velocity.y);
    }
    void attack()
    {
        AnimatorStateInfo animatorInfo;
        animatorInfo = myanim.GetCurrentAnimatorStateInfo(0);  //要在update获取

        //if (Input.GetMouseButtonDown(0))
        if (Input.GetKeyDown(KeyCode.F))
        {
            print("attack");
            myanim.SetBool("attacking", true);
            print(animatorInfo.length);
            print(animatorInfo.normalizedTime);
            if (animatorInfo.normalizedTime > 0.4f)
            {
                print("noproblem");
            }
            if(System.Math.Abs(Boss.transform.position.x-this.transform.position.x)<=4)
            {
                attackHit.SetActive(true);
            }
            
        }
        if(animatorInfo.normalizedTime>0.4f&& animatorInfo.IsName("Attack"))
        {
            print("false");
            myanim.SetBool("attacking", false);
            attackHit.SetActive(false);
        }


        /*第二套攻击
        if (Input.GetKeyDown(KeyCode.G))
        {
            myanim.SetBool("attacking", true);
        }*/

    }

    public void death()
    {
        myanim.SetBool("dead", true);
        Invoke("Idead", 2f);
    }
    void getHit()
    {
        if(GetHit.activeSelf)
        {
            Hp-=0.1f;
        }
        if(Hp==0)
        {
            death();
        }
    }
    void Idead()
    {
        SceneManager.LoadScene(0);
    }



}
