using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Dialog : MonoBehaviour
{
    [Header("UI")]
    public Image headImg;
    public Sprite monsterimg;
    public Sprite liu;
    public Sprite Player;
    public Sprite ma;
    public Sprite wang;
    public Text text;
    public Text diaName;
    [Header("File")]
    //public string Point;
    public TextAsset textfile;
    private List<string> vs=new List<string>();
    [Header("数值")]
    public float textdelay = .1f;
    public int current = 0;
    public bool isFinish = false;
    public bool textFinish = false;
    public bool istyping ;
    public bool afterGame ;
    [Header("选项")]
   static public int option=0;
    GameObject op1;
    GameObject op2;
    GameObject boss;
    public GameObject L;
    void Start()
    {
        boss = GameObject.Find("Bossfind/GameObject/Boss");
        istyping = false;
        isFinish = false;
        afterGame = false;
        gettextfromfile(textfile);
        StartCoroutine(printByTime());
        initopt();
        // text.text = vs[current++];
        //Dialogkuang = GameObject.Find(Point + "/dialog/Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        Print();
    }

    void Print()
    {
        if (Input.GetKeyDown(KeyCode.E)&&isFinish)
        {   current = 0;
            text.text = vs[current++];
            isFinish = false;
            if (gameObject.tag == "finaldialog")
            {
                print("Test");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                afterGame = true;
            }else if (gameObject.tag == "switch1")
            {
                print("Test");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else if (gameObject.tag == "beforefight")
            {
                boss.SetActive(true);
            }
            else if (gameObject.tag == "enterSecondNight")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }else if(gameObject.tag== "enterThirdDay")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else if (gameObject.tag == "Final")
            {
                SceneManager.LoadScene(0);

            }
            else if(gameObject.tag== "Fisrfight")
            {
                GameObject.Find("Canvas/Panel/GameObject").SetActive(false);
            }

            gameObject.SetActive(false);
          
            
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (!istyping)
                {
                    print("点R的次数");
                    if(current>=vs.Count)
                    {
                        if (gameObject.tag=="switch1")
                        {
                            text.text = "按E进入客栈";
                        }else if (gameObject.tag == "enterSecondNight")
                        {
                            text.text = "按E进入夜晚";
                        }
                        else if (gameObject.tag == "Final")
                        {
                            text.text = "按E结束游戏";
                        }
                        else
                        {
                            text.text = "按E退出对话";
                        }
                            
                        isFinish = true;
                    }
                    else if(vs[current].Length>=1&&vs[current][0] == 's')
                    {
                        op1.SetActive(true);
                        op2.SetActive(true);
                        vs[current]="c";
                    }else if(vs[current].Length>=1&&vs[current][0] == 'h')
                    {
                        vs[current] = "";
                        Destroy(L);
                    }
                    else if (vs[current].Length >= 1 && vs[current][0] == 'c')
                    {
                        if (option == 1)
                        {
                            vs[current] = "刘:";
                            vs[current + 1] = "朝廷哪有兵马来？";
                            vs[current + 2] = "薛:";
                            vs[current + 3] = "我消灭了那妖怪，自然就不需要朝廷的兵马了。";
                        }
                        else if (option == 2)
                        {
                            vs[current] = "刘:";
                            vs[current + 1] = "难道你已经杀掉他了？";
                            vs[current + 2] = "薛:";
                            vs[current + 3] = "没能杀掉他。不过今晚估计就可以取他性命。";
                        }
                    }
                    else if (current < vs.Count)
                    {
                        StartCoroutine(printByTime());
                    }
                    
                }
                else
                {
                    text.text = vs[current];
                    textFinish = true;
                }
            }
        }
    }

    public void gettextfromfile(TextAsset textAsset)
    {
        vs.Clear();
        var strs= textfile.text.Split('\n');
        foreach (var str in strs){
            vs.Add(str);
        }
        print(vs[0]);
        current = 0;
    }

    IEnumerator printByTime()
    {
        
        istyping = true;
        textFinish = false;
        if(vs[current].Length >1)
        {
            switch (vs[current][0])
            {
          
                case '妖':
                    diaName.text = "帽妖";
                    headImg.sprite = monsterimg;
                    current++; 
                    break;
                case '薛':
                    diaName.text = "薛获麟";
                    headImg.sprite = Player;
                    current++;
                    break;
                case '马':
                    diaName.text = "马掌柜";
                    current++;
                    headImg.sprite = ma;
                    break;
                case '王':
                    diaName.text = "王重五";
                    current++;
                    headImg.sprite = wang;
                    break;
                case '刘':
                    diaName.text = "刘县令";
                    current++;
                    headImg.sprite = liu;
                    break;
            }
        }
        
        print(istyping);
        text.text = "";
        
        for(int i = 0; i < vs[current].Length-1&& !textFinish; i++)
        {
            text.text += vs[current][i];
            yield return new WaitForSeconds(textdelay);
        }
        current++;
        istyping = false;
    }
    void initopt()
    {
        op1 = GameObject.Find("刘知县有选项的/dialog/Canvas/选项1");
        op2 = GameObject.Find("刘知县有选项的/dialog/Canvas/选项2");
    }
}
