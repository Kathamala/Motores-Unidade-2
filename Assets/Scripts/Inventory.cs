using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	#region Singleton

	public static Inventory instance;

	void Awake ()
	{
		if(instance != null){ return;}
		instance = this;
	}

	#endregion

	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;

	public int space = 10;

	public List<Item> items = new List<Item>();

	public GameObject gs;

	public void Start()
	{
		if(gs.GetComponent<GameScript>().getCurrentStage() != 1) items = gs.GetComponent<GameScript>().getItemsList();
	}

	public bool Add (Item item)
	{
		if (item.showInInventory) {
			if (items.Count >= space) {
				return false;
			}

			for (int i = 0; i < items.Count; i++)
			{
				if(items[i].name == item.name) 
				{
					item.ammount++;
					gs.GetComponent<GameScript>().setItemsList(items);

					if (onItemChangedCallback != null)
						onItemChangedCallback.Invoke ();
						
					return true;
				}
			}

			item.ammount = 1;
			items.Add (item);
			gs.GetComponent<GameScript>().setItemsList(items);

			if (onItemChangedCallback != null)
				onItemChangedCallback.Invoke ();
			
		}

		return true;
	}

	public void Remove (Item item)
	{
		items.Remove(item);
		gs.GetComponent<GameScript>().setItemsList(items);

		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();
	}

}