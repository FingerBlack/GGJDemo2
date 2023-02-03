using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBehavior : MonoBehaviour
{

    public GameObject resorsePrefeb;
    public GameObject roots;
    public int spawnRange = 100;
    public int spawnGap = 10;
    public int numPerSpawn = 1;
    public int minBlockPerSide = 10;
    public int blockSizeIncreaseRate = 2;


    private int lowBound = 0;
    private int highBound = 0;
    private float resourseBlockLength = 0;


    // Start is called before the first frame update
    void Start()
    {


        highBound = spawnGap;
        resourseBlockLength = resorsePrefeb.transform.localScale.x;
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
                for(int i = 0; i < minBlockPerSide; i++)
                {
                    for (int j = 0; j < minBlockPerSide; j++)
                    {
                        GameObject obj = Instantiate(resorsePrefeb, roots.transform.position + new Vector3(x+i* resourseBlockLength, y+j* resourseBlockLength, 0), Quaternion.identity) as GameObject;
                    }
                }
                //GameObject obj = Instantiate(resorsePrefeb, roots.transform.position + new Vector3(x, y, 0), Quaternion.identity) as GameObject;


                //Debug.Log("spawned at: " + x + " " + y);
                n--;
            }

           
            // enlarge hollow
            highBound += spawnGap;
            lowBound += spawnGap;

            minBlockPerSide+=blockSizeIncreaseRate;


        }
    }
}
