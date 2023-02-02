using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elves : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public Node node;
    public float speed;
    public List<int> Level = new List<int>{ 0, 3, 9,27,81,243,729,2187,6561,19683};

    void Start()
    {
        speed=1f;
        node=target.GetComponent<Node>();

    }

    // Update is called once per frame
    void Update()
    {   
        node=target.GetComponent<Node>();
        float dis=Vector3.Distance(transform.position,target.transform.position);

        if(dis>0.1f){
            transform.position=Vector3.MoveTowards(transform.position,target.transform.position,speed*Time.deltaTime);
        }else{

            
            int times=0;
            while(true){
                times++;
                if(times>100){
                    break;
                    
                }
                if(node.Neighbors.Count==0){
                    return;
                }
                int element = Random.Range(0,node.Neighbors.Count); 
                
                GameObject edge=node.Neighbors[element];
                float Dice =Random.Range(0f,1f);
                Edge e=edge.GetComponent<Edge>();
                //Debug.Log(element+" "+e.possibility/node.total);
                if(Dice <(e.possibility+Level[e.guidline])/node.total){
                    //Debug.Log(target+" "+e.start);
                    if(target!=e.start){
                        target=e.start;

                    }else{
                        target=e.end;
                    }
                    break;
                }
            }
        }
    }
}
