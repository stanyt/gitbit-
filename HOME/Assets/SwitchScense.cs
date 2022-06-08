using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwitchScense : MonoBehaviour
{
    public string sceneWillGo;

    // Use this for initialization
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        SceneManager.LoadScene(sceneWillGo);//要切换到的场景
    }
}

