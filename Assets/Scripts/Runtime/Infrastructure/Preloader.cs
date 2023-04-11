using UnityEngine;

namespace Client.Runtime
{
    public class Preloader : MonoBehaviour, IPreloader
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}