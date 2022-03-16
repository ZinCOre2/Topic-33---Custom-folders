using System.IO;
using UnityEngine;

public class Controller_Textures : MonoBehaviour
{
    [SerializeField] private ImageData baseIcon;

    private Renderer _hairRenderer;
    private Renderer _clothesRenderer;
    
    private void Start()
    {

    }

    private void Update()
    {
        var directoryInfoHairs = new DirectoryInfo(Application.streamingAssetsPath + "/CharTextures/Hairs");
        var directoryInfoTorsos = new DirectoryInfo(Application.streamingAssetsPath + "/CharTextures/Torsos");
        var directoryInfoLegs = new DirectoryInfo(Application.streamingAssetsPath + "/CharTextures/Legs");
        var directoryInfoHeads = new DirectoryInfo(Application.streamingAssetsPath + "/CharTextures/Heads");
        
        var allFiles = directoryInfoHairs.GetFiles("*.*");

        foreach (var fileInfo in allFiles)
        {
            print($"File name {fileInfo.Name}");
            
            if (fileInfo.Name.Contains("meta")) { continue; }

            var imageData = Instantiate(baseIcon, baseIcon.transform.parent);

            var bytes = File.ReadAllBytes(fileInfo.FullName);
            var texture2D = new Texture2D(1, 1);

            texture2D.LoadImage(bytes);

            var rect = new Rect(0, 0, texture2D.width, texture2D.height);
            var pivot = new Vector2(0.5f, 0.5f);

            var sprite = Sprite.Create(texture2D, rect, pivot);
            imageData.image.sprite = sprite;
            imageData.text.text = fileInfo.Name;
        }
        
        baseIcon.gameObject.SetActive(false);
    }
}
