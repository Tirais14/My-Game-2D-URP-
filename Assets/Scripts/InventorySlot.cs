using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
	[SerializeField] private InventoryItem inventoryItem;
	[SerializeField] private bool hasItem = false;
	public bool HasItem => hasItem;

	public bool CheckForAnItem()
	{
		if (inventoryItem.ItemId > 0 && inventoryItem.InventoryItemName != string.Empty && inventoryItem.InventoryItemCount > 0)
		{ hasItem = true; }
		else
		{ hasItem = false; }
		
		return hasItem;
	}

	public void ClearSlot()
	{
		inventoryItem.ResetItem();
		hasItem = false;
	}

	public void SetInventoryItem(Item item)
	{
		inventoryItem.SetItem(item);
		hasItem = true;
	}
	public void SetInventoryItem(InventoryItem inventoryItem)
	{
		this.inventoryItem.SetItem(inventoryItem);
		hasItem = true;
	}

	private void MoveItemToThisSlot(InventorySlot draggedInventoryItemSlot, InventoryItem draggedInventoryItem)
	{
		if (draggedInventoryItemSlot != null && draggedInventoryItemSlot != this)
		{
			if (hasItem)
			{
				GameObject tempInventoryItemObj = Instantiate(draggedInventoryItem.gameObject);
				Debug.Log(tempInventoryItemObj);
				tempInventoryItemObj.SetActive(false);
				tempInventoryItemObj.transform.SetParent(transform.parent);
				InventoryItem tempInventoryItem = tempInventoryItemObj.GetComponent<InventoryItem>();
				SetInventoryItem(draggedInventoryItem);
				draggedInventoryItemSlot.SetInventoryItem(tempInventoryItem);
				Destroy(tempInventoryItemObj);
			}
			else
			{
				SetInventoryItem(draggedInventoryItem);
				draggedInventoryItemSlot.ClearSlot();
			}
		}
	}

	public void OnDrop(PointerEventData eventData)
	{
		Debug.Log("Item Dragged");
		GameObject draggedObject = eventData.pointerDrag;
		if(draggedObject != null)
		{
			InventorySlot draggedInventoryItemSlot = draggedObject.GetComponent<DragAndDrop>().InventorySlot;
			InventoryItem draggedInventoryItem = draggedObject.GetComponent<InventoryItem>();
			MoveItemToThisSlot(draggedInventoryItemSlot, draggedInventoryItem);
		}
	}
}
