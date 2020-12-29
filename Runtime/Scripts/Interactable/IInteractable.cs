namespace Interaction
{
    public interface IInteractable
    {
        void Interact(IInteractor interactor, InteractionType type);
    }
}