using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private CanvasGroup _windowGroup;
    [SerializeField] private Button _actionButton;

    public event Action ButtonClicked;
    
    protected CanvasGroup WindowGroup => _windowGroup;
    protected Button ActionButton => _actionButton;

    private void OnEnable()
    {
        _actionButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _actionButton.onClick.RemoveListener(OnButtonClick);
    }

    public void Close()
    {
        WindowGroup.alpha = 0f;
        WindowGroup.blocksRaycasts = false;
        ActionButton.interactable = false;
    }

    public void Open()
    {
        WindowGroup.alpha = 1f;
        WindowGroup.blocksRaycasts = true;
        ActionButton.interactable = true;
    }

    private void OnButtonClick()
    {
        ButtonClicked?.Invoke();
    }
}