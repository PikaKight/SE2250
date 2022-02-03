using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject smallItem, medItem, largeItem;
    
    private int smallItemNum, medItemNum, largeItemNum;

    public float spawnDelay = 2;
    private float nextSpawnTime;

    void Start(){
        smallItemNum = 0;
        medItemNum = 0;
        largeItemNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        spawnItem();

    }

    private void spawnItem(){
        //next spawn time
        nextSpawnTime = Time.time + spawnDelay;
        //creates the randome number gen that gives the position and item type
        var rand = new System.Random();
        int itemNum = rand.Next(1,4);
        
        float x = RandomNum(-3,3);
        float z = RandomNum(-3,0);

        Vector3 position = new Vector3(x, 0.41f ,z);

        //creates the item based on rng
        if (itemNum == 1 && smallItemNum < 4){
            Instantiate(smallItem, position,  Quaternion.identity);
            smallItemNum += 1;
        }

        if (itemNum == 2 && medItemNum < 4){
            Instantiate(medItem, position,  Quaternion.identity);
            medItemNum += 1;  
        }
                
        if (itemNum == 3 && largeItemNum < 4){
            Instantiate(largeItem, position,  Quaternion.identity);
            largeItemNum += 1;
        }
    }

    float RandomNum(int min, int max){
        var rand = new System.Random();
        double val = rand.NextDouble() * (max-min) + min;
        print(val);
        return (float)val;
    
    }
}
