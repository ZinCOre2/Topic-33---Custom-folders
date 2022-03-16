using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "TextureConfig", menuName = "Task Char Customizer/Color Config", order = 0)]
public class Config_TextureColors : ScriptableObject
{
    [SerializeField] private Color[] colors;
    public Color[] Colors => colors;
}

