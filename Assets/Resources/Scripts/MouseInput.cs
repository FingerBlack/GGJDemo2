using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{   
    
    public float a;
    
    public float c;

    int[] b = new int[]{ 60,120 };
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Vector3 screenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
 
            //Physics2D.OverlapCircle
            ContactFilter2D filter = new ContactFilter2D().NoFilter();
            List<Collider2D> results = new List<Collider2D>();
            Physics2D.OverlapCircle( Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.01f,filter,results);
            Debug.Log(Input.mousePosition);
            bool flag=false;

            foreach( Collider2D result in results)
            {
                Debug.Log(result.gameObject);
                if(result.gameObject.TryGetComponent<Node>(out Node node)){
                    // float dis=Vector3.Distance((edge.start.transform.position+edge.end.transform.position)/2.0f,Camera.main.ScreenToWorldPoint(Input.mousePosition));
                    // dis-=30f;
                    node.Growth();
                    flag=true;
                    break;
                }
                

                
            }
            if(!flag){
                foreach( Collider2D result in results)
                {
                    if(result.gameObject.TryGetComponent<Edge>(out Edge edge)){
                        // float dis=Vector3.Distance((edge.start.transform.position+edge.end.transform.position)/2.0f,Camera.main.ScreenToWorldPoint(Input.mousePosition));
                        // dis-=30f;
                        if(edge.guidline<9)
                            edge.guidline+=1 ;
                        break;
                    }
                }
            }    
            

        }
        if (Input.GetMouseButtonDown(1))
        {
            //Vector3 screenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
 
            //Physics2D.OverlapCircle
            ContactFilter2D filter = new ContactFilter2D().NoFilter();
            List<Collider2D> results = new List<Collider2D>();
            Physics2D.OverlapCircle( Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.01f,filter,results);
            Debug.Log(Input.mousePosition);
            foreach( Collider2D result in results)
            {
                Debug.Log(result.gameObject);
                if(result.gameObject.TryGetComponent<Edge>(out Edge edge)){
                    // float dis=Vector3.Distance((edge.start.transform.position+edge.end.transform.position)/2.0f,Camera.main.ScreenToWorldPoint(Input.mousePosition));
                    // dis-=30f;
                    if(edge.guidline>0)
                        edge.guidline-=1;
                }
                
            }
                
            

        }

    }
}
