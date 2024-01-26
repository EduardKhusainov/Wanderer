using UnityEngine;
using Wanderer.NSUtilities;

public class GameManager : PersistentSingleton<GameManager>
{
    private void Awake()
    {
        SetCursorState(CursorLockMode.Locked);
    }
    
    public void SetCursorState(CursorLockMode mode)
    {
        Cursor.lockState = mode;
    }
}
