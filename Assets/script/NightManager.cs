using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class NightManager : MonoBehaviour
{
    public int afterFight=1;
    public Monster Monster;
    public Transform Player;
    public Transform fir;
    public GameObject leftborder;
    public PolygonCollider2D night1;
    public PolygonCollider2D night2;
    private List<Transform> VS=new List<Transform>();
    public CinemachineConfiner camconf;
    bool master;

    // Start is called before the first frame update
    void Start()
    {
        Monster = gameObject.GetComponent<Monster>();
        camconf.m_BoundingShape2D = night1;
        master = false;
    }

    // Update is called once per frame
    void Update()
    {
        afterDeath();
    }
    void afterDeath()
    {
        if (Monster.Hp <= 0&& !master)
        {
            Destroy(leftborder);
            var trans =VS[afterFight] ;
            
            print(camconf.m_BoundingShape2D);
           var ob= GameObject.Find(afterFight +"/dialog/Canvas");
            if (afterFight == 1)
            {
                var ob2= GameObject.Find(afterFight + "/dialog/extra");
                ob2.SetActive(true);
            }
            print(afterFight++);
            print(ob);
            ob.SetActive(true);
            
            print(ob);
            
            camconf.m_BoundingShape2D = night2;
            print("trans:"+trans.localPosition);
            master = true;
            
            Player.transform.position = new Vector2(trans.position.x, Player.position.y);
            
        }
       
    }
   
}
