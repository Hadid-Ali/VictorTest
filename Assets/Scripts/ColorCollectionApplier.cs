using System;
using UnityEngine;

public class ColorCollectionApplier : ColorApplierBase
{
    [field: SerializeField] public ColorObject[] Colors { get; private set; }

    public static Action<Color> ColorChanged { get; set; }
    
    public override void ApplyColor(Color color)
    {
        base.ApplyColor(color);
        ColorChanged?.Invoke(color);
    }

    public void Reset()
    {
        base.ApplyColor(Color.white);
    }
}
