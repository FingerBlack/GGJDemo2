using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElvesSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public Vector3 Localposition;
    public float TimeCount;
    public float TimePeirod;
    public GameObject elf;
    public GameObject root;
    void Start()
    {
        TimeCount=0;
        TimePeirod=1f;
    }

    // Update is called once per frame
    void Update()
    {
        TimeCount+=Time.deltaTime;
        Localposition=new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f),0);
        
        if(TimeCount>TimePeirod){
            GameObject Elves=GameObject.Find("/Roots/Elves");
            if(Elves.transform.childCount>50){
                return;
            }
            GameObject obj=Instantiate(elf, transform.position, Quaternion.identity,Elves.transform) as GameObject;
            obj.GetComponent<Elves>().target=root;
            TimeCount=0;
        }
    }
}
