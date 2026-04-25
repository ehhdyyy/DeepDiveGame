using UnityEngine;
using UnityEngine.SceneManagement;

// GameStateUI manages all UI elements related to the game's state, including the start screen, game UI, and win/death screens. It also handles transitioning between these states and managing related audio and gameplay elements.
public class GameStateUI : MonoBehaviour
{
    [Header("UI")]
    public GameObject startScreen;
    public GameObject gameUI;

    [Header("Cameras and VFX")]
    public GameObject startCam;
    public GameObject startCamVFX;

    [Header("Audio")]
    public GameObject startScreenAudio;
    public GameObject gameAudio;

    [Header("Gameplay")]
    public GameObject player;
    public GameObject spawnZone;
    public GameObject fishZone;
    public GameObject hud;
    public GameObject starterItems;
    public GameObject enemy;
    public GameObject spawnedObjectFolder;


    // Triggered by start button on start screen. Transitions to game state by enabling/disabling relevant UI, audio, and gameplay objects.
    public void StartGame()
    {
        if (gameUI != null) gameUI.SetActive(true);
        if (startCam != null) startCam.SetActive(false);
        if (startScreen != null) startScreen.SetActive(false);
        if (startCamVFX != null) startCamVFX.SetActive(false);
        if (startScreenAudio != null) startScreenAudio.SetActive(false);
        if (gameAudio != null) gameAudio.SetActive(true);
        if (player != null) player.SetActive(true);
        if (spawnZone != null) spawnZone.SetActive(true);
        if (fishZone != null) fishZone.SetActive(true);
        if (hud != null) hud.SetActive(true);
        if (starterItems != null) starterItems.SetActive(true);
        if (enemy != null) enemy.SetActive(true);
        if (spawnedObjectFolder != null) spawnedObjectFolder.SetActive(true);

        Time.timeScale = 1f;
    }

    // Triggered by restart button on win/death screens. Resets the scene to start fresh.
    public void ResetToFreshScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}