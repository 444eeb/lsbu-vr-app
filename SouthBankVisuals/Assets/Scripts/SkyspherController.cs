using UnityEngine;
using UnityEngine.Video;

public class SkyspherController : MonoBehaviour
{
    [Header("360 Content — assign image OR video, not both")]
    public Texture2D panoramicImage;
    public VideoClip panoramicVideo;

    [Header("References")]
    public Renderer sphereRenderer;

    private Material skyMaterial;
    private VideoPlayer videoPlayer;

    void Start()
    {
        skyMaterial = new Material(Shader.Find("Skybox/Panoramic"));
        skyMaterial.SetFloat("_Mapping", 1);
        sphereRenderer.material = skyMaterial;

        if (panoramicVideo != null)
            SetupVideo();
        else if (panoramicImage != null)
            SetupImage();
        else
            Debug.LogWarning("SkyspherController: No content assigned on " + gameObject.name);
    }

    void SetupImage()
    {
        skyMaterial.SetTexture("_MainTex", panoramicImage);
        Debug.Log("Skysphere: image loaded — " + panoramicImage.name);
    }

    void SetupVideo()
    {
        RenderTexture rt = new RenderTexture(
            (int)panoramicVideo.width,
            (int)panoramicVideo.height, 0);

        videoPlayer = gameObject.AddComponent<VideoPlayer>();
        videoPlayer.clip = panoramicVideo;
        videoPlayer.targetTexture = rt;
        videoPlayer.isLooping = true;
        videoPlayer.playOnAwake = true;
        videoPlayer.renderMode = VideoRenderMode.RenderTexture;

        skyMaterial.SetTexture("_MainTex", rt);
        videoPlayer.Play();
        Debug.Log("Skysphere: video loaded — " + panoramicVideo.name);
    }

    public void SwapImage(Texture2D newImage)
    {
        if (videoPlayer != null) videoPlayer.Stop();
        skyMaterial.SetTexture("_MainTex", newImage);
    }
}