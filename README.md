🎮 XboxMacro - Controller Service

This project provides a controller service for polling Xbox controller input using SharpDX.XInput. It maps button events to custom actions and can be easily extended or integrated into larger automation or macro systems.
🚀 Features

    Polls Xbox controller input at a regular interval (every 10ms).

    Detects individual button presses (A, B, X, Y, D-Pad, Shoulders, Start, etc.).

    Fires user-defined actions on button press via ButtonEventEntity.

    Notifies subscribers when the controller connects or disconnects.

    Designed with modularity and reusability in mind.

🛠️ Technologies Used

    .NET (C#)

    SharpDX.XInput - for controller input

    System.Timers.Timer - for polling

📦 Installation

Install SharpDX.XInput via NuGet:

Install-Package SharpDX.XInput

📄 Usage Example

var controllerService = new ControllerService();

controllerService.ButtonEvent.A = () => Console.WriteLine("A button pressed!");
controllerService.ControllerStateChanged += state => Console.WriteLine(state);

// Keep the app running...
Console.ReadLine();

controllerService.Dispose();

🧩 Architecture

    ControllerService: Handles polling, button state checking, and invoking corresponding actions.

    ButtonEventEntity: Container for delegate actions assigned to controller buttons.

    IControllerService: Interface abstraction (assumed part of your codebase).

🔄 Customization

To change the behavior for each button, assign your own Action:

controllerService.ButtonEvent.Y = () => PerformSpecialMove();

You can refresh button-action mappings at runtime using:

controllerService.RefreshButtonActions();

❗ Notes

    Requires a connected Xbox controller.

    Ensure your app handles disposal to stop polling (Dispose() method).
