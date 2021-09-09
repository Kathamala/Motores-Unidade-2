using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    //public InvetoryUI stageInventoryUI;
    //public static InvetoryUI inventoryUI;

    public static List<Item> items;

    static int lives = 2;
    static int score = 0;
    static int currentStage = 1;

    public Text scoreText;
    public Text livesText;

    public GameObject toaster;
    public GameObject player;

    public int pointsToCompleteStage1 = 610;
    public int pointsToCompleteStage2 = 0;

    private bool checkCoinText = false;
    private bool checkRunText = false;
    private bool checkCrazyPlatform = false;
    private bool checkFloor = false;
    // Start is called before the first frame update
    void Start()
    {
        if(score == 0){
            currentStage = 1;
            toaster.GetComponent<ToastMessages>().showToast("Eae rapaz, beleza! Este é o ULTIMATE NINJA COIN COLLECTOR 3D 4K 1080P FULL HD TORRENT DUBLADO LEGENDADO. Primeiramente, vai usando o WSAD pra mexer o ninja e Espaço para pular. Também pode usar o mouse pra movimentar a câmera.", 15);
            items = new List<Item>();
        } else{
            currentStage = 2;
            toaster.GetComponent<ToastMessages>().showToast("Hehehe, fase 2. O cara é bom.", 5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + (lives+1);

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
        } else if(currentStage == 2){
            if(player.transform.position.x > 93 && !checkFloor){
                checkFloor = true;
                toaster.GetComponent<ToastMessages>().showToast("Essas plataformas são difíceis. Se tiver com problema, tenta pular antes de começar a se movimentar. Ajuda a controlar melhor o ninja :)", 15);
            }  
        }

        if(lives < 0){
            lives = 4;
            score = 0;
            items = new List<Item>();
            SceneManager.LoadScene(0);
        }

    }

    public List<Item> getItemsList(){
        return items;
    }

    public void setItemsList(List<Item> itemsList){
        items = itemsList;
    }

/*
    public InvetoryUI getInventoryUI(){
        return inventoryUI;
    }

    public void setInventoryUI(InvetoryUI iUI){
        inventoryUI = iUI;
    }*/

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

    public int getScore(){
        return score;
    }

    public void setScore(int value){
        score = value;
    }

    public void addScore(int points){
        score += points;
    }

    public int getCurrentStage(){
        return currentStage;
    }

    public void setCurrentStage(int newStage){
        currentStage = newStage;
    }
}
