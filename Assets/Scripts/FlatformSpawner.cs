using System.Linq.Expressions;
using UnityEngine;
using System.Collections;


public class FlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public Transform lastPlatform;
    Vector3 lastPosition;
    Vector3 newPos;
    bool stop;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastPosition = lastPlatform.position;
        StartCoroutine(SpawnPlatforms());
     
    }

    // Update is called once per frame
    void Update()
    {


        //if (Input.GetKey(KeyCode.Space))
        //{
        //    SpawnPlatforms();
        //}
        }

    IEnumerator SpawnPlatforms()
    {
        while (!stop) 
        { 
        GeneratePosition();
        Instantiate(platform, newPos,Quaternion.identity);
        lastPosition = newPos;
            yield return new WaitForSeconds(0.1f);  
        }
         }    

    //void SpawnPlatforms()
    //{
        
    //}    
    void GeneratePosition()
    {
        newPos = lastPosition;
        int rand = Random.Range(0, 2);
        if (rand > 0)
        {
            newPos.x += 2f;
        }
        else { newPos.z += 2f; }
       
    }    
}
