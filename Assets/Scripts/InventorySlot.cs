using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item item;
    public GameObject removeButton;

    public Text count;

    public Image icon;

    public Renderer ren;
    private Material[] mat;

    public GameObject gs;

    public GameObject player;

    public GameObject toaster;

    public void Update()
    {
        if(item != null)
        {
            if(item.isSkate)
            {
                removeButton.GetComponent<Button>().enabled = false;
                removeButton.GetComponent<Image>().enabled = false;
                count.text = "";
            }else{
                if(item.ammount > 1)
                {
                    count.text = item.ammount.ToString();
                } else{
                    count.text = "";
                };
            };
        } else{
            count.text = "";
        }
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.color = item.icon.color;
        icon.enabled = true;
        removeButton.GetComponent<Button>().interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.GetComponent<Button>().interactable = false;
    }

    public void onRemoveButton()
    {
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if(item != null)
        {
            if(item.isSkate)
            {
                ren.material = item.icon;
                if(item.name == "RedSkateBoard")
                {
                    player.GetComponent<ThirdPersonMovement>().jumpHeight = 12f;
                    toaster.GetComponent<ToastMessages>().showToast("Você pula muito alto!", 5);
                } else{
                    player.GetComponent<ThirdPersonMovement>().jumpHeight = 3f;
                }

                if(item.name == "GreenSkate")
                {
                    player.GetComponent<ThirdPersonMovement>().speed = 20f;
                    player.GetComponent<ThirdPersonMovement>().fastSpeed = 28f;
                    toaster.GetComponent<ToastMessages>().showToast("Você está mais rápido agora!", 5);
                } else{
                    player.GetComponent<ThirdPersonMovement>().speed = 12;
                    player.GetComponent<ThirdPersonMovement>().fastSpeed = 20f;
                }

                if(item.name == "SkateOfGold")
                {
                    player.GetComponent<ThirdPersonMovement>().maxJumps = 1;
                    toaster.GetComponent<ToastMessages>().showToast("Boa garoto! Double jump!", 5);
                } else{
                    player.GetComponent<ThirdPersonMovement>().maxJumps = 0;

                }

                if(item.name == "FinalSkate")
                {
                    player.GetComponent<ThirdPersonMovement>().speed = 20f;
                    player.GetComponent<ThirdPersonMovement>().fastSpeed = 28f;
                    player.GetComponent<ThirdPersonMovement>().maxJumps = 1;
                    player.GetComponent<ThirdPersonMovement>().jumpHeight = 12f;
                    gs.GetComponent<GameScript>().setLives(0);
                    toaster.GetComponent<ToastMessages>().showToast("É MUITA SUSTÂNCIA. BUFF MÁXIMO E SÓ UMA VIDA RESTANTE!", 10);

                } else if(item.name != "RedSkateBoard" && item.name != "GreenSkate" && item.name != "SkateOfGold"){
                    player.GetComponent<ThirdPersonMovement>().speed = 12;
                    player.GetComponent<ThirdPersonMovement>().fastSpeed = 20f;
                    player.GetComponent<ThirdPersonMovement>().maxJumps = 0;
                    player.GetComponent<ThirdPersonMovement>().jumpHeight = 3f;
                }
            } else{
                gs.GetComponent<GameScript>().increaseLives();
                item.Use();
            }
        }
    }
}
