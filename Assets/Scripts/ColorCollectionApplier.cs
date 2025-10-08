using UnityEngine;

public class ColorCollectionApplier : ColorApplierBase
{
    [field: SerializeField] public ColorObject[] Colors { get; private set; }
}
