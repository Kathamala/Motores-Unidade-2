using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public GameObject gameScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(gameScript.GetComponent<GameScript>().getCurrentStage() == 1){
                if(gameScript.GetComponent<GameScript>().getScore() >= gameScript.GetComponent<GameScript>().pointsToCompleteStage1){
                    gameScript.GetComponent<GameScript>().setCurrentStage(2);
                    SceneManager.LoadScene("Stage2");
                } else {
                    gameScript.GetComponent<GameScript>().toaster.GetComponent<ToastMessages>().showToast("Epa, ainda não né rapaz. Tá faltando moeda aí que eu tô ligado...", 5);
                }
            } else if(gameScript.GetComponent<GameScript>().getCurrentStage() == 2){
                if(gameScript.GetComponent<GameScript>().getScore() >= gameScript.GetComponent<GameScript>().pointsToCompleteStage2){
                    gameScript.GetComponent<GameScript>().setCurrentStage(2);                    
                    SceneManager.LoadScene("SampleScene");
                } else {
                    gameScript.GetComponent<GameScript>().toaster.GetComponent<ToastMessages>().showToast("Epa, ainda não né rapaz. Tá faltando moeda aí que eu tô ligado...", 5);
                }
            }

        }
    }
}
