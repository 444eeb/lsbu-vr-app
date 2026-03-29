using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class Hotspot : MonoBehaviour
{
    [Header("Content")]
    public string hotspotTitle = "Location Name";
    [TextArea] public string hotspotDescription = "Description of this location.";

    [Header("References")]
    public GameObject infoPanel;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descText;

    [Header("Colours")]
    public Color defaultColor = new Color(0.294f, 0.149f, 0.510f);
    public Color hoverColor = Color.white;

    private XRBaseInteractable interactable;
    private Renderer hotspotRenderer;
    private bool isPanelOpen = false;

    void Start()
    {
        hotspotRenderer = GetComponent<Renderer>();
        hotspotRenderer.material.color = defaultColor;

        interactable = GetComponent<XRBaseInteractable>();
        interactable.selectEntered.AddListener(OnSelected);
        interactable.hoverEntered.AddListener(OnHoverEnter);
        interactable.hoverExited.AddListener(OnHoverExit);

        if (infoPanel != null)
            infoPanel.SetActive(false);
    }

    void OnSelected(SelectEnterEventArgs args) => TogglePanel();

    void OnHoverEnter(HoverEnterEventArgs args) =>
        hotspotRenderer.material.color = hoverColor;

    void OnHoverExit(HoverExitEventArgs args) =>
        hotspotRenderer.material.color = defaultColor;

    void TogglePanel()
    {
        isPanelOpen = !isPanelOpen;

        if (isPanelOpen)
        {
            titleText.text = hotspotTitle;
            descText.text = hotspotDescription;
            infoPanel.SetActive(true);

            Transform cam = Camera.main.transform;
            infoPanel.transform.LookAt(cam);
            infoPanel.transform.Rotate(0, 180, 0);
        }
        else
        {
            infoPanel.SetActive(false);
        }
    }

    public void ClosePanel()
    {
        isPanelOpen = false;
        infoPanel.SetActive(false);
    }

    void OnDestroy()
    {
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnSelected);
            interactable.hoverEntered.RemoveListener(OnHoverEnter);
            interactable.hoverExited.RemoveListener(OnHoverExit);
        }
    }
}