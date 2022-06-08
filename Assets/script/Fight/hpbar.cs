using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpbar : MonoBehaviour
{
    public Texture back;//背景图

    public Texture fore;//前景图

    private float scale_height = 0.99f;

    private float width;

    private float height;

    private float position_left;

    private float position_top;
    // Start is called before the first frame update
    void Start()
    {
        position_left = transform.localPosition.x;
        position_top = transform.localPosition.y;
        width = transform.GetComponent<Renderer>().bounds.size.x;
        height = transform.GetComponent<Renderer>().bounds.size.y;
        print(position_left);
    }

    // Update is called once per frame
    void Update()
    {
        OnGUI();
    }

    void OnGUI()

    {


        GUI.DrawTexture(new Rect(position_left, position_top, back.width, back.height), back);

        //GUI.DrawTexture (new Rect (500, 300, fore.width, fore.height), fore);



        if (Input.GetKeyUp(KeyCode.Space))
        {
            scale_height = scale_height - 0.01f;

            if (scale_height < 0)

                scale_height = 0;

        }

        GUI.Label(new Rect(0, 0, 100, 100), "scale_height" + scale_height);

        GUI.DrawTextureWithTexCoords(new Rect(position_left, position_top + back.height * (1 - scale_height), fore.width, fore.height * scale_height), fore,

        new Rect(0, 0, 1, scale_height), true);

    }

}
