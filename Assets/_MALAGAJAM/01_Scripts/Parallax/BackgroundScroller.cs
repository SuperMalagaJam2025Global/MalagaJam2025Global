using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Range(-100f, 100f)] [SerializeField] float scrollSpeed;
    private float offset;
    private Material mat;

    private void Awake() { mat = GetComponent<Renderer>().material; }

    private void Update() { ApplyParallaxToTexture(); }

    private void ApplyParallaxToTexture()
    {
        offset += (Time.deltaTime * scrollSpeed) / 10;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}