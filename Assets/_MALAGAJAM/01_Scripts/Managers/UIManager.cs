using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager uiManagerInstance;

    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject gameOverContainer;

    private void Awake() { uiManagerInstance = this; }



}