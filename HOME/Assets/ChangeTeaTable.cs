using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTeaTable : MonoBehaviour
{
    Button[] button;
    GameObject newGameObject;

    // Start is called before the first frame update
    void Start()
    {
        button = transform.GetComponentsInChildren<Button>();
        newGameObject = GameObject.Find("NewGameObject");

        button[0].onClick.AddListener(()=> {
            GameObject go = GameObject.FindWithTag("TeaTable");
            Instantiate(Resources.Load<GameObject>("Prefabs/TeaTable0"), newGameObject.transform);
            Destroy(go);
        });
        button[1].onClick.AddListener(()=> {
            GameObject go = GameObject.FindWithTag("TeaTable");
            Instantiate(Resources.Load<GameObject>("Prefabs/TeaTable1"), newGameObject.transform);
            Destroy(go);
        });
        button[2].onClick.AddListener(() => {
            GameObject go = GameObject.FindWithTag("TeaTable");
            Instantiate(Resources.Load<GameObject>("Prefabs/TeaTable2"), newGameObject.transform);
            Destroy(go);
        });
        button[3].onClick.AddListener(() => {
            GameObject go = GameObject.FindWithTag("TeaTable");
            Instantiate(Resources.Load<GameObject>("Prefabs/TeaTable3"), newGameObject.transform);
            Destroy(go);
        });
    }
}
