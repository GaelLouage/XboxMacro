using XboxMacro.Models;

namespace XboxMacro.Services.Interfaces
{
    public interface IControllerService
    {
        event Action<string> ControllerStateChanged;
        ButtonEventEntity ButtonEvent { get; set; }
        void RefreshButtonActions();
    }
}
