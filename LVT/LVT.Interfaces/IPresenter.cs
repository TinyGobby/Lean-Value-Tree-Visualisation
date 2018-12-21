namespace LVT.LVT.Interfaces
{
    public interface IPresenter<T>
        where T: class
    {
     string VisualizeToString(T toVisualise, string parentNode);
    }

    public interface IMeasurePresenter : IPresenter<Measure> { }
    public interface IEpicPresenter : IPresenter<Epic> { }
    public interface IInitiativePresenter : IPresenter<Initiative> { }
    public interface IBetPresenter : IPresenter<Bet> { }
    public interface IGoalPresenter : IPresenter<Goal> { }
    public interface IVisionPresenter : IPresenter<Vision> { }
}
