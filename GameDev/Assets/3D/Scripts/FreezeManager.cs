using UnityEngine;

public static class FreezeManager
{
    private static Player player;
    private static PlayerLook camera;
    private static bool isFrozen = false;

    public static void Init(Player playerRef, PlayerLook cameraRef)
    {
        player = playerRef;
        camera = cameraRef;
    }

    public static void Freeze()
    {
        if (isFrozen) return;
        
        if (player != null) player.freezePLayer();
        if (camera != null) camera.freezeCamera();
        
        isFrozen = true;
        Debug.Log("Player & Camera gefreezed");
    }

    public static void Unfreeze()
    {
        if (!isFrozen) return;
        
        if (player != null) player.unfreezePlayer();
        if (camera != null) camera.unfreezeCamera();
        
        isFrozen = false;
        Debug.Log("Player & Camera unfreezed");
    }

    public static bool IsFrozen()
    {
        return isFrozen;
    }

    public static void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public static void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public static void Reset()
    {
        player = null;
        camera = null;
        isFrozen = false;
    }
}