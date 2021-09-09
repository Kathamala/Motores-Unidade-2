using UnityEngine;

public class Interactable : MonoBehaviour {

	public float radius = 3f;
	public Transform interactionTransform;

	public Transform player;

	//bool hasInteracted = false;

	public virtual void Interact ()
	{
		Debug.Log("Interacting with " + transform.name);
	}

	void Update ()
	{
        float distance = Vector3.Distance(player.position, interactionTransform.position);
        if (distance <= radius)
        {
            Interact();
            //hasInteracted = true;
        }
	}

}