using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class npctrriger : MonoBehaviour
{
    public string Point;
    private GameObject R;
    private GameObject Dia;
    private bool on = false;

    void Start()
    {
        R = GameObject.Find(Point + "/Canvas/R");
        Dia = GameObject.Find(Point + "/dialog/Canvas");
        on = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            on = true;
            R.SetActive(true);
            print("bossdialog");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            on = false;
            R.SetActive(false);
        }
    }
     void Update() {
        if (on&&Input.GetKeyDown(KeyCode.R))
        {
            Dia.SetActive(true);
        }
    }
    public void DayScene()
    {
        SceneManager.LoadScene(0);
        print(SceneManager.sceneCount);

    }
}
