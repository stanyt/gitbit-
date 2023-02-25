using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    [Header("死亡变量")]
    public GameObject canvas_after;
    public GameObject leftborder;

    [Header("其他变量")]
    public int FallSpeed;
    public int attackCount=0;
    public int BackSpeed = 10;
    private Rigidbody2D monsrigid2D;
    private float attackRange;
    public int moveSpeed;
    public Transform left;
    public Transform Playerpos;
    public Transform Monpos;
    private Animator animmon;
    public Image hpimg;
    public int Hp = 100;
    public int waitingTime=1;
    public float waiting=0;
    private GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("FirstPoint/dialog/Canvas");
        Hp = 1;
        monsrigid2D = GetComponent<Rigidbody2D>();
        monsrigid2D.velocity = new Vector3(0, -FallSpeed * Time.deltaTime, 0);
        attackRange = Mathf.Abs(left.position.x - transform.position.x);
        animmon = gameObject.GetComponent<Animator>();
    }

    [System.Obsolete]
    void Update()
    {
        setHpBar();
        FaceToplayer();
        MoveToPlayer();
        attack();
    }
    void attack()
    {
        AnimatorStateInfo animatorInfo;
        animatorInfo = animmon.GetCurrentAnimatorStateInfo(0);  //要在update获取
        if (animmon.GetBool("attacking") && Mathf.Abs(Playerpos.position.x - transform.position.x) <= attackRange)
        {
            APlayer player = Playerpos.gameObject.GetComponent<APlayer>();
            player.Hp--;
            //player.myrigid2D.velocity = new Vector2(-Monpos.transform.localScale.x * BackSpeed, 0);
        }

        if (Mathf.Abs(Playerpos.position.x - transform.position.x) <= attackRange)
        {

            waiting += Time.deltaTime;
            if (waiting > waitingTime)
            {
                animmon.SetBool("attacking", true);
                waiting = 0;
                attackCount++;
                
            }
            else if(animatorInfo.normalizedTime > 1.0f&& animmon.GetBool("attacking"))
                {
                    animmon.SetBool("attacking", false);
                }
        
        }
        else if (animmon.GetBool("attacking"))
        {
            waiting = 0;
            animmon.SetBool("attacking", false);
        }
    } 
    void FaceToplayer()
    {
        if((Playerpos.position.x - transform.position.x) >= 0)//在Boss右边
        {
            Monpos.transform.localScale = new Vector3(-1,1, 1);
        }
        else//在Boss左边
        {
            Monpos.transform.localScale = new Vector3(1,1, 1);

        }
    }
    void setHpBar()
    {
        hpimg.fillAmount = Hp * 0.01f;
        if (Hp < 0.2f)
        {
            death();
        }
    }

    [System.Obsolete]
    void MoveToPlayer()
    {
        //print(GameObject.Find("FirstPoint/dialog/Canvas").active);
        if(Mathf.Abs(Playerpos.position.x - transform.position.x) > attackRange&& monsrigid2D.velocity.y==0&&!canvas.active)
        {
            animmon.SetBool("walking", true);
            monsrigid2D.velocity = new Vector2(-Monpos.localScale.x * moveSpeed * Time.deltaTime,0);
            if(Mathf.Abs(Playerpos.position.x - transform.position.x) <= attackRange)
            {
                animmon.SetBool("walking", false);
            }
            else if (Mathf.Abs(monsrigid2D.velocity.x) < 0.1)
            {
                animmon.SetBool("walking", false);

            }
            else
                animmon.SetBool("walking", true);
        }
        else
        {
            animmon.SetBool("walking", false);
        }
    }
    void death()
    {
        
    }
}
