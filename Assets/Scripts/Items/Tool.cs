using UnityEngine;

[CreateAssetMenu(fileName = "New Tool", menuName = "Items/Tool")]
public class Tool : Item
{
	[SerializeField] private bool wateringSoil = false;
	[SerializeField] private bool cultivatesSoil = false;
	[SerializeField] private bool harvsetsCrop = false;
}
