using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NavigationManager : MonoBehaviour
{
    [Header("Scene Names — must match Build Settings exactly")]
    public string[] sceneNames = {
        "Scene_Courtyard",
        "Scene_Cafe",
        "Scene_Library",
        "Scene_Classroom"
    };

    [Header("UI References")]
    public TextMeshProUGUI sceneCounterText;
    public TextMeshProUGUI locationNameText;

    private int currentIndex = 0;

    void Start()
    {
        string current = SceneManager.GetActiveScene().name;
        for (int i = 0; i < sceneNames.Length; i++)
        {
            if (sceneNames[i] == current)
            {
                currentIndex = i;
                break;
            }
        }
        UpdateUI();
    }

    public void GoToNext()
    {
        int next = (currentIndex + 1) % sceneNames.Length;
        SceneManager.LoadScene(sceneNames[next]);
    }

    public void GoToPrev()
    {
        int prev = (currentIndex - 1 + sceneNames.Length) % sceneNames.Length;
        SceneManager.LoadScene(sceneNames[prev]);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToNav()
    {
        SceneManager.LoadScene("NavPanel");
    }

    void UpdateUI()
    {
        if (sceneCounterText != null)
            sceneCounterText.text = (currentIndex + 1).ToString("D2") + " / 04";

        if (locationNameText != null)
        {
            string[] names = { "Courtyard", "Café", "Library", "Classroom" };
            locationNameText.text = names[currentIndex];
        }
    }
}