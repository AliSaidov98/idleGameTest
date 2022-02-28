using UnityEngine;
using DG.Tweening;

public class Repairer : MonoBehaviour
{
    [SerializeField] private ColorsHolder _colors;
    [SerializeField] private float _destinationSpeed;
    public Color[] Colors => _colors.colors;

    private Vector3 _initPosition;

    private void Awake()
    {
        _initPosition = transform.position;
        ShowColorsOnCubes();
    }

    public void Repair(ColumnSettings column)
    {
        print("I repair: " + transform.name);
        
        var newPosition = column.transform.position;
        newPosition.y = _initPosition.y;
        newPosition.z -= 1;
        
        transform.DOMove(newPosition, _destinationSpeed).SetDelay(0.5f).OnComplete(() =>
        {
            column.ChangeColor(Color.white);
            transform.DOMove(_initPosition, _destinationSpeed).SetDelay(0.5f).OnComplete(() => GameEvents.OnTimerSet?.Invoke());
        });
    }

    private void ShowColorsOnCubes()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<MeshRenderer>().material.color = _colors.colors[child.GetSiblingIndex()];
        }
    }
}
