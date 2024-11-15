using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Script: MonoBehaviour
{
    [SerializeField] private Button StartButton;
    [SerializeField] private Button QuitButton;


    private void Awake()
    {
        StartButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.Gray_EmptyScene);
        });


        QuitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }


}
