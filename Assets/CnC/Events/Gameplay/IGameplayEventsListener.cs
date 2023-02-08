/// dystop.us | 08.02.2023
namespace CnC.Events
{
    public interface IGameplayEventsListener 
    {
        /// <summary>
        /// Calls when <b>GameplayEvent.FishCatched</b> event is dispatched by <b>GameplayEventsManager</b>
        /// </summary>
        /// <typeparam name="CustomParameterType"></typeparam>
        /// <param name="parameters"></param>
         /*
        public void OnFishCatched<CustomParameterType>(params CustomParameterType[] parameters);
         */

        public void OnInstantFishCatch(params object[] parameters);
    }
}
