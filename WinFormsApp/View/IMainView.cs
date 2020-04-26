using WinFormsApp.Presenter;

namespace WinFormsApp.View
{
    public interface IMainView
    {
        MainPresenter Presenter { set; }
    }
}
