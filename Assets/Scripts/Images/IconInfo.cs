using UnityEngine;

[CreateAssetMenu(fileName = "IconConfig", menuName = "Custom Folders/IconConfig", order = 0)]
public class IconInfo : ScriptableObject
{
    [SerializeField] private string iconName;
    [SerializeField] private string prefabName;

    public string IconName => iconName;
    public string PrefabName => prefabName;
}
