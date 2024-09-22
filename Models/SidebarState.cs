namespace FirstProjectWithMVC.Models
{
    public class SidebarState
    {
        public bool IsOpen { get; set; }
        public Dictionary<string, bool> SubmenuStates { get; set; } = new Dictionary<string, bool>();
    }
}
