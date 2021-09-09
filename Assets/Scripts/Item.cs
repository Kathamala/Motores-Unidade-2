using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

	new public string name = "New Item";				
	public Material icon = null;
	public bool showInInventory = true;

	public bool isSkate = false;

	public int ammount = 1;

	public void Start()
	{
		ammount = 1;
	}

	public virtual void Use ()
	{
		ammount--;
		if(ammount <= 0) RemoveFromInventory();
	}

	public void RemoveFromInventory ()
	{
		Inventory.instance.Remove(this);
	}

}