namespace Asoode.Main.Core.Contracts.General
{
    public interface IServerInfo
    {
        string ContentRootPath { get; set; }
        string EmailsRootPath { get; set; }
        string FilesRootPath { get; set; }
        string I18nRootPath { get; set; }
        string RootPath { get; set; }
        string SmsRootPath { get; set; }
    }
}