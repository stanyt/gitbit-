using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum StateType
{
    Idle, Patrol, Chase, React, Attack, Hit,Death,Tkey,TValue
}

[Serializable]
public class Parameter
{
    public int health = 15;
    public float moveSpeed;
    public float chaseSpeed;
    public float idleTime;
    public Transform[] patrolPoints;
    public Transform[] chasePoints;
    public Transform target;
    public LayerMask targetLayer;
    public Transform attackPoint;
    public float attackArea;
    public Animator animator;
    public bool getHit;
    public GameObject GetHit;
    public GameObject HitPlayer;

//对话结束后！！！！！！！！！！！！！！！！！！！！！！
[Header("boss 的血条的Image")]//放这里
    public Image image;




    /*额外添加*/
    public GameObject leftborder;
    public GameObject Dial;
    public Dialog dialog;

}
public class FSM : MonoBehaviour
{
    public bool getValue = false;
    public IState currentState;
    public Dictionary<StateType, IState> states = new Dictionary<StateType, IState>();

    public Parameter parameter;
    void Start()
    {
        states.Add(StateType.Idle, new IdleState(this));
        states.Add(StateType.Patrol, new PatrolState(this));
        states.Add(StateType.Chase, new ChaseState(this));
        states.Add(StateType.React, new ReactState(this));
        states.Add(StateType.Attack, new AttackState(this));
        states.Add(StateType.Hit, new HitState(this));
        states.Add(StateType.Death, new DeathState(this));
       
        TransitionState(StateType.Idle);


        changeValue();
        parameter.animator = transform.GetComponent<Animator>();
    }

    void Update()
    {
        currentState.OnUpdate();

        if (parameter.GetHit.activeSelf)//受到伤害
        {
            parameter.getHit = true;
        }
        Death();
    }

    public void TransitionState(StateType type)
    {
        if (currentState != null)
            currentState.OnExit();
        currentState = states[type];
        currentState.OnEnter();
    }

    public void FlipTo(Transform target)
    {
        if (target != null)
        {
            if (transform.position.x >= target.position.x)
            {
                transform.localScale = new Vector3(0.8f,0.8f,0.8f );
            }
            else if (transform.position.x <= target.position.x)
            {
                transform.localScale = new Vector3(-0.8f,0.8f,0.8f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            parameter.target = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            parameter.target = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(parameter.attackPoint.position, parameter.attackArea);
    }
    
    IEnumerator disenable()
    {
       
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);

    }

    void Death()
    {
        if (currentState == states[StateType.Death])
        {
            StartCoroutine(disenable());
        }

    }
    void changeValue()
    {
        parameter.dialog = parameter.Dial.GetComponent<Dialog>();
        if (!getValue)
        {
            if (Dialog.option == 1)
            {
                parameter.health = 25;
            }else if (Dialog.option == 2)
            {
                parameter.health = 18;
            }
            else
            {
                parameter.health = 20;
            }
            getValue = true;
        }
        
    }

}