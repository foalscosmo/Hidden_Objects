using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

namespace GardenScripts
{
    public class TouchObject : MonoBehaviour
    {
       private Camera mainCamera;
        private Finger touchFinger;
        [SerializeField] private List<Transform> targetObjects = new();
        [SerializeField] private int maxObjectCount;
        [SerializeField] private int currentObjectIndex;
        [SerializeField] private List<int> stayedObjs = new();
        private HashSet<int> UntouchableObjects { get; } = new();

        public List<int> StayedObjs
        {
            get => stayedObjs;
            set => stayedObjs = value;
        }

        public int MaxObjectCount => maxObjectCount;
        public event Action OnCorrectTouch;
        public event Action<int> OnCorrectInvokeIndex;

        public int CurrentObjectIndex => currentObjectIndex;

        public List<Transform> TargetObjects => targetObjects;

        private void Awake()
        {
            mainCamera = Camera.main;
        }

        private void OnEnable()
        {
            EnhancedTouchSupport.Enable();
            ETouch.Touch.onFingerDown += HandleFingerDown;
        }

        private void OnDisable()
        {
            ETouch.Touch.onFingerDown -= HandleFingerDown;
            EnhancedTouchSupport.Disable();
        }

        private void HandleFingerDown(Finger touchedFinger)
        {
            if (touchFinger != null) return;

            Vector2 touchPosition = GetTouchWorldPosition(touchedFinger.screenPosition);

            for (var index = 0; index < targetObjects.Count; index++)
            {
                if (UntouchableObjects.Contains(index)) continue;
                var currentTarget = targetObjects[index];
                if (Vector2.Distance(touchPosition, currentTarget.position) < 2f)
                {
                    stayedObjs[index] = 99;
                    touchFinger = touchedFinger;
                    currentObjectIndex = index;
                    OnCorrectTouch?.Invoke();
                    OnCorrectInvokeIndex?.Invoke(index);
                    UntouchableObjects.Add(index);
                    var originalScale = currentTarget.localScale;
                    currentTarget.DOScale(1.2f, 0.5f).OnComplete(() =>
                    {
                        currentTarget.DOScale(originalScale, 0.5f);
                    });
                }
            }

            touchFinger = null;
        }

        private Vector2 GetTouchWorldPosition(Vector2 screenPosition)
        {
            return mainCamera.ScreenToWorldPoint(screenPosition);
        }
    }
}
