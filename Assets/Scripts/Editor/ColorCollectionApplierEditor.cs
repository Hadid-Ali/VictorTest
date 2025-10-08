using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ColorCollectionApplier))]
public class ColorCollectionApplierEditor : Editor
{
    private ColorCollectionApplier _colorCollectionApplier;

    void OnEnable()
    {
        _colorCollectionApplier = target as ColorCollectionApplier;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        ColorObject [] colors = _colorCollectionApplier.Colors;

        foreach (var t in colors)
        {
            if (GUILayout.Button($"Apply {t.Name} Color"))
            {
                _colorCollectionApplier.ApplyColor(t.Color);
            }
        }
        GUILayout.Space(10);
        if (GUILayout.Button("Reset"))
        {
            _colorCollectionApplier.ApplyColor(Color.white);
        }
    }
}
