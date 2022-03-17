using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    [Header("Set in Inspector: Enemy")]
    public float speed = 10f;
    public float fireRate = 0.3f;
    public float health = 10;

    public float rotation = 0;
    // Start is called before the first frame update
    BoundsCheck bndCheck;

    

    void Awake(){
        bndCheck = GetComponent<BoundsCheck>();
    }

    public Vector3 pos{
        get{
            return (this.transform.position);
        }
        set{
            this.transform.position = value;
        }
    }

    // Update is called once per frame
    void Update()
    {   
        
        Move(Random.Range(0,1) * 2 -1);

        if (bndCheck != null && bndCheck.offBot){
            Destroy(gameObject);
        }
    }

    public virtual void Move(int rnd){

        print(rnd);
        Vector3 tempPos = pos;
        
        //Checks if the enemy is off the screen on the side and changes the x direction if it is
        if (bndCheck != null && bndCheck.offLeft || bndCheck.offRight){
            this.rotation *= -1;
            bndCheck.offLeft = bndCheck.offRight = false;
            
            rnd = 1;
        }

        //changes the x and y position based off of speed, time and angle of movement
        tempPos.x -= speed*Time.deltaTime*(Mathf.Sin(rotation*(Mathf.PI/180)*rnd));
        tempPos.y -= speed*Time.deltaTime;
        
        //sets the new positition
        pos = tempPos;
    }
}
