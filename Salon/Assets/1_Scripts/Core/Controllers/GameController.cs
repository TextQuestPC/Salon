using Characters;
using ObjectsOnScene;
using SystemMove;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "GameController", menuName = "Controllers/GameController")]
    public class GameController : Controller
    {
        private Player player;

        public Player GetPlayer { get => player; }

        public override void OnStart()
        {
            player = BoxControllers.GetController<CreatorController>().CreatePlayer();
            Camera.main.GetComponent<MoveCameraComponent>().SetNextTarget(player.transform);
        }

        #region ACTIONS_GAME

        public void PlayerTryGetItem(TypeItem typeItem)
        {
            if (player.CheckCanGetItem())
            {
                player.GetItemFromPlace(typeItem);
            }
        }

        public void CompleteProcedure(Service service)
        {
            player.RemoveItem(service.GetTypeNeedItem);
        }

        #endregion ACTIONS_GAME
    }
}