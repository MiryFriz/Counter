using TMPro;
using UnityEngine;

public class View : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField] private float _interval = 0.5f;

    private Counter _counter;

    private void Start()
    {
        _counter = new Counter(this, _interval);
        _counter.OnValueChanged += UpdateUI;
        UpdateUI(_counter.Value);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _counter.Toggle();
        }
    }

    private void OnDestroy()
    {
        if (_counter != null)
        {
            _counter.OnValueChanged -= UpdateUI;
        }
    }

    private void UpdateUI(int value)
    {
        if (_counterText != null)
        {
            _counterText.text = $"{value}";
        }
    }
}