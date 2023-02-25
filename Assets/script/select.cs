using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class select : MonoBehaviour
{
    public GameObject Dialog1;
    private Dialog dialog;
    public GameObject otherOption;
    void Start()
    {
        dialog = Dialog1.GetComponent<Dialog>();
    }
    public void click1()
    {
        Dialog.option = 1;
        Destroy(gameObject);
        Destroy(otherOption);
    }
    public void click2()
    {

        Dialog.option = 2;
        Destroy(gameObject);
        Destroy(otherOption);

    }
}
