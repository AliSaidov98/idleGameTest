using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour
{
    public static UnityEvent OnTimerSet = new UnityEvent();
    public static UnityEvent OnRepair = new UnityEvent();

    public static Color currentColor;
    public static ColumnSettings currentColumn;

    private void Start()
    {
        OnTimerSet?.Invoke();
    }
}
