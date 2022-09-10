using System.Collections;
using UnityEngine;

public class PloughCell : MonoBehaviour
{
    [SerializeField] private TextDisplay _textDisplay;
    [SerializeField] private GameObject _vegetableTemplate;

    [SerializeField] private int _income;

    private bool _isRipe = false;
    private GameObject _vegetable;
    private IEnumerator _enumerator = null;

    private void Start()
    {
        StartCultivation();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_isRipe)
            StartCultivation();
        else
        {
            Destroy(_vegetable);
            print(_income);
            _textDisplay.SetMoney(_income);
            _isRipe = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StartCultivation();
    }

    private void StartCultivation()
    {
        if (!_isRipe && _enumerator == null)
        {
            _enumerator = TimerRipe(3f);
            StartCoroutine(_enumerator);
        }
    }

    private IEnumerator TimerRipe(float duration)
    {
        yield return new WaitForSeconds(duration);
        _vegetable = Instantiate(_vegetableTemplate, transform);
        _isRipe = true;
        _enumerator = null;
    }
}
