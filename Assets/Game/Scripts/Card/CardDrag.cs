using UnityEditor.Timeline.Actions;
using UnityEngine;

public class CardDrag : ChildBehavior
{
    
    [SerializeField] private CardCtrl cardCtrl;
    [SerializeField]  private Camera mainCamera;
    [SerializeField] private bool isDragging = false; 
    [SerializeField] private Vector3 offset;         
    
    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        if(mainCamera == null) mainCamera = Camera.main;
        if (cardCtrl == null) cardCtrl = transform.GetComponentInParent<CardCtrl>();
    }
    

    private void OnMouseDown()
    {
        Debug.Log("Click");
        isDragging = true;
        offset = cardCtrl.transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        if (isDragging) cardCtrl.transform.position = GetMouseWorldPosition() + offset;
        
    }

    private void OnMouseUp()
    {
        isDragging = false;

        // Kiểm tra vị trí thả
        if (IsOverDropZone()) cardCtrl.SpawnBot();
        else
        {
            // Reset vị trí nếu không thả đúng khu vực
            ResetCardPosition();
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f; 
        return mainCamera.ScreenToWorldPoint(mousePosition);
    }

    private bool IsOverDropZone()
    {
        // Kiểm tra nếu vị trí thả nằm trong khu vực thả (Drop Zone)
        // Ở đây bạn có thể thay thế bằng logic cụ thể của bạn
        Collider2D dropZone = Physics2D.OverlapPoint(cardCtrl.transform.position);
        return dropZone != null && dropZone.CompareTag("DropZone");
    }

    private void ResetCardPosition()
    {
        // Reset vị trí thẻ bài về vị trí ban đầu
        cardCtrl.transform.position = Vector3.zero;
    }
}