using System;
using System.Collections;
using UnityEngine;

public class Counter
{
    private int _value = 0;
    private bool _isCounting = false;
    private float _interval;
    private Coroutine _coroutine;
    private MonoBehaviour _context;

    public event Action<int> OnValueChanged;
    public int Value => _value;

    public Counter(MonoBehaviour context, float interval)
    {
        _context = context;
        _interval = interval;
    }

    public void Toggle()
    {
        if (_isCounting)
            Stop();
        else
            Start();
    }

    private void Start()
    {
        _isCounting = true;
        _coroutine = _context.StartCoroutine(CountRoutine());
    }

    private void Stop()
    {
        _isCounting = false;

        if (_coroutine != null)
        {
            _context.StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator CountRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_interval);
            _value++;
            OnValueChanged?.Invoke(_value);
        }
    }
}