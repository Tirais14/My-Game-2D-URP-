using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
public class Item : ScriptableObject 
{
	[SerializeField] private int id = 0;
	public int Id => id;
	[SerializeField] private new string name = "Not Assigned";
	public string Name => name;
	[SerializeField] private Sprite icon = null;
	public Sprite Icon => icon;
	[SerializeField] private bool canSell = true;
	public bool CanSell => canSell;
	[SerializeField] private float cost = 0f;
	public float Cost => cost;
}