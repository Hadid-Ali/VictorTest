using System;
using UnityEngine;

[Serializable]
public struct ColorObject
{
    [field: SerializeField] public Color Color { get; private set; }
    [field: SerializeField] public string Name { get; private set; }
}
