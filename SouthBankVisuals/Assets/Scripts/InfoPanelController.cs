using UnityEngine;
using UnityEngine.Video;

public class InfoPanelController : MonoBehaviour
{
    [Header("References")]
    public GameObject infoPanel;
    public SkyspherController skysphereController;

    [Header("Robot Video (Scene_Cafe only)")]
    public VideoClip robotVideo;
    public VideoClip originalVideo;

    private bool isRobotView = false;

    public void OpenPanel()
    {
        infoPanel.SetActive(true);
    }

    public void ClosePanel()
    {
        infoPanel.SetActive(false);
    }

    public void ToggleRobotView()
    {
        if (skysphereController == null) return;

        if (!isRobotView)
        {
            skysphereController.SwapVideo(robotVideo);
            isRobotView = true;
        }
        else
        {
            skysphereController.SwapVideo(originalVideo);
            isRobotView = false;
        }
    }
}