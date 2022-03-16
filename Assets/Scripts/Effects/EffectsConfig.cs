using System.Linq;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

[CreateAssetMenu(fileName = "EffectsConfig", menuName = "Custom Folders/EffectsConfig", order = 0)]
public class EffectsConfig : ScriptableObject
{
    [SerializeField] private string[] effects;
    public string[] Effects => effects;

    public GameObject GetRandomEffect()
    {
        var effectName = effects[Random.Range(0, effects.Length)];
        return LoadObject(effectName);
    }

    public GameObject GetEffect(string effectName)
    {
        var objName = effects.FirstOrDefault(e => e == effectName);
        return string.IsNullOrEmpty(objName) ? null : LoadObject(effectName);
    }
    
    private static GameObject LoadObject(string effectName)
    {
        var asset = Resources.Load<GameObject>($"Effects/{effectName}");
        Resources.UnloadUnusedAssets();
        return asset;
    }
    
#if UNITY_EDITOR
    private void Reset()
    {
        var objects = Resources.LoadAll<GameObject>("Effects");
        effects = new string[objects.Length];

        for (int i = 0; i < effects.Length; i++)
        {
            effects[i] = objects[i].name;
        }
    }
#endif
}
