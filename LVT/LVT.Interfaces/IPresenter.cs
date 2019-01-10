namespace LVT.LVT.Interfaces
{
    public interface IPresenter<T>
        where T: class
    {
     string VisualizeToString(T toVisualise, string parentNode);
    }

    public interface IMeasurePresenter : IPresenter<MeasureOld> { }
    public interface IEpicPresenter : IPresenter<EpicOld> { }
    public interface IInitiativePresenter : IPresenter<InitiativeOld> { }
    public interface IBetPresenter : IPresenter<BetOld> { }
    public interface IGoalPresenter : IPresenter<Goal> { }
    public interface IVisionPresenter : IPresenter<VisionOld> { }
}
