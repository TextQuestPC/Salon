using UI;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "ValuesController", menuName = "Controllers/ValuesController")]
    public class ValuesController : Controller
    {
        private int money;

        public void AddMoney(int value)
        {
            money += value;

            UIManager.GetWindow<UIWindow>().ChangeMoneyText(money);
        }
    }
}