using System;
using UnityEngine;
using UnityEngine.UI;

public class Button_CharacterCustomize : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Image image;
    [SerializeField] private Text textLabel;

    public void Setup(string id, Action<string> callback)
    {
        textLabel.text = id;
        
        button.onClick.AddListener(delegate
        {
            callback?.Invoke(id);
        });
    }
    
    public void Setup(Sprite texture, Action<Sprite> callback)
    {
        image.sprite = texture;
        
        button.onClick.AddListener(delegate
        {
            callback?.Invoke(texture);
        });
    }
    
    public void Setup(Color color, Action<Color> callback)
    {
        image.material.color = color;
        
        button.onClick.AddListener(delegate
        {
            callback?.Invoke(color);
        });
    }
}
