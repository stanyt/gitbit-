using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiTrigger : MonoBehaviour
{
    public string Point;
    private GameObject Dialogkuang;

    void Start()
    {
        Dialogkuang = GameObject.Find(Point + "/dialog/Canvas");

        Dialog dialog = Dialogkuang.GetComponent<Dialog>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Dialogkuang.SetActive(true);
            print("bossdialog");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Dialogkuang.SetActive(false);
        }
    }
}
