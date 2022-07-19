using ImGuiNET;
using JuceEngine.Editor.Resources.UseCases;

namespace JuceEngine.Editor.General.UseCases
{
    public sealed class DrawEditorUseCase
    {
        readonly DrawResourcesWindowUseCase _drawResourcesWindowUseCase;

        public DrawEditorUseCase(
            DrawResourcesWindowUseCase drawResourcesWindowUseCase
            )
        {
            _drawResourcesWindowUseCase = drawResourcesWindowUseCase;
        }

        public void Execute()
        {
            // Draw whatever you want here.
            if (ImGui.Begin("Test Window"))
            {
                ImGui.Text("Hello");
            }
            ImGui.End();

            _drawResourcesWindowUseCase.Execute();
        }
    }
}
