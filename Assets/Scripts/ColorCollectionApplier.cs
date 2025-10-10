using System;
using UnityEngine;

public class ColorCollectionApplier : ColorApplierBase
{
    [field: SerializeField] public ColorObject[] Colors { get; private set; }
    
    public override void ApplyColor(Color color)
    {
        base.ApplyColor(color);
        if (TryGetComponent(out IColorMediatorComponent colorMediatorComponent))
        {
            colorMediatorComponent.ApplyColorStyle(color);
        }
    }

    public void Reset()
    {
        base.ApplyColor(Color.white);
    }
}
