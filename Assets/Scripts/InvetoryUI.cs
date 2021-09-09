using UnityEngine;

public class InvetoryUI : MonoBehaviour
{

    //public GameObject gs;

    public Transform itemsParent;

    Inventory inventory;

    [HideInInspector] public InventorySlot[] slots;

    public GameObject inventoryUI;

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>(); //COLOCAR NO UPADTE SE O INVENTORY FOR DINÂMICO*/
        UpdateUI();
    }
     
    void Update()
    {
        //slots = itemsParent.GetComponentsInChildren<InventorySlot>(); //COLOCAR NO UPADTE SE O INVENTORY FOR DINÂMICO*/
        UpdateUI();
        if(Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count){
                slots[i].AddItem(inventory.items[i]);
            } else{
                slots[i].ClearSlot();
            }
        }
    }
}
