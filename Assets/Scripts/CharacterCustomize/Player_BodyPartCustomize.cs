using System;
using System.IO;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Player_BodyPartCustomize : MonoBehaviour
{
    [SerializeField] private Button_CharacterCustomize buttonPrefab;
    [SerializeField] private RectTransform buttonGrid;
    [SerializeField] private string assetsFolder;

    private CustomizableParts _characterParts;
    
    public void SetGridData(CustomizableParts characterParts, string searchPattern)
    {
        _characterParts = characterParts;
        
        var directoryInfo = new DirectoryInfo(Application.streamingAssetsPath + "/CharTextures/" + assetsFolder);
        var textures = directoryInfo.GetFiles($"{searchPattern}*.*");
        
        foreach (var fileInfo in textures)
        {
            if (fileInfo.Name.Contains("meta")) { continue; }

            var bytes = File.ReadAllBytes(fileInfo.FullName);
            var texture2D = new Texture2D(1, 1);

            texture2D.LoadImage(bytes);
            
            var rect = new Rect(0, 0, texture2D.width, texture2D.height);
            var pivot = new Vector2(0.5f, 0.5f);

            var sprite = Sprite.Create(texture2D, rect, pivot);

            var btn = Instantiate(buttonPrefab, buttonGrid);
            btn.Setup(sprite, OnCharacterCustomizeButton);
        }
        
    }

    private void OnCharacterCustomizeButton(Sprite sprite)
    {
        switch (assetsFolder)
        {
            case "Hairs":
                _characterParts.Hair.material.mainTexture = sprite.texture;
                break;
            case "Torsos":
                _characterParts.Torso.material.mainTexture = sprite.texture;
                break;
            case "Legs":
                _characterParts.Legs.material.mainTexture = sprite.texture;
                break;
            case "Heads":
                _characterParts.Head.material.mainTexture = sprite.texture;
                break;
        }
    }
}
