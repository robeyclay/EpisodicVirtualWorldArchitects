using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    private static Scene targetScene;

    public enum Scene
    {
        Color_EmptyScene,
        Color_FinalScene,
        Color_hightolow_step1,
        Color_hightolow_step2,
        Color_lowtohigh_step1,
        Color_lowtohigh_step2,
        EndScene,
        Gray_EmptyScene,
        Gray_FinalScene,
        Gray_hightolow_step1,
        Gray_hightolow_step2,
        Gray_lowtohigh_step1,
        Gray_lowtohigh_step2,
        LoadingScene,
        MainMenu
    }

    public static void Load(Scene targetScene)
    {
        Loader.targetScene = targetScene;
        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }

    public static void LoaderCallback()
    {
        SceneManager.LoadScene(targetScene.ToString());
    }

}
