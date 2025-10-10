using UnityEngine;

public abstract class ColorApplierBase : MonoBehaviour
{
    [SerializeField] private ColoringComponent _coloringComponent;

    public virtual void ApplyColor(Color c)
    {
        _coloringComponent.ApplyColor(c);
    }
}
