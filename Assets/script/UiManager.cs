/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiManager : MonoBehaviour
{
    [Header("UI")]
    public Image headImg;
    public Text text;
    [Header("File")]
    //public string Point;
    public TextAsset textfile;
    private List<string> vs = new List<string>();
    public int current = 0;
    public bool isFinish = false;
    //private GameObject Dialogkuang;
    // Start is called before the first frame update
    void Start()
    {
        isFinish = false;
        current = 0;
        gettextfromfile(textfile);
        text.text = vs[current++];
        //Dialogkuang = GameObject.Find(Point + "/dialog/Canvas");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && isFinish)
        {
            current = 0;
            text.text = vs[current++];
            isFinish = false;
            //Dialogkuang.SetActive(false);

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (current < vs.Count)
                {
                    text.text = vs[current++];
                }
                else
                {
                    text.text = "按E退出对话";
                    isFinish = true;

                }
            }
        }
    }


    public void gettextfromfile(TextAsset textAsset)
    {
        vs.Clear();
        var strs = textfile.text.Split('\n');
        foreach (var str in strs)
        {
            vs.Add(str);
        }
        print(vs[0]);
        current = 0;
    }

}
*/