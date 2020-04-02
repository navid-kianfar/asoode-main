namespace Asoode.Main.Core.ViewModel.General
{
    public class SelectableItem<T>
    {
        public object Payload { get; set; }
        public bool? Disabled { get; set; }
        public string Icon { get; set; }
        public string Image { get; set; }
        public bool? Selected { get; set; }
        public string Text { get; set; }
        public T Value { get; set; }
    }
}