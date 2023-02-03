using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBehavior : MonoBehaviour
{

    public GameObject resorsePrefeb;
    public GameObject roots;
    public int spawnRange = 100;
    public int spawnGap = 10;
    public int numPerSpawn = 2;


    private int lowBound = 0;
    private int highBound = 0;


    // Start is called before the first frame update
    void Start()
    {


        highBound = spawnGap;

    }

    // Update is called once per frame
    void Update()
    {


        while (highBound <= spawnRange)
        {
            // spawn n obj per hollow
            int n = numPerSpawn;
            while (n > 0)
            {
                float x = 0;
                float y = 0;
                float dist = 0;

                // check if in hollow
                while (dist <= lowBound || dist >= highBound)
                {
                    x = Random.Range((highBound + spawnGap) * -1, highBound + spawnGap);
                    y = Random.Range((highBound + spawnGap) * -1, highBound + spawnGap);
                    dist = Mathf.Sqrt(x * x + y * y);
                }

                //spawn resourse
                GameObject Resourse = GameObject.Find("/Resourse");
                GameObject obj = Instantiate(resorsePrefeb, roots.transform.position + new Vector3(x, y, 0), Quaternion.identity) as GameObject;


                //Debug.Log("spawned at: " + x + " " + y);
                n--;
            }

           
            // enlarge hollow
            highBound += spawnGap;
            lowBound += spawnGap;


        }
    }
}
