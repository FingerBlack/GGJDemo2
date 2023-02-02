using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeFormation : MonoBehaviour
{   
    public GameObject Target;
    Rigidbody2D rigidbody2d;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = rigidbody2d.position;
        Vector2 positionTarget = Target.transform.position;
        if(positionTarget.x > position.x){
            
            position.x = position.x +  speed * Time.deltaTime;
            
        }else if(positionTarget.x < position.x){
                position.x = position.x - speed * Time.deltaTime ;
            }

         if(positionTarget.y > position.y){
            
            position.y = position.y +  speed * Time.deltaTime;
            
        }else if(positionTarget.y < position.y){
                position.y = position.y - speed * Time.deltaTime ;
            }
        rigidbody2d.MovePosition(position);
    }
}
