using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    [Header("Set in Inspector")]

    public float radius = 1f;

    public bool keepOnScreen = true;

    [Header("Set Dynamically")]

    public bool isOnScreen = true;
    public float camWidth;

    public float camHeight;
    
    [HideInInspector]

    public bool offRight, offLeft, offTop, offBot;


    void Start() {
        
    }

    void Awake(){
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    
    }

    void LateUpdate(){
        Vector3 pos = transform.position;
        isOnScreen = true;
        offRight = offLeft = offTop = offBot = false;

        if (pos.x > camWidth - radius){
            pos.x = camWidth - radius;
            isOnScreen = false;
            offRight = true;
        }

        if (pos.x < -camWidth + radius){
            pos.x = -camWidth + radius;
            isOnScreen = false;
            offLeft = true;
        }

        if (pos.y > camHeight - radius){
            pos.y = camHeight - radius;
            isOnScreen = false;
            offTop = true;
        }

        isOnScreen = !(offRight||offLeft||offTop||offBot);

        if (pos.y < -camHeight + radius){
            pos.y = -camHeight + radius;
            isOnScreen = false;
            offBot = true;
        }

        if (keepOnScreen && !isOnScreen){
            transform.position = pos;
            isOnScreen = true;
            offRight = offLeft = offTop = offBot = false;
        }
    }
    // Start is called before the first frame update
    void OnDrawGizmos(){
        if (!Application.isPlaying) return;

        Vector3 boundSize = new Vector3(camWidth*2, camHeight*2,0.1f);
        Gizmos.DrawWireCube(Vector3.zero, boundSize);
    }
}
