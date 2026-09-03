# Copilot instructions

## Build, test, and lint commands

- Run commands from the repository root.
- Build the solution: `dotnet build InventarioISP20.sln`
- Run the app: `dotnet run --project Desktop\Desktop.csproj`
- Check for automated tests: `dotnet test InventarioISP20.sln`  
  This repository does not currently contain a test project, so this works as a solution-level check rather than executing test cases.
- No repository-specific lint or format command is configured. There is no `.editorconfig`, StyleCop, Roslynator, or dedicated formatting script in the repo.

## High-level architecture

- The repository is a single-project .NET 8 Windows Forms solution: `InventarioISP20.sln` loads `Desktop\Desktop.csproj`.
- `Desktop\Program.cs` is the entry point and starts the app by running `MenuPrincipalView`.
- UI code lives in `Desktop\Views\`. Each form is split across the usual WinForms partial files:
  - `<FormName>.cs` for behavior and event handlers
  - `<FormName>.Designer.cs` for generated control/layout code
  - `<FormName>.resx` for designer resources
- `MenuPrincipalView` is the current navigation hub. Its designer defines the main menu and icon-based controls, and its code-behind wires the behavior.
- Navigation is currently shallow and form-driven: `MenuPrincipalView` opens secondary forms directly. At the moment, `SubMenuArticulos_Click` creates `ArticulosView` and calls `Show()`, while `SubMenuSalirDelSistema_Click` closes the main window.
- `ArticulosView`, `CategoriasView`, `PrestamosView`, and `UbicacionesView` currently exist as shell forms with constructors that only call `InitializeComponent()`.

## Key conventions

- Preserve the WinForms partial-class split already used throughout the project: keep behavior in the `.cs` file, and avoid moving designer-managed layout code out of `.Designer.cs`.
- New screens should follow the existing naming pattern and location: `*View` forms under `Desktop\Views`.
- The main form uses `FontAwesome.Sharp` controls in designer code for menu and button icons. Reuse that package instead of introducing a second icon approach for the same UI surface.
- Secondary windows are opened modelessly with `Show()` from event handlers on the main form. Match that pattern unless the navigation model is being intentionally changed.
- Most forms use the `Desktop` namespace, but `UbicacionesView` uses `Desktop.Views` in both partial files. Keep partial class namespaces aligned when editing a form, and be deliberate if you normalize that inconsistency.

## Mandatory instructions
- Hablar en español.