using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soild : MonoBehaviour
{
   public GameObject mon;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.tag);
        if (collision.tag == "Monster")
        {
            Monster monster = mon.GetComponent<Monster>();
            print(monster);
            monster.Hp-=4;
            print("命中");
        }
    }
}
