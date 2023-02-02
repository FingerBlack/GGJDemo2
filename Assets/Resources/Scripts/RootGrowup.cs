using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootGrowup : MonoBehaviour
{
    // Start is called before the first frame update
    public int Basic=100;
    public int originalToal=100;
    public int Total=0;
    public Vector3 originalElvesScale;
    public Vector3 originalScale;
    public int  resourceslimit;
    void Start()
    {
        Basic=10;
        Total=0;
        originalToal=10;
        GameObject elves=Resources.Load("Prefabs/Elf") as GameObject;
        originalElvesScale=elves.transform.localScale;
        originalScale=transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {    
        float scale=(float)(Basic+Total)/originalToal;
        foreach (Transform cld in GameObject.Find("Roots/Elves").transform)
        {
            if(cld.gameObject.TryGetComponent<Elves>(out Elves a)){
                cld.transform.localScale=new Vector3(originalElvesScale.x/scale,originalElvesScale.y/scale,originalElvesScale.z);
            }
        }
        transform.localScale=new Vector3(originalScale.x*scale,originalScale.y*scale,originalScale.z);
    }
}
