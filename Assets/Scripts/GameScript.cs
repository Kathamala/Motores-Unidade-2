using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    static int lives = 3;
    static float score = 0f;
    static int currentStage;

    public Text scoreText;
    public Text livesText;

    public GameObject toaster;
    public GameObject player;

    public int pointsToCompleteStage1 = 610;
    public int pointsToCompleteStage2 = 0;

    private bool checkCoinText = false;
    private bool checkRunText = false;
    private bool checkCrazyPlatform = false;
    // Start is called before the first frame update
    void Start()
    {
        toaster.GetComponent<ToastMessages>().showToast("Eae rapaz, beleza! Este é o ULTIMATE NINJA COIN COLLECTOR 3D 4K 1080P FULL HD TORRENT DUBLADO LEGENDADO. Primeiramente, vai usando o WSAD pra mexer o ninja. Também pode usar o mouse pra movimentar a câmera.", 10);
        currentStage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;

        if(currentStage == 1){
            if(player.GetComponent<PlayerScript>().collisionWithFirstCoin && !checkCoinText){
                checkCoinText = true;
                toaster.GetComponent<ToastMessages>().showToast("Brabo demais! Você coletou uma moeda! Ela vai te dar pontos. Não esqueça de coletar todas as moedas para poder passar de fase.", 7);
            }

            if(player.transform.position.z > 25 && !checkRunText){
                checkRunText = true;
                toaster.GetComponent<ToastMessages>().showToast("Fica ligado que se tu segurar o SHIFT ESQUERDO, você corre! Ah, e é bom tomar cuidado com esses vazio infinito aí em baixo. Se tu cair aí, tu perde uma vida.", 7);
            }

            if(player.transform.position.z > 115 && !checkCrazyPlatform){
                checkCrazyPlatform = true;
                toaster.GetComponent<ToastMessages>().showToast("O que era pra ser isso, na moral?", 7);
            }            
        }

        if(lives < 0){
            SceneManager.LoadScene(0);
            lives = 3;
        }

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

    public int getCurrentStage(){
        return currentStage;
    }

    public void setCurrentStage(int newStage){
        currentStage = newStage;
    }
}
