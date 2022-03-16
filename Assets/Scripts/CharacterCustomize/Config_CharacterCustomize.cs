using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Task Char Customizer/Character Config", order = 0)]
public class Config_CharacterCustomize : ScriptableObject
{
    [SerializeField] private string[] characters;
    public string[] Characters => characters;
    
    public GameObject GetCharacter(string characterName)
    {
        var objName = characters.FirstOrDefault(e => e == characterName);
        return string.IsNullOrEmpty(objName) ? null : LoadObject(characterName);
    }
    
    private static GameObject LoadObject(string characterName)
    {
        var asset = Resources.Load<GameObject>($"Characters/{characterName}");
        Resources.UnloadUnusedAssets();
        return asset;
    }
    
#if UNITY_EDITOR
    private void Reset()
    {
        var objects = Resources.LoadAll<GameObject>("Characters");
        characters = new string[objects.Length];

        for (int i = 0; i < characters.Length; i++)
        {
            characters[i] = objects[i].name;
        }
    }
#endif
}

