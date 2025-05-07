using System.Collections.Generic;
using UnityEngine;

public class ItemsDatabase : MonoBehaviour
{
	private static int itemsCount = 0;
	[SerializeField] private Item[] itemsDatabase;
	private static Dictionary<string, Item> items;

	public static bool TryGetItem(string itemName, out Item foundItem)
	{
		foreach (var item in items)
		{
			if(item.Key == itemName)
			{
				foundItem = item.Value;
				return true;
			}
		}
		foundItem = null;
		return false;
	}

	//private void RenameItems()
	//{
	//	Dictionary<Type, string> nameCodes = new(3)
	//	{
	//		[typeof(Tool)] = "Tool_",
	//		[typeof(Weapon)] = "Weapon_",
	//		[typeof(Item)] = "Item_"
	//	};
	//	foreach (Item item in itemsDatabase)
	//	{
	//		string newName;
	//		if (item is Tool && !item.Name.Contains(nameCodes[typeof(Tool)]))
	//		{
	//			newName = nameCodes[typeof(Tool)] + item.Name;
	//			ChangeItemName(item, newName);
	//			Debug.Log(item.Name);
	//			continue;
	//		}
	//		else if (item is Weapon && !item.Name.Contains(nameCodes[typeof(Weapon)]))
	//		{
	//			newName = nameCodes[typeof(Weapon)] + item.Name;
	//			ChangeItemName(item, newName);
	//			Debug.Log(item.Name);
	//			continue;
	//		}
	//		else if (item is Item && !item.Name.Contains(nameCodes[typeof(Item)]))
	//		{
	//			newName = nameCodes[typeof(Item)] + item.Name;
	//			ChangeItemName(item, newName);
	//			Debug.Log(item.Name);
	//		}
	//	}
	//}

	//private void ChangeItemName<T>(T obj, string newName)
	//{
	//	FieldInfo name = typeof(Item).GetField("name", BindingFlags.Instance | BindingFlags.NonPublic);
	//	name?.SetValueOptimized(obj, newName);
	//}

	private void Start()
	{
		Debug.Log(itemsDatabase.Length);
		items = new Dictionary<string, Item>(itemsDatabase.Length);
		foreach (Item item in itemsDatabase)
		{
			itemsCount++;
			items.Add(item.Name, item);
		}
		itemsDatabase = null;
	}
}
