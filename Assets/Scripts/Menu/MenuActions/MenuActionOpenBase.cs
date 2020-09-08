using System.Threading.Tasks;

namespace MutatronicMenues
{
    public abstract class MenuActionOpenBase : MenuActionBase
    {
        protected override void ManageHistory()
        {
            MenuController.MenuHistory.Add(targetMenu);
        }
    }
}