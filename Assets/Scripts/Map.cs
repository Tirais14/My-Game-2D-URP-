using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
	[SerializeField] private Grid terrain;
	[SerializeField] private Camera mainCamera;
	[SerializeField] private Tilemap tilemap;
	public Tile tile;

	/// <param name="tile"></param>
	/// <returns>Return false if getting failed</returns>
	public bool TryGetClickedTile(out TileBase tile)
	{
		Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
		tile = tilemap.GetTile(terrain.WorldToCell(mousePosition));

		if (tile != null)
		{ return true; }
		else
		{ return false; }
	}

	public void SetTile(Vector3 position, TileBase tile)
	{
		position = mainCamera.ScreenToWorldPoint(position);
		Vector3Int convertedPosition = terrain.WorldToCell(position);
		tilemap.SetTile(convertedPosition, tile);
	}

	private void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{ SetTile(Input.mousePosition, tile); }
	}
}