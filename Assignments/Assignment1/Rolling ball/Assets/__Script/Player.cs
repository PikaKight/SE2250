using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public float speed;

    public TextMeshProUGUI scoreText;
    
    public GameObject winTextObject;

    private Rigidbody rb;

    private int score;
    private int winScore = 24;

    private float moveX, moveY;

    private float restartDelay = 5f;


    void Start(){
        
        rb = GetComponent<Rigidbody>();
        winTextObject.SetActive(false);
        score = 0;
        SetScoreText();
    }

    void FixedUpdate(){
        Vector3 movement = new Vector3(moveX, 0.0f, moveY);
        rb.AddForce(movement * speed);
        
    }

    void OnMove(InputValue movementValue){
        Vector2 movementVector = movementValue.Get<Vector2>();

        moveX = movementVector.x;
        moveY = movementVector.y;
    }
    
    //sets the score 
    void SetScoreText(){
        scoreText.text = "Score: " + score.ToString();
        if (score >= winScore){
            winTextObject.SetActive(true);

            Invoke("RestartGame", restartDelay);
        }
    }
    
    //if the player is colliding with the item, that item will disapear and score will update
    private void OnTriggerEnter(Collider other){

        if(other.gameObject.CompareTag("Small Item")){
            other.gameObject.SetActive(true);
            score += 1;
            SetScoreText();
            Destroy(other.gameObject);
        }

        else if(other.gameObject.CompareTag("Med Item")){
            other.gameObject.SetActive(false);
            score += 2;
            SetScoreText();
            Destroy(other.gameObject);
        }
        
        else if(other.gameObject.CompareTag("Large Item")){
            other.gameObject.SetActive(false);
            score += 3;
            SetScoreText();
            Destroy(other.gameObject);
        }

    }

    void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}


