using System;
using System.IO;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
	[SerializeField] private int itemId = 0;
	public int ItemId => itemId;

	[SerializeField] private string inventoryItemName = "";
	public string InventoryItemName => inventoryItemName;

	[SerializeField] private int inventoryItemCount = 0;
	public int InventoryItemCount => inventoryItemCount;

	[SerializeField] private Image inventoryItemIcon = null;
	public Image InventoryItemIcon => inventoryItemIcon;
	public Transform DefaultParent { get; private set; }

	/// <summary>
	/// Instead of this metod use Inventory UI method
	/// </summary>
	public void ResetItem()
	{
		itemId = 0;
		inventoryItemName = "";
		inventoryItemCount = 0;
		inventoryItemIcon.sprite = null;
		inventoryItemIcon.enabled = false;
	}

	/// <summary>
	/// Instead of this metod use Inventory UI method
	/// </summary>
	public void SetItem(Item item, int count = 1)
	{
		itemId = item.Id;
		inventoryItemName = item.Name;
		inventoryItemCount = count;
		inventoryItemIcon.sprite = item.Icon;
		inventoryItemIcon.enabled = true;
	}
	/// <summary>
	/// Instead of this metod use Inventory UI method
	/// </summary>
	public void SetItem(InventoryItem inventoryItem)
	{
		itemId = inventoryItem.ItemId;
		inventoryItemName = inventoryItem.inventoryItemName;
		inventoryItemCount = inventoryItem.InventoryItemCount;
		inventoryItemIcon.sprite = inventoryItem.InventoryItemIcon.sprite;
		inventoryItemIcon.enabled = true;
	}

	void Awake()
	{
		DefaultParent = transform.parent;
		name = "InventoryItem" + GetComponentInParent<InventorySlot>().name.Remove(0, 13);
	}
}
