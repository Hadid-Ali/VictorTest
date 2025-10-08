using UnityEngine;

public class ColorDataEntity
{
    public float r;
    public float g;
    public float b;
    public float a;

    public Color GetColor() => new(r, g, b, a);

    public override string ToString() => GetColor().ToString();
}