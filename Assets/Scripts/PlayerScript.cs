using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject gameScript;
    private Vector3 initialPosition;

    [HideInInspector] public bool collisionWithFirstCoin = false;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        collisionWithFirstCoin = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            gameScript.GetComponent<GameScript>().addScore(10);
            print("Points: " + gameScript.GetComponent<GameScript>().getScore());
            collisionWithFirstCoin = true;
        }

        if(other.gameObject.CompareTag("Killer"))
        {
            transform.position = new Vector3(0, 40, 0);
            GetComponent<ThirdPersonMovement>().velocity = new Vector3(0, 0, 0);            
            gameScript.GetComponent<GameScript>().decreaseLives();
        }
    }
}
