using ChuongCustom;
using UnityEngine;
using UnityEngine.UI;

public class HPPlayer : MonoBehaviour
{
    [SerializeField] private Image _fill;

    private void OnValidate()
    {
        _fill = GetComponentInChildren<Image>();
    }

    void Start()
    {
        InGameAction.ChangeHP += OnChangeGem;
        _fill.fillAmount = 1;
    }

    private void OnChangeGem(int obj)
    {
        _fill.fillAmount = obj / 100f;
    }
}