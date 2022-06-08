using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class hpBar : MonoBehaviour
{
    public Image Hpimg;
    //public Image Hping2;
    // Start is called before the first frame update
    private Parameter parameter;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        setHpBar();
    }
    void setHpBar()
    {   
        APlayer aPlayer = gameObject.GetComponent<APlayer>();
        Hpimg.fillAmount =aPlayer.Hp * 0.025f;
        if (aPlayer.Hp < 0)
        {
            aPlayer.Isdead = true;
            aPlayer.death();
        }
    }
}
