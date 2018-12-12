using System;
using System.Collections.Generic;
using System.Text;

namespace LVT.LVT.Interfaces
{ /*the way I was thinking, we could add one or more descriptions for more complex Visualizer methods
    - for example one "to html", that adds tags to each object, or "to xml" etc -
  that we could then implement in the "Presenters" that I've created in the services, but probably worth checking with Kieron/Dan? */

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
