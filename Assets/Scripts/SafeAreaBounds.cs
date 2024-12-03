using UnityEngine;

public class SafeAreaBounds : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private BoxCollider2D bottomCollider;
    [SerializeField] private BoxCollider2D leftCollider;
    [SerializeField] private BoxCollider2D rightCollider;
    [SerializeField] private BoxCollider2D topCollider;

    private Rect safeArea;

    private void Awake()
    {
        SetCollidersOnSafeAreaBounds();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SetCollidersOnSafeAreaBounds();
        }
    }

    private void SetCollidersOnSafeAreaBounds()
    {
        safeArea = Screen.safeArea;

        Vector2 safeAreaBottomCenter = mainCamera.ScreenToWorldPoint(new Vector3(
            safeArea.x + safeArea.width / 2,
            safeArea.yMin,
            mainCamera.nearClipPlane
        ));

        Vector2 safeAreaTopCenter = mainCamera.ScreenToWorldPoint(new Vector3(
            safeArea.x + safeArea.width / 2,
            safeArea.yMax,
            mainCamera.nearClipPlane
        ));

        Vector2 safeAreaLeftCenter = mainCamera.ScreenToWorldPoint(new Vector3(
            safeArea.xMin,
            safeArea.y + safeArea.height / 2,
            mainCamera.nearClipPlane
        ));

        Vector2 safeAreaRightCenter = mainCamera.ScreenToWorldPoint(new Vector3(
            safeArea.xMax,
            safeArea.y + safeArea.height / 2,
            mainCamera.nearClipPlane
        ));

        float width = mainCamera.ScreenToWorldPoint(new Vector3(safeArea.width, 0, 0)).x - mainCamera.ScreenToWorldPoint(Vector3.zero).x;
        float height = mainCamera.ScreenToWorldPoint(new Vector3(0, safeArea.height, 0)).y - mainCamera.ScreenToWorldPoint(Vector3.zero).y;

        bottomCollider.transform.position = safeAreaBottomCenter;
        bottomCollider.size = new Vector2(width, 1f); 

        topCollider.transform.position = safeAreaTopCenter;
        topCollider.size = new Vector2(width, 1f); 

        leftCollider.transform.position = safeAreaLeftCenter;
        leftCollider.size = new Vector2(1f, height); 

        rightCollider.transform.position = safeAreaRightCenter;
        rightCollider.size = new Vector2(1f, height); 
    }
}