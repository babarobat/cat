using UnityEngine;

namespace Client.Runtime
{
    public class CatSimulatorSceneContext : MonoBehaviour
    {
        [SerializeField] private HUDView _hudView;
        public HUDView HudView => _hudView;

        public void CleanUp()
        {
            HudView.CleanUp();
        }
    }
}