using UnityEngine;

public class ColumnSettings : MonoBehaviour
{
    public Color _color;
    private MeshRenderer _mesh;

    private void Awake()
    {
        _mesh = GetComponent<MeshRenderer>();
    }

    public void ChangeColor(Color color)
    {
        _mesh.material.color = color;
    }
}
