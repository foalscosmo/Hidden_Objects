using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DownPanel : MonoBehaviour
{
    [SerializeField] private TouchObject touchObject;
    [SerializeField] private List<Image> downPanelObjects = new();
    [SerializeField] private List<GameObject> checkIconObjects = new();
    [SerializeField] private int correctAmountCounter;
    public event Action OnMaxObjectAnswered;
    public event Action OnObjectScaled;
    public List<Image> DownPanelObjects => downPanelObjects;
    public int CorrectAmountCounter => correctAmountCounter;
    private void OnEnable()
    {
        touchObject.OnCorrectInvokeIndex += HandleScaleOfCorrectObject;
    }

    private void OnDisable()
    {
        touchObject.OnCorrectInvokeIndex -= HandleScaleOfCorrectObject;
    }

    private void Awake()
    {
            
        for (var index = 0; index < downPanelObjects.Count; index++)
        {
            checkIconObjects[index].SetActive(false);
            checkIconObjects[index].transform.localScale = Vector3.zero;
            var sr = downPanelObjects[index];
            var color = sr.color;
            color.a = 1f;
            sr.color = color;
        }
    }

    private void HandleScaleOfCorrectObject(int index)
    {
        correctAmountCounter++;
        OnObjectScaled?.Invoke();
            
        var originalScale = downPanelObjects[index].transform.localScale;

        downPanelObjects[index].transform.DOScale(originalScale * 1.2f, 0.5f).OnComplete(() =>
        {
            var sr = downPanelObjects[index];
            var color = sr.color;
            color.a = 0.5f;
            sr.color = color;
    
            downPanelObjects[index].transform.DOScale(originalScale, 0.3f).OnComplete(() =>
            {
                checkIconObjects[index].SetActive(true);
                checkIconObjects[index].transform.DOScale(1, 0.3f);        
                if (correctAmountCounter == touchObject.MaxObjectCount)
                {
                    OnMaxObjectAnswered?.Invoke();
                }
            });
        });
            
    }
}