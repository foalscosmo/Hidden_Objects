using UnityEngine;

namespace GardenScripts
{
    public class ResponsivePosition : MonoBehaviour
    {
        [SerializeField]  private Camera mainCamera;
        [SerializeField]  private Vector2 defaultResolution;
        [SerializeField]  private RectTransform cameraRect;
        private Rect screenArea;
        
        void Start()
        {
            Test();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Test();
            }
        }

        private void Test()
        {
            // //with scren only
            // transform.localScale = new Vector3(1, 1, 1);
            // transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, 0);
            // float screenRatio =  cameraRect.rect.width / defaultResolution.x;
            // transform.localScale = new Vector3(transform.localScale.x*screenRatio,transform.localScale.y*screenRatio);
            
            //only with safe area
            transform.localScale = Vector3.one;
            transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, 0);
            float screenRatio = cameraRect.rect.width / defaultResolution.x;
            Debug.Log(screenRatio + " Screen ratio");
            Debug.Log(cameraRect.rect.width + " Screen size");
            Debug.Log(Screen.safeArea.width + " Safe area");
            transform.localScale = new Vector3(transform.localScale.x*screenRatio,transform.localScale.y*screenRatio);
        }
    }
}