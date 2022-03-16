using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizableParts : MonoBehaviour
{
    [SerializeField] private Renderer hair;
    public Renderer Hair => hair;
    [SerializeField] private Renderer torso;
    public Renderer Torso => torso;
    [SerializeField] private Renderer legs;
    public Renderer Legs => legs;
    [SerializeField] private Renderer head;
    public Renderer Head => head;
}
