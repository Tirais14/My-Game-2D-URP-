using UnityEngine;

public class OtherScript : MonoBehaviour
{
    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] private Animator playerAnimationController;

	public void UseTool()
    {
  //      if (Input.GetMouseButtonDown(0))
  //      {
  //          playerAnimationController.SetTrigger("PlayerAttack");

		//}
    }
    void Update()
    {
  //      inventoryUI.OpenCloseInventory();
  //      UseTool();

		//if (Input.GetKeyDown(KeyCode.E))
  //      {
  //          InventoryUI.AddItem("Hoe");
		//}
    }

    //[ContextMenu("Rename Slots")]
    [AddComponentMenu("Rename Slots")]
    public void Rename()
    {
		InventorySlot[] inventorySlots = FindObjectsOfType<InventorySlot>();
		Debug.Log(inventorySlots);
	}
}
