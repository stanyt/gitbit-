using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Fight1 : MonoBehaviour
{
    public GameObject Boss ;
    public Transform Player ;
    public FSM FSM;
    public PolygonCollider2D night1;
    public PolygonCollider2D night2;
    public CinemachineConfiner camconf;
    bool deathboss = false;
    // Start is called before the first frame update
    void Start()
    {
        camconf.m_BoundingShape2D = night1;
        FSM = Boss.GetComponent<FSM>();
        deathboss = false;
    }

    // Update is called once per frame
    void Update()
    {
        afterDeath();
    }
    void afterDeath()
    {
       
        
        if (FSM.currentState == FSM.states[StateType.Death])
        {
            deathboss = true;
        }
        if (deathboss)
        {
            StartCoroutine(Destroyobj());
            
        }

    }
   IEnumerator Destroyobj()
    {
        yield return new WaitForSeconds(2.5f);
        GameObject dialogafter= GameObject.Find("AfterFight/dialog/Canvas");
        dialogafter.SetActive(true);
        dialogafter.transform.position = new Vector2(Player.position.x, dialogafter.transform.position.y);
        camconf.m_BoundingShape2D = night2;
        deathboss = false;
        Destroy(gameObject);
    }
}
