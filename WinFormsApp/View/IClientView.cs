using WinFormsApp.Presenter;

namespace WinFormsApp.View
{
    public interface IClientView
    {
        ClientsPresenter Presenter { set; }
    }
}
