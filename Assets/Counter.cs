using UnityEngine;
using TMPro;
using System.Collections;

public class CounterController : MonoBehaviour
{
    [SerializeField] private float interval = 0.5f;
    [SerializeField] private TextMeshProUGUI counterText;

    private int counter = 0;
    private bool isCounting = false;
    private Coroutine countingCoroutine;


    private void Start()
    {
        UpdateUI();

        Debug.Log("Нажмите ЛКМ для запуска/остановки счетчика");
        Debug.Log($"Текущее значение: {counter}");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ToggleCounter();
        }
    }

    private void ToggleCounter()
    {
        if (isCounting)
        {
            StopCounter();
        }
        else
        {
            StartCounter();
        }
    }

    private void StartCounter()
    {
        if (countingCoroutine != null)
        {
            StopCoroutine(countingCoroutine);
        }

        isCounting = true;
        countingCoroutine = StartCoroutine(CountRoutine());

        Debug.Log($"▶️ Счетчик ЗАПУЩЕН (текущее значение: {counter})");
    }

    private void StopCounter()
    {
        if (countingCoroutine != null)
        {
            StopCoroutine(countingCoroutine);
            countingCoroutine = null;
        }

        isCounting = false;

        Debug.Log($"⏸️ Счетчик ОСТАНОВЛЕН (значение: {counter})");
    }

    private IEnumerator CountRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);

            counter++;
            UpdateUI();

            Debug.Log($"Счетчик: {counter}");
        }
    }

    private void UpdateUI()
    {
        if (counterText != null)
        {
            counterText.text = $"{counter}";
        }
    }

    private void OnDestroy()
    {
        if (countingCoroutine != null)
        {
            StopCoroutine(countingCoroutine);
        }
    }
}