using System.Collections;
using System.Collections.Generic;
//using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject gameScript;
    private Vector3 initialPosition;

    [HideInInspector] public bool collisionWithFirstCoin = false;

    //private bool paused;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        collisionWithFirstCoin = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }*/
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            gameScript.GetComponent<GameScript>().addScore(10);
            collisionWithFirstCoin = true;
        }

        if(other.gameObject.CompareTag("Killer"))
        {
            GetComponent<CharacterController>().enabled = false;
            GetComponent<CharacterController>().transform.position = initialPosition;
            GetComponent<CharacterController>().enabled = true;            
            GetComponent<ThirdPersonMovement>().velocity = new Vector3(0, 0, 0);            
            gameScript.GetComponent<GameScript>().decreaseLives();
        }
    }
}
