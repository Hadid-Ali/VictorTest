using System;
using Unity.Mathematics;
using UnityEngine;

public class ColoringComponent : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _meshRenderer ??= GetComponent<MeshRenderer>();
    }

    public void ApplyColor(Color color)
    {
        _meshRenderer.material.color = color;
    }
}
