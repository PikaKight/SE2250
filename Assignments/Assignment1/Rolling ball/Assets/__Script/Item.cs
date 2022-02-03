using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        transform.Rotate(new Vector3(15,30,45) * Time.deltaTime);
    }

    private void OnTriggerCollissionCheck(Collider other){
        if(other.gameObject.CompareTag("Small Item")){
            gameObject.SetActive(false);
            transform.Translate(1f,0f,1f);
            gameObject.SetActive(true);
        }

        else if(other.gameObject.CompareTag("Med Item")){
            gameObject.SetActive(false);
            transform.Translate(1f,0f,1f);
            gameObject.SetActive(true);
        }
        
        else if(other.gameObject.CompareTag("Large Item")){
            gameObject.SetActive(false);
            transform.Translate(1f,0f,1f);
            gameObject.SetActive(true);
        }
    }
}
