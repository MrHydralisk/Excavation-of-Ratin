using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    [SerializeField]
    private Camera sceneCamera;

    private Vector3 lastPosition;

    [SerializeField]
    private LayerMask palcementLayerMask;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        GridManager gridManager = GridManager.instance;
        Vector3 mousePosition = GetSelectedMapPosition();
        Vector3Int gridPosition = gridManager.WorldToCell(mousePosition);
        gridManager.mouseIndicator.transform.position = mousePosition;
        gridManager.cellIndicator.transform.position = gridManager.CellToWorld(gridPosition);

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            CameraManager.instance.MoveCameraTo(mousePosition);
        }

        float scrollValue = Input.GetAxisRaw("Mouse ScrollWheel");
        CameraManager.instance.ResizeCamera(scrollValue);
    }

    public Vector3 GetSelectedMapPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = sceneCamera.nearClipPlane;
        Ray ray = sceneCamera.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, palcementLayerMask))
        {
            lastPosition = hit.point;
        }
        return lastPosition;
    }
}
