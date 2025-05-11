using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using XboxMacro.Models;
using XboxMacro.Services.Interfaces;

namespace XboxMacro.Services.Classes
{
    public class ControllerService : IControllerService
    {
        public ButtonEventEntity ButtonEvent { get; set; } = new ButtonEventEntity();
        public event Action<string> ControllerStateChanged;
        private Controller _controller;
        private System.Timers.Timer _timer;
        private TimeSpan elapsed;
        private DateTime _startTime;
        private Dictionary<GamepadButtonFlags, Action?> _buttonActions;


        public ControllerService()
        {
            _controller = new Controller(UserIndex.One);
            _timer = new System.Timers.Timer();
            _timer.Elapsed += OnTimedEvent;
            _timer.Elapsed += OnStateChanged;
            _timer.Interval = 10;
            _timer.Enabled = true;
            _startTime = DateTime.Now;
            RefreshButtonActions();
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            try
            {
                if (_controller.IsConnected)
                {

                    foreach (var (flag, action) in _buttonActions)
                    {
                        if (_controller.GetState().Gamepad.Buttons.HasFlag(flag))
                            action?.Invoke();
                    }
                }
            }
            catch (Exception ex)
            {
                ControllerStateChanged?.Invoke($"Error polling controller: {ex.Message}");
            }
        }
        public void RefreshButtonActions()
        {
            _buttonActions = new Dictionary<GamepadButtonFlags, Action?>
                    {
                        {GamepadButtonFlags.A, ButtonEvent.A },
                        {GamepadButtonFlags.B, ButtonEvent.B },
                        {GamepadButtonFlags.Y, ButtonEvent.Y },
                        {GamepadButtonFlags.X, ButtonEvent.X },
                        {GamepadButtonFlags.Back, ButtonEvent.Back },
                        {GamepadButtonFlags.DPadDown, ButtonEvent.DpadDown },
                        {GamepadButtonFlags.DPadLeft, ButtonEvent.DPadLeft},
                        {GamepadButtonFlags.DPadRight, ButtonEvent.DPadRight},
                        {GamepadButtonFlags.DPadUp, ButtonEvent.DPadUp},
                        {GamepadButtonFlags.LeftShoulder, ButtonEvent.LeftShoulder},
                        {GamepadButtonFlags.RightShoulder, ButtonEvent.RightShoulder},
                        {GamepadButtonFlags.LeftThumb, ButtonEvent.LeftThumb},
                        {GamepadButtonFlags.RightThumb, ButtonEvent.RightThumb},
                        {GamepadButtonFlags.Start, ButtonEvent.Start},
                    };
        }

        public void OnStateChanged(object source, ElapsedEventArgs e)
        {
            if (_controller.IsConnected)
            {
                ControllerStateChanged?.Invoke("controller IsConnected");
            }
            else
            {
                ControllerStateChanged?.Invoke("controller IsDisConnected");
            }
        }

        public void Dispose()
        {
            _timer?.Stop();
            _timer?.Dispose();
        }
    }
}
