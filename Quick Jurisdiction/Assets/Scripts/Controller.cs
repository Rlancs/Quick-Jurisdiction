using UnityEngine;
using System.IO.Ports;
using System.Threading;
using UnityEngine.SceneManagement;
using TMPro;

public class Controller : MonoBehaviour
{
    // Accesses other scripts for methods to change criminals and reset the timer
    [SerializeField] private CriminalArray criminalScript;
    [SerializeField] private Timer timerScript;

    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject portMenu;
    [SerializeField] private GameObject gameplayUI;
    [SerializeField] private TMP_InputField portText;
    [SerializeField] private GameObject guilty;
    [SerializeField] private GameObject notGuilty;
    Thread IOThread = new Thread(DataThread);
    private static SerialPort sp;

    // The data to be read, the data to be outputted, and the port the controller is connected to
    private static string dataIn = "";
    private static string dataOut = "";
    private static string port = "COM3";

    private bool guiltyState = false;
    private bool notGuiltyState = false;
    private bool gameStart = true;
    public bool gameEnd = false;

    /// <summary>
    /// Establishes connection with the controller, then repeatedly reads incoming string data from the arduino serial monitor
    /// </summary>
    private static void DataThread()
    {
        sp = new SerialPort(port, 115200);
        sp.Open();

        while (true)
        {
            if (dataOut != "")
            {
                sp.Write(dataOut);
                dataOut = "";
            }

            dataIn = sp.ReadExisting();
            Thread.Sleep(1000);
        }
    }

    private void OnDestroy()
    {
        IOThread.Abort();
        sp.Close();
    }

    /// <summary>
    /// Executes when the user inputs the port as a string at the beginning of the game, starting the game.
    /// </summary>
    public void PortSet()
    {
        gameStart = false;
        portMenu.SetActive(false);
        gameplayUI.SetActive(true);
        startMenu.SetActive(true);
        port = portText.text;
        IOThread.Start();
    }

    void Start()
    {
        Time.timeScale = 0f;
    }

    private void Update()
    {
        // Will constantly display the currently chosen verdict
        guilty.SetActive(guiltyState);
        notGuilty.SetActive(notGuiltyState);
        if (dataIn != "")
        {
            // If there is an input from the controller, the string input is parsed to an integer
            var data = uint.Parse(dataIn);
            dataIn = "";
            // During game time
            if (Time.timeScale == 1f)
            {
                switch (data)
                {
                    // Checks for gavel and stamp inputs
                    case (int)ControllerInput.Hammer:
                        // A verdict must be given for a trial to adjourn and the next criminal to be loaded
                        if (guiltyState == true || notGuiltyState == true)
                        {
                            criminalScript.NewCriminal();
                            timerScript.ResetTime();
                            notGuiltyState = false;
                            guiltyState = false;
                        }
                        break;
                    case (uint)ControllerInput.Guilty:
                        guiltyState = true;
                        notGuiltyState = false;
                        break;
                    case (uint)ControllerInput.NotGuilty:
                        guiltyState = false;
                        notGuiltyState = true;
                        break;
                }
            }
            // During the beginning or end of the game
            else
            {
                // Game starts on a gavel input
                if (gameStart == false && data == (int)ControllerInput.Hammer)
                {
                    Time.timeScale = 1f;
                    startMenu.SetActive(false);
                    StartCoroutine(criminalScript.AttorneyDialogue());
                    StartCoroutine(criminalScript.ProsecutorDialogue());
                    gameStart = true;
                }
                else if (gameEnd == true)
                {
                    // Checks which stamp is used, resulting in the game either restarting or quitting
                    switch (data)
                    {
                        case (uint)ControllerInput.Guilty:
                            Application.Quit();
                            break;
                        case (uint)ControllerInput.NotGuilty:
                            SceneManager.LoadScene("Courtroom");
                            break;
                    }
                }
            }
        }
    }

    public enum ControllerInput : uint
    {
        Hammer = 1,
        Guilty = 3522879144,
        NotGuilty = 3598154146
    }
}
