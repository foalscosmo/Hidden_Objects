using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private DownPanel downPanel;
    [SerializeField] private GameObject finishPanel;
    [SerializeField] private Button mainBackButton;
    [SerializeField] private Button inPanelBackButton;
    [SerializeField] private GameObject downPanelCanvas;
    private bool isFinishPanelOpen;

    private void OnEnable()
    {
        downPanel.OnMaxObjectAnswered += HandleAllCorrectTouches;
    }

    private void OnDisable()
    {
        downPanel.OnMaxObjectAnswered -= HandleAllCorrectTouches;
    }

    private void Awake()
    {
        finishPanel.SetActive(false);
        inPanelBackButton.transform.localScale = Vector3.zero;
        finishPanel.transform.localScale = Vector3.zero;
    }

    private void HandleAllCorrectTouches()
    {
        mainBackButton.gameObject.SetActive(false);
        finishPanel.SetActive(true);
        downPanelCanvas.SetActive(false);
        finishPanel.transform.DOScale(1, 1).OnComplete((() =>
        {
            inPanelBackButton.transform.DOScale(1, 1);
        }));
    }
        
}