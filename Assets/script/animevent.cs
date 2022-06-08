using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animevent : MonoBehaviour
{
    public Animator myanim;
    // Start is called before the first frame update
    void Start()
    {
        myanim = GetComponent<Animator>();
    }

    public void stopattack()
    {
        print("jump");
        myanim.SetBool("attacking", false);
    }
}
