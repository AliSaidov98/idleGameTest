using System.Collections.Generic;
using UnityEngine;

public class ColumnsBreak : MonoBehaviour
{
    [SerializeField] private ColorsHolder _colorsHolder;
    [SerializeField] private float _timeToBreak;

    private List<ColumnSettings> _columnSettings = new List<ColumnSettings>();

    private float _timer;
    private bool _colbroke;

    private void Awake()
    {
        ColumnSettingsAssign();
        
        GameEvents.OnTimerSet.AddListener(() =>
        {
            SetBroke(false);
            SetTimer(_timeToBreak);
        });
    }

    private void SetBroke(bool broke)
    {
        _colbroke = broke;
    }

    private void Update()
    {
        if (_timer > 0)
            _timer -= Time.deltaTime;
        
        else if(_timer <= 0 && !_colbroke)
            BreakRandomCol();
    }

    private void ColumnSettingsAssign()
    {
        foreach (Transform child in transform)
        {
            child.TryGetComponent(out ColumnSettings columnSettings);
            
            if(columnSettings == null)
                Debug.LogError("column settings is not assigned to child: " + child);
            
            else
                _columnSettings.Add(columnSettings);
            
        }
    }

    public void SetTimer(float t)
    {
        _timer = t;
    }

    private void BreakRandomCol()
    {
        SetBroke(true);
        
        var rndColumn = Random.Range(0, _columnSettings.Count);
        var rndColor = Random.Range(0, _colorsHolder.colors.Length);

        _columnSettings[rndColumn].ChangeColor(_colorsHolder.colors[rndColor]);

        GameEvents.currentColumn = _columnSettings[rndColumn];
        GameEvents.currentColor = _colorsHolder.colors[rndColor];
        
        GameEvents.OnRepair?.Invoke();
    }
}
