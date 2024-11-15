using JetBrains.Annotations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public InputActionAsset playerControls;
    [SerializeField] private bool isPaused;
    [SerializeField] private string inputText;
    [SerializeField] private float currentTime;
    private static List<float> timeList = new List<float>();

    private static List<string> inputDataList = new List<string>();
    private string filename;
    [SerializeField] private TMP_InputField inputField;
    private InputAction pauseAction;

    public static PauseMenuController Instance;

    private InputAction menu;


    //public event EventHandler OnPauseAction;

    //[SerializeField] private GameObject pauseUI;

    //[SerializeField] private Button LoadNextButton;
    // [SerializeField] private Button BackToGameButton;

    private void Update()
    {
        if (!isPaused)
        {
            currentTime += Time.unscaledDeltaTime;
        }
    }

    private void Start()
    {
        currentTime = 0f;
        filename = Application.dataPath + "/times.csv";
        //Debug.Log("Filename is: " + filename);
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    private void Awake()
    {
        pauseAction = playerControls.FindActionMap("XRI UI").FindAction("Pause");
        //menu = playerControls.XRI_UI.Pause;
    }

    private void OnEnable()
    {
        pauseAction.performed += Pause;
        pauseAction.Enable();
        //playerControls.Player.Look;
        //menu.performed += Pause;
    }

    private void OnDisable()
    {
        pauseAction.performed -= Pause;
        pauseAction.Disable();
    }

    void Pause(InputAction.CallbackContext context)
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            ActivateMenu();
        }
        else
        {
            DeactivateMenu();
        }

    }

    void ActivateMenu()
    {
        //playerControls.Player.Look.Disable();
        timeList.Add(currentTime);
        Debug.Log("Current time is" + currentTime);

        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        AudioListener.pause = true;
        pauseMenuUI.SetActive(true);
    }

    public void DeactivateMenu()
    {
        //playerControls.Player.Look.Enable();
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseMenuUI.SetActive(false);
    }


    public void LoadScene(string sceneName)
    {
        //inputDataList.Add(inputText);
        //for (int i = 0; i < inputDataList.Count; i++)
        //{
        //    Debug.Log("List is: " + inputDataList[i]);
        //}
        //Debug.Log("Current inputText value is: " + inputText);

        if (System.Enum.TryParse(sceneName, out Loader.Scene targetScene))
        {
            Loader.Load(targetScene);
        }
        else
        {
            Debug.LogError($"Scene {sceneName} is not defined in Loader.Scene enum.");
        }
    }

    public void updateInputVariable(string input)
    {
        Debug.Log("Input Value is: " + inputText);
        inputText = input;
    }

    [System.Serializable]
    public class Participant
    {
        public string codename;
    }

    public Participant myParticipant = new Participant();

    public void experimentEnded()
    {
        //if (inputDataList.Count == 0)
        //{
        //    Debug.Log("There was nothing to write");
        //    return;
        //}

        using (TextWriter tw = new StreamWriter(filename, false))
        {
            tw.WriteLine("Codename, Stage1Gray, Stage2Gray, Stage3Gray, Stage4Gray, Stage5Color, Stage6Color, Stage7Color");
            string csvLine = myParticipant.codename;

            foreach (float time in timeList)
            {
                csvLine += "," + time;
            }
            tw.WriteLine(csvLine);
        }

        Application.Quit();
    }

}
