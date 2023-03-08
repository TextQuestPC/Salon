using InputSystem;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "InputController", menuName = "Controllers/InputController")]
    public class InputController : Controller
    {
        private TouchSystem touchSystem;

        public override void OnStart()
        {
            touchSystem = BoxControllers.GetController<CreatorController>().CreateTouchSystem();

            touchSystem.SetPlayer = BoxControllers.GetController<GameController>().GetPlayer;
        }
    }
}