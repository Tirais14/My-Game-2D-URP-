using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	private Vector3 defaultPosition;
	[SerializeField] private InventorySlot inventorySlot;
	public InventorySlot InventorySlot => inventorySlot;
	[SerializeField] private InventoryItem inventoryItem;
	public Image inventoryItemIcon;

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (inventorySlot.HasItem)
		{
			Debug.Log("OnBeginDrag");
			defaultPosition = inventoryItem.transform.position;
			inventoryItem.transform.SetParent(transform.root);
			inventoryItem.transform.SetAsLastSibling();
			inventoryItem.InventoryItemIcon.raycastTarget = false;
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (inventorySlot.HasItem)
		{
			Debug.Log("OnDrag");
			inventoryItem.transform.position = Input.mousePosition;
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (eventData.pointerDrag != null)
		{
			Debug.Log("OnEndDrag");
			inventoryItem.transform.SetParent(inventoryItem.DefaultParent);
			inventoryItem.transform.position = defaultPosition;
			inventoryItem.InventoryItemIcon.raycastTarget = true;
			if (!InventoryUI.IsMouseOverUI())
			{
				InventoryUI.DeleteItem(inventoryItem);
			}
			InventoryUI.onItemChangedCallback.Invoke();
		}
	}
}
