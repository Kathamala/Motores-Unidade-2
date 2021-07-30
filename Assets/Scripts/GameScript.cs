using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    private int lives = 3;
    private float score = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getLives(){
        return lives;
    }

    public void setLives(int l){
        lives = l;
    }

    public void decreaseLives(){
        lives--;
    }

    public void increaseLives(){
        lives++;
    }

    public float getScore(){
        return score;
    }

    public void setScore(float value){
        score = value;
    }

    public void addScore(float points){
        score += points;
    }
}
