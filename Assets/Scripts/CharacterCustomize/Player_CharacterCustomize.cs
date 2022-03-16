using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Player_CharacterCustomize : MonoBehaviour
{
    [SerializeField] private Button_CharacterCustomize buttonPrefab;
    [SerializeField] private Button confirmButton;
    [SerializeField] private RectTransform characterButtonGrid;
    [SerializeField] private Player_BodyPartCustomize[] customizePanels;
    [SerializeField] private Transform characterRoot;

    private Config_CharacterCustomize _config;
    private GameObject _createdModel;

    private void Start()
    {
        _config = Resources.Load<Config_CharacterCustomize>("CharacterConfig");

        var names = _config.Characters;

        foreach (var objName in names)
        {
            var btn = Instantiate(buttonPrefab, characterButtonGrid);
            btn.Setup(objName, OnCharacterCustomizeButton);
        }
        
        foreach (var panel in customizePanels)
        {
            panel.gameObject.SetActive(false);
        }
        
        confirmButton.onClick.AddListener(delegate
        {
            if (_createdModel == null) { return; }

            gameObject.SetActive(false);
            
            foreach (var panel in customizePanels)
            {
                panel.gameObject.SetActive(true);
                
                var searchPattern = "";
                if (_createdModel.name.Contains("Female"))
                {
                    searchPattern = "Female";
                }
                if (_createdModel.name.Contains("Male"))
                {
                    searchPattern = "Male";
                }
                
                panel.SetGridData(_createdModel.GetComponent<CustomizableParts>(), searchPattern);
            }
        });
        
    }

    private void OnCharacterCustomizeButton(string id)
    {
        var directoryInfoHairs = new DirectoryInfo(Application.streamingAssetsPath + "/CharTextures/Hairs");
        var directoryInfoTorsos = new DirectoryInfo(Application.streamingAssetsPath + "/CharTextures/Torsos");
        var directoryInfoLegs = new DirectoryInfo(Application.streamingAssetsPath + "/CharTextures/Legs");
        var directoryInfoHeads = new DirectoryInfo(Application.streamingAssetsPath + "/CharTextures/Heads");
            
        var allFiles = directoryInfoHairs.GetFiles("*.*");
        
        var asset = _config.GetCharacter(id);
        if (asset == null) { return; }
        
        if (_createdModel != null)
        {
            Destroy(_createdModel);
        }
        
        _createdModel = Instantiate(asset, characterRoot);
    }
    
}