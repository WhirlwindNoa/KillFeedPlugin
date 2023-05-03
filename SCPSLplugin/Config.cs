namespace SCPSLplugin
{
    using Exiled.API.Interfaces;
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; }
        bool IConfig.Debug { get; set; }
    }
}
