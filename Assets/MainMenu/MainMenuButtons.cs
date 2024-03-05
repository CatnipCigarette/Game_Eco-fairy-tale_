using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public string LesLeshego;
    public string Field;
    public string UnderWater;
    public string SnowForest;
    public string Clouds;

    public Button GGCTTiD;
    public Button SaveForest;
    public Button FindGrow;
    public Button CleanLake;
    public Button SortTrash;
    public Button BuildWind;
    public Button Exit;

    void Start()
    {
        GGCTTiD.onClick.AddListener(OpenGGCTTiD);
        SaveForest.onClick.AddListener(StartSaveForest);
        FindGrow.onClick.AddListener(StartFindGrow);
        CleanLake.onClick.AddListener(StartCleanLake);
        SortTrash.onClick.AddListener(StartSortTrash);
        BuildWind.onClick.AddListener(StartBuildWind);
        Exit.onClick.AddListener(ExitGame);
    }

    private void OpenGGCTTiD()
    {
        Application.OpenURL("https://ggkttd.by");
    }

    private void StartSaveForest()
    {
        SceneManager.LoadScene(LesLeshego);
    }

    private void StartFindGrow()
    {
        SceneManager.LoadScene(Field);
    }

    private void StartCleanLake()
    {
        SceneManager.LoadScene(UnderWater);
    }

    private void StartSortTrash()
    {
        SceneManager.LoadScene(SnowForest);
    }

    private void StartBuildWind()
    {
        SceneManager.LoadScene(Clouds);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
