using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    // Start is called before the first frame update
    public float possibility;
    public int guidline;
    public GameObject start;
    public GameObject end;
    public int TimeCount;
    public int TimePierod;
    public SpriteRenderer Sprite;
    void Start()
    {
        possibility=1f;
        guidline=0;
        TimePierod=30;
        Sprite=gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {       
        Sprite.color=new Color(1f-(guidline)/10f,1f-(guidline)/10f,1f-(guidline)/10f,255f);
        

        // TimeCount++;
        // if(TimeCount>TimePierod){
        //     TimeCount=0;
        //     if(guidline>=0){
        //         guidline*=0.99f;
        //     }
        // }
        
    }
}
