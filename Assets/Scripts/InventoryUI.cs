using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private RectTransform inventorySlotsObject;
	public delegate void OnItemChanged();
	public static OnItemChanged onItemChangedCallback;
	public static InventorySlot[] inventorySlots;
	private bool inventoryOpened = false;

    public static void AddItem(Item item)
    {
		InventorySlot emptyInventorySlot;
		if(TryGetEmptyInventorySlot(out emptyInventorySlot))
		{ emptyInventorySlot.SetInventoryItem(item); }
    }
	public static void AddItem(string itemName)
	{
		InventorySlot emptyInventorySlot;
		if(TryGetEmptyInventorySlot(out emptyInventorySlot))
		{
			Item item;
			if(ItemsDatabase.TryGetItem(itemName, out item))
			{
				emptyInventorySlot.SetInventoryItem(item);
			}
		}
	}

	public static void DeleteItem(InventoryItem inventoryItem)
	{ inventoryItem.GetComponentInParent<InventorySlot>().ClearSlot(); }

	private static bool TryGetEmptyInventorySlot(out InventorySlot emptyInventorySlot)
	{
		foreach (InventorySlot inventorySlot in inventorySlots)
		{
			if (!inventorySlot.HasItem)
			{
				emptyInventorySlot = inventorySlot;
				return true;
			}
		}

		emptyInventorySlot = null;
		return false;
	}

	public static bool IsMouseOverUI()
	{ return EventSystem.current.IsPointerOverGameObject(); }

	private void UpdateUI()
	{
		Debug.Log("Inventory UI Updated!");
		foreach (InventorySlot inventorySlot in inventorySlots)
		{
			inventorySlot.CheckForAnItem();
			if (inventorySlot.HasItem)
			{
				//InventoryItem inventoryItem = inventorySlot.gameObject.transform.GetChild(0).GetComponent<InventoryItem>();
				InventoryItem inventoryItem = inventorySlot.gameObject.GetComponentInChildren<InventoryItem>();
				//if (ItemsDatabase.TryFindItem(inventoryItem.name))
				//{ Debug.LogWarning("While updating UI strange item was detected!"); }
			}
			else
			{ inventorySlot.ClearSlot(); }
		}
	}

	public void OpenCloseInventory()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			Debug.Log(gameObject.name);
			if(inventoryOpened)
			{
				inventoryOpened = false;
				gameObject.SetActive(inventoryOpened); 
			}
			else
			{
				inventoryOpened = true;
				gameObject.SetActive(inventoryOpened);
			}
		}
	}

	void Start()
    {
        inventorySlots = inventorySlotsObject.GetComponentsInChildren<InventorySlot>();
		onItemChangedCallback += UpdateUI;
	}
}
