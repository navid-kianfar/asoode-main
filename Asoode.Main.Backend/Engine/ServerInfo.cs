using Asoode.Main.Core.Contracts.General;

namespace Asoode.Main.Backend.Engine
{
    internal class ServerInfo : IServerInfo
    {
        public string ContentRootPath { get; set; }
        public string EmailsRootPath { get; set; }
        public string FilesRootPath { get; set; }
        public string I18nRootPath { get; set; }
        public string RootPath { get; set; }
        public string SmsRootPath { get; set; }
        public string Domain { get; set; }
    }
}