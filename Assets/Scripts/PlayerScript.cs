using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject gameScript;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -8){
            gameScript.GetComponent<GameScript>().decreaseLives();
            gameObject.GetComponent<ThirdPersonMovement>().velocity = new Vector3(0, 0, 0);
            transform.position = new Vector3(0, 0, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            gameScript.GetComponent<GameScript>().addScore(10);
            print("Points: " + gameScript.GetComponent<GameScript>().getScore());
        }
    }
}
