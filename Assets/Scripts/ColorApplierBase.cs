using UnityEngine;

public abstract class ColorApplierBase : MonoBehaviour
{
  [SerializeField] private ColoringComponent _coloringComponent;

  public void ApplyColor(Color c)
  {
    _coloringComponent.ApplyColor(c);
  }
}
